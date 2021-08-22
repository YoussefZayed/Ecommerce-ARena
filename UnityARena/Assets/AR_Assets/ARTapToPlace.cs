using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ARTapToPlace : MonoBehaviour
{
    public GameObject Monitor;
    public GameObject Tv;
    private GameObject gameObjectToInstatiate;
    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private Vector2 touchPosition;
    private float scaleAmount = 0.0008f;
    private float rotateAmount = 1f;
    public Text txt;
    

    private List<Tuple<string,string>> productInfo;
    private int currentItem = 0;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    private void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        gameObjectToInstatiate = Monitor;
        Tuple<string, string>[] data = { new Tuple<string, string>("Monitor","Asus 27inch LCD" ),
                            new Tuple<string, string>("TV","Samsung 57inch LCD" ),
                            new Tuple<string, string>("Monitor","Samsung 27inch LCD" ),new Tuple<string, string>("Monitor","Acer 27inch LCD" ),new Tuple<string, string>("TV","TCL 57inch LCD" ) };
        productInfo = new List<Tuple<string, string>>(data);
        currentItem = -1;
        nextItem(true);
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
                try
                {
                    spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.rotation = hitPose.rotation;
                    var childrotate = spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.eulerAngles;
                    spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3((float)(childrotate.x), (float)(childrotate.y + 90), (float)(childrotate.z)); ;
                    
                }
                catch (Exception)
                {

                }
            }
            else {
                spawnedObject.transform.position = hitPose.position;
                try
                {
                    spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.rotation = hitPose.rotation;
                        var childrotate = spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.eulerAngles;
                        spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.eulerAngles = new Vector3((float)(childrotate.x), (float)(childrotate.y + 90), (float)(childrotate.z)); ;
                   
                    
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }

    public void nextItem(bool next) {
        if (next)
        {
            if (currentItem + 1 >= productInfo.Count)
            {
                currentItem = 0;
            }
            else
            {
                currentItem += 1;
            }
        }
        else
        {
            if (currentItem - 1 < 0)
            {
                currentItem = productInfo.Count - 1;
            }
            else
            {
                currentItem -= 1;
            }
        }
        var newGameObject = gameObjectToInstatiate;
        if (productInfo[currentItem].Item1 == "Monitor")
        {
            newGameObject = Monitor;
        }
        else {
            newGameObject = Tv;
        }
        txt.GetComponent<UnityEngine.UI.Text>().text = productInfo[currentItem].Item2;
        try
        {
            if (newGameObject != gameObjectToInstatiate)
            {
                gameObjectToInstatiate = newGameObject;
                var curPose = spawnedObject.transform.position;
                var curRote = spawnedObject.transform.GetChild(0).gameObject.transform.GetChild(0).transform.rotation;
                Destroy(spawnedObject);
                spawnedObject = null;
            }
        }
        catch (Exception)
        {
            Debug.Log("HERE2");
        }
    }
}
