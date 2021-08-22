using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
public class ImageTracking : MonoBehaviour
{
    private ARTrackedImageManager _aRTrackedImageManager;
    // Start is called before the first frame update
    void Awake()
    {
        _aRTrackedImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable()
    {
        _aRTrackedImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable()
    {
        _aRTrackedImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args) 
    {
        foreach (var trackedImage in args.added)
        {
            Debug.Log(trackedImage.name);
        }
    }
}
