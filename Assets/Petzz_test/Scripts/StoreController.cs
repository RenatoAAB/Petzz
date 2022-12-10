using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreController : MonoBehaviour
{

    public static StoreController Instance { get; private set; }

    private Button storeButton;
    private List<GameObject> items = new List<GameObject>();
    private bool storeActive = false;

    private void Awake()
    {
        Instance = this;
        storeButton = transform.Find("LojaButton").GetComponent<Button>();
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("itemStore")) {
             items.Add(i);
             i.SetActive(false);
        }
    }

    public void Start ()
    {
        LoadJsonData(Instance);
        storeButton.onClick.AddListener(() => {
            OnStoreButtonClick();
        });
    }

    public void OnStoreButtonClick(){
        if(storeActive){
            Debug.Log("off");
            foreach(GameObject i in items) {
                i.SetActive(false);
            }
            storeActive = false;
        }
        else{
            Debug.Log("on");
            foreach(GameObject i in items) {
                if(! (i.GetComponent<Item>().IsOwned())){
                    i.SetActive(true);
                }
            }
            storeActive = true;
        }
    }

    private static void SaveJsonData(StoreController sc)
    {
        SaveData sd = new SaveData();
        foreach(GameObject i in sc.items) {
            i.GetComponent<Item>().PopulateSaveData(sd);
        }
        if(FileManager.WriteToFile("ItemData.txt", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    private static void LoadJsonData(StoreController sc)
    {
        if(FileManager.LoadFromFile("ItemData.txt", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            foreach(GameObject i in sc.items) {
                i.GetComponent<Item>().LoadFromSaveData(sd);
            }
        }
    }


}
