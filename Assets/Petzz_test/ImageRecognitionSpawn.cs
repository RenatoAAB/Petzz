using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

public class ImageRecognitionSpawn : MonoBehaviour
{
    private ARTrackedImageManager arImageManager;

    private void Awake(){
      arImageManager = FindObjectOfType<ARTrackedImageManager>();
    }

    public void OnEnable(){
      arImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable(){
      arImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args){
      foreach (var trackedImage in args.added){
        Debug.Log(trackedImage.name);
      }
    }
}
