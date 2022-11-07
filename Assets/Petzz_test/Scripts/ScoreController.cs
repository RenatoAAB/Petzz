using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI CoinCount;
    private const string CoinKey = "Coin";
    private int currentScore;

    public static ScoreController Instance { get; private set; }
    // Start is called before the first frame update

    private void Awake()
    {
        Instance = this;
    }
    
    void Start()
    {
        LoadPrefs();
    }

    // Update is called once per frame
    void OnApplicationQuit()
    {
        SavePrefs();
    }

    public void SubtractCoin(int value)
    {
        currentScore -= value;
        UpdateText();
    }

    public void AddCoin()
    {
        currentScore += 1;
        UpdateText();
    }

    public void UpdateText()
    {
        CoinCount.text = currentScore.ToString();
    }

    public void SavePrefs()
    {
        PlayerPrefs.SetInt(CoinKey, currentScore);
        PlayerPrefs.Save();
    }

    public void LoadPrefs()
    {
        var score = PlayerPrefs.GetInt(CoinKey, 0);
        currentScore = score;
        UpdateText();
    }
}
