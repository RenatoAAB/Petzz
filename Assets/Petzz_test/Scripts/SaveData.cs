using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData : MonoBehaviour
{
    [System.Serializable]
    public struct itemData
    {
        public string name;
        public bool owned;
    }

    public int coinCount;
    public List<itemData> list_items = new List<itemData>();

    public string ToJson(){
        return JsonUtility.ToJson(this);
    }

    public void LoadFromJson(string a_Json){
        JsonUtility.FromJsonOverwrite(a_Json, this);
    }

}

public interface ISaveable
{
    void LoadFromSaveData(SaveData a_SaveData);
    void PopulateSaveData(SaveData a_SaveData);
}
