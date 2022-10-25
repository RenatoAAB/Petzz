using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine.Experimental.XR;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class ImageRecognitionSpawn : MonoBehaviour

{
    [SerializeField]
    private GameObject[] placeablePrefabs;

    bool spawnado = false;
    private GameObject camera;
    private Dictionary<string, GameObject> spawnedPrefabs = new Dictionary<string, GameObject>();
    private ARTrackedImageManager arImageManager;

    private void Awake(){
      arImageManager = FindObjectOfType<ARTrackedImageManager>();
      camera = GameObject.Find("AR Camera");

      foreach(GameObject prefab in placeablePrefabs){
        GameObject newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity);
        newPrefab.name = prefab.name;
        spawnedPrefabs.Add(prefab.name, newPrefab);
      }
    }

    public void OnEnable(){
      arImageManager.trackedImagesChanged += OnImageChanged;
    }

    public void OnDisable(){
      arImageManager.trackedImagesChanged -= OnImageChanged;
    }

    public void OnImageChanged(ARTrackedImagesChangedEventArgs args){
      foreach (ARTrackedImage trackedImage in args.added){
        UpdateImage(trackedImage);
      }
      foreach (ARTrackedImage trackedImage in args.updated){
        UpdateImage(trackedImage);
      }
      foreach (ARTrackedImage trackedImage in args.removed){
        spawnedPrefabs[trackedImage.name].SetActive(false);
      }
    }

    private void UpdateImage(ARTrackedImage trackedImage){
      string name = trackedImage.referenceImage.name;
      Vector3 position = trackedImage.transform.position;

      GameObject prefab = spawnedPrefabs[name];
      prefab.transform.position = position;
      prefab.transform.LookAt(camera.transform.position);
      if(spawnado == false){
          PerguntasUI.Instance.ShowQuestion("Quer invocar o urso?", () => {
            prefab.SetActive(true);
            spawnado = true;
            AnimController.instantiatedBear(prefab);
          }, () => {

        });  
      }
   
      
      foreach(GameObject go in spawnedPrefabs.Values)
      {
        if(go.name != name){
          go.SetActive(false);
        }
      }
    }
}
