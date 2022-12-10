using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{

    public static Inventory Instance { get; private set; }

    private Button inventoryButton;
    private List<GameObject> items = new List<GameObject>();
    private bool inventoryActive = false;

    private void Awake()
    {
        Instance = this;
        inventoryButton = transform.Find("InventoryButton").GetComponent<Button>();
        foreach(GameObject i in GameObject.FindGameObjectsWithTag("itemInventory")) {
             items.Add(i);
             i.SetActive(false);
        }
    }

    public void AddItem(Item item){
        foreach(GameObject i in items) {
            if(i.GetComponent<Item>().name == item.name){
                i.GetComponent<Item>().SetOwned(true);
            }
        }
        SaveJsonData(Instance);
        LoadJsonData(Instance);
    }

    public void Start ()
    {
        LoadJsonData(Instance);
        inventoryButton.onClick.AddListener(() => {
            OnInventoryButtonClick();
        });
    }

    public void OnInventoryButtonClick(){
        if(inventoryActive){
            Debug.Log("off");
            foreach(GameObject i in items) {
                i.SetActive(false);
            }
            inventoryActive = false;
        }
        else{
            Debug.Log("on");
            foreach(GameObject i in items) {
                if(i.GetComponent<Item>().IsOwned()){
                    Debug.Log(i.GetComponent<Item>().IsOwned());
                    i.SetActive(true);
                }
            }
            inventoryActive = true;
        }
    }

    private static void SaveJsonData(Inventory inv)
    {
        SaveData sd = new SaveData();
        foreach(GameObject i in inv.items) {
            i.GetComponent<Item>().PopulateSaveData(sd);
        }
        if(FileManager.WriteToFile("ItemData.txt", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    private static void LoadJsonData(Inventory inv)
    {
        if(FileManager.LoadFromFile("ItemData.txt", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            foreach(GameObject i in inv.items) {
                i.GetComponent<Item>().LoadFromSaveData(sd);
            }
        }
    }

}
