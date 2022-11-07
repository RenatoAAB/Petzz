using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonControl : MonoBehaviour
{

    private Button playButton;
    private Button feedButton;

    private void Awake()
    {
        playButton = transform.Find("Play").GetComponent<Button>();
        feedButton = transform.Find("Feed").GetComponent<Button>();

    }

    public void Start ()
    {
        playButton.onClick.AddListener(() => {
            OnPlayButtonClick();
        });
        feedButton.onClick.AddListener(() => {
            OnFeedButtonClick();
        });
    }

    public void OnPlayButtonClick(){
        AnimController.OnPlayButtonClick();
        if(AnimController.IsBearInstantiated()){
            ScoreController.Instance.AddCoin();
        }
    }

    public void OnFeedButtonClick(){
        AnimController.OnFeedButtonClick();
        if(AnimController.IsBearInstantiated()){
            ScoreController.Instance.AddCoin();
        }
    }



}
