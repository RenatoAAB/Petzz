using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class Item : MonoBehaviour, ISaveable
{
    public string name;
    public int price = 0;
    public Material padrao;
    public Material itemColor;

    private Inventory inventory;
    private ScoreController scoreController;
    private TextMeshProUGUI itemText;
    private Button button;
    private bool owned = false;
    private bool isActive;

    private void Awake()
    {
        scoreController = GameObject.FindGameObjectWithTag("money").GetComponent<ScoreController>();
        inventory = GameObject.FindGameObjectWithTag("inventory").GetComponent<Inventory>();
        button = this.GetComponent<Button>();
        if(gameObject.tag == "itemStore"){
            GameObject child = this.transform.GetChild(0).gameObject;
            if(child != null){
                itemText = child.GetComponent<TextMeshProUGUI>();
                itemText.text = price.ToString();
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "itemStore"){
            button.onClick.AddListener(() => {
                BuyItem();
            });
        }
        else{
            button.onClick.AddListener(() => {
                ApplyItem();
            });
        }
    }

    public bool IsOwned(){
        return owned;
    }

    public void SetOwned(bool bought){
        owned = bought;
    }

    public void ApplyItem(){
        Debug.Log("Apply item");
        GameObject bear = AnimController.getInstantiatedBear();
        if(bear != null)
        {//changeColor
            var body = GameObject.FindGameObjectWithTag("body");
            Renderer renderer = body.GetComponent<Renderer>();
            if(isActive){
                renderer.sharedMaterial = padrao;
                isActive = false;
            }
            else{
                renderer.sharedMaterial = itemColor;
                isActive = true;
            }
        }
    }

    public void BuyItem(){
        var coinCount = scoreController.GetCurrentScore();
        if(coinCount >= price){
            //buy item
            scoreController.SubtractCoin(price);
            inventory.AddItem(this);
            this.owned = true;
            gameObject.SetActive(false);
        }
    }

    public void PopulateSaveData(SaveData sd){
        SaveData.itemData itemData = new SaveData.itemData();
        itemData.name = name;
        itemData.owned = owned;
        sd.list_items.Add(itemData);
    }

    public void LoadFromSaveData(SaveData sd){
        Debug.Log(sd.list_items);
        foreach(SaveData.itemData itemData in sd.list_items)
        {
            if(itemData.name == name)
            {
                Debug.Log("FOUND");
                owned = itemData.owned;
                Debug.Log(owned);
                break;
            }
        }
    }


}
