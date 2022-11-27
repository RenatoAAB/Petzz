using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class BuyItem : MonoBehaviour
{
    private Button verdeSkin;
    private ScoreController scoreController;
    public int price;
    private Inventory inventory;

    private void Awake()
    {
        verdeSkin = transform.Find("Verde").GetComponent<Button>();
        scoreController = GameObject.FindGameObjectWithTag("money").GetComponent<ScoreController>();
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
    }

    public void Start ()
    {
        verdeSkin.onClick.AddListener(() => {
            OnItemButtonClick();
        });
    }

    public void OnItemButtonClick(){
        var coinCount = scoreController.GetCurrentScore();
        if(coinCount >= price){
            //buy item
            scoreController.SubtractCoin(price);
            inventory.Activateitem();
        }
    }

}