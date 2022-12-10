using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour, ISaveable
{
    public TextMeshProUGUI CoinCount;
    private int currentScore;

    public static ScoreController Instance { get; private set; }
    // Start is called before the first frame update

    public int GetCurrentScore(){
        return currentScore;
    }

    private void Awake()
    {
        Instance = this;
        LoadJsonData(Instance);
        UpdateText();
    }

    public void SubtractCoin(int value)
    {
        currentScore -= value;
        SaveJsonData(Instance);
        UpdateText();
    }

    public void AddCoin()
    {
        currentScore += 1;
        SaveJsonData(Instance);
        UpdateText();
    }

    public void UpdateText()
    {
        CoinCount.text = currentScore.ToString();
    }

    private static void SaveJsonData(ScoreController sc)
    {
        SaveData sd = new SaveData();
        sc.PopulateSaveData(sd);
        if(FileManager.WriteToFile("SaveData.txt", sd.ToJson()))
        {
            Debug.Log("Save successful");
        }
    }

    public void PopulateSaveData(SaveData sd)
    {
        sd.coinCount = currentScore;
    }

    private static void LoadJsonData(ScoreController sc)
    {
        if(FileManager.LoadFromFile("SaveData.txt", out var json))
        {
            SaveData sd = new SaveData();
            sd.LoadFromJson(json);

            sc.LoadFromSaveData(sd);
        }
    }

    public void LoadFromSaveData(SaveData sd){
        currentScore = sd.coinCount;
    }


}
