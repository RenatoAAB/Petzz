using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PerguntasUI : MonoBehaviour
{

    public static PerguntasUI Instance { get; private set; }

    private TextMeshProUGUI textMeshPro;
    private Button simButton;
    private Button naoButton;

    private void Awake()
    {
        Instance = this;
        textMeshPro = transform.Find("Text").GetComponent<TextMeshProUGUI>();
        simButton = transform.Find("Sim").GetComponent<Button>();
        naoButton = transform.Find("Nao").GetComponent<Button>();

        HideQuestion();
    }

    public void ShowQuestion (string questionText, Action yesAction, Action noAction){
        gameObject.SetActive(true);
        textMeshPro.text = questionText;
        simButton.onClick.AddListener(() => {
            HideQuestion();
            yesAction();
        });
        naoButton.onClick.AddListener(() => {
            HideQuestion();
            noAction();
        });
    }

    public void HideQuestion(){
        gameObject.SetActive(false);
    }


}
