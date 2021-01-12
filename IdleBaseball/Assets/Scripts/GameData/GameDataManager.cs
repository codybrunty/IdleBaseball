using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameDataManager : MonoBehaviour{

    public static GameDataManager instance;
    public GameData gameData;

    #region singleton
    private void Awake() {
        //Debug.Log(Application.persistentDataPath);
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
            LoadGameData();
        }
        else {
            Destroy(gameObject);
        }
    }
    #endregion

    [ContextMenu("Load GameData")]
    public void LoadGameData() {
        string path = Application.persistentDataPath + "/GameData.json";
        if (File.Exists(path)) {
            string loadedJsonDataString = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(loadedJsonDataString);
        }
        else {
            SaveGameData();
        }
    }


    [ContextMenu("SaveGameData")]
    public void SaveGameData() {
        string path = Application.persistentDataPath + "/GameData.json";
        string jsonDataString = JsonUtility.ToJson(gameData, true);
        File.WriteAllText(path, jsonDataString);
    }


}



[System.Serializable]
public class GameData{
    public List<Player> allPlayers;
}
