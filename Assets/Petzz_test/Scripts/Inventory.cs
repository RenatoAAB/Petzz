using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Inventory : MonoBehaviour
{
    private Button inventoryButton;
    private GameObject item;
    private GameObject specificItem;
    private bool inventoryActive = false;

    private void Awake()
    {
        inventoryButton = transform.Find("InventoryButton").GetComponent<Button>();
        item = transform.Find("InventoryOptions").gameObject;
        specificItem = GameObject.FindGameObjectWithTag("boughtItem");
        specificItem.SetActive(false);
        item.SetActive(false);

    }

    public void Activateitem(){
        specificItem.SetActive(true);
    }

    public void Start ()
    {
        inventoryButton.onClick.AddListener(() => {
            OnInventoryButtonClick();
        });
    }

    public void OnInventoryButtonClick(){
        if(inventoryActive){
            item.SetActive(false);
            inventoryActive = false;
        }
        else{
            item.SetActive(true);
            inventoryActive = true;
        }
    }
}
