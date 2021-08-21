using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARTapToPlace : MonoBehaviour
{

    public GameObject gameObjectToInstatiate;
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private float scaleAmount = 0.0008f;
    private float rotateAmount = 1f;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition) {
        if (Input.touchCount ==1) {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        else if (Input.multiTouchEnabled && Input.touchCount == 2 && spawnedObject != null)
        {
            var scale = spawnedObject.transform.localScale;
            spawnedObject.transform.localScale = new Vector3((float)(scale.x + scaleAmount), (float)(scale.y + scaleAmount), (float)(scale.z + scaleAmount));
        }
        else if (Input.multiTouchEnabled && Input.touchCount == 3 && spawnedObject != null)
        {
            var scale = spawnedObject.transform.localScale;
            spawnedObject.transform.localScale = new Vector3((float)(scale.x - scaleAmount), (float)(scale.y - scaleAmount), (float)(scale.z - scaleAmount));
        }
        touchPosition = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            return;

        if (_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon)) {
            var hitPose = hits[0].pose;


            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(gameObjectToInstatiate, hitPose.position, hitPose.rotation);
            }
            else {
                spawnedObject.transform.position = hitPose.position;
                try
                {
                    spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.rotation = hitPose.rotation;
                    var childrotate = spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.eulerAngles;
                    spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3((float)(childrotate.x ), (float)(childrotate.y + 90), (float)(childrotate.z)); ;
                }
                catch (Exception)
                {
                    Debug.Log("HERE");
                }
            }
        }
    }
}
