using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class ApplyItem : MonoBehaviour
{
    private Button verdeSkin;
    private GameObject bear;
    private bool isActive = false;
    public Material padrao;
    public Material itemColor;

    private void Awake()
    {
        verdeSkin = transform.Find("Verde").GetComponent<Button>();
        
    }

    public void Start ()
    {
        verdeSkin.onClick.AddListener(() => {
            OnItemButtonClick();
        });
    }

    public void OnItemButtonClick(){
        bear = AnimController.getInstantiatedBear();
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
}
