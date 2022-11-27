using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreController : MonoBehaviour
{

    private Button storeButton;
    private GameObject item;
    private bool storeActive = false;

    private void Awake()
    {
        storeButton = transform.Find("LojaButton").GetComponent<Button>();
        item = transform.Find("LojaOptions").gameObject;
        item.SetActive(false);

    }

    public void Start ()
    {
        storeButton.onClick.AddListener(() => {
            OnStoreButtonClick();
        });
    }

    public void OnStoreButtonClick(){
        if(storeActive){
            item.SetActive(false);
            storeActive = false;
        }
        else{
            item.SetActive(true);
            storeActive = true;
        }
    }


}
