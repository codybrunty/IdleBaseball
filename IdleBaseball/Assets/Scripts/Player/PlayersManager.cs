using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersManager : MonoBehaviour{


    public static PlayersManager instance;
    public List<Player> allPlayers;
    public GameObject playerDisplayPrefab;

    #region singleton
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else {
            Destroy(gameObject);
        }
    }
    #endregion

    #region Start    
    private void Start() {
        LoadAllPlayers();
        InstantiatePlayerDisplays();
    }
    #endregion

    #region Load Player Manager Data
    private void InstantiatePlayerDisplays() {
        for (int i = 0; i < allPlayers.Count; i++) {
            PlayerDisplay display = Instantiate(playerDisplayPrefab, playerDisplayPrefab.transform.parent).GetComponent<PlayerDisplay>();
            display.playerIndex = i;
            display.UpdateDisplay();
            display.gameObject.SetActive(true);
        }
    }

    private void LoadAllPlayers() {
        if (GameDataManager.instance.gameData.allPlayers.Count == 0) {
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.gameData.allPlayers.Add(new Player());
            GameDataManager.instance.SaveGameData();
        }
        allPlayers = GameDataManager.instance.gameData.allPlayers;
    }

    #endregion

    #region Saving Player Manager Data
    void OnApplicationQuit() {
        TransferPlayerManagerDataToGameData();
        GameDataManager.instance.SaveGameData();
    }

    private void TransferPlayerManagerDataToGameData() {
        GameDataManager.instance.gameData.allPlayers = allPlayers;
    }
    #endregion

}
