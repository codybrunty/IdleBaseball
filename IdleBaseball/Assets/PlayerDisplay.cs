using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerDisplay : MonoBehaviour{
    [Header("Player Information")]
    public int playerIndex;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI positionText;
    public TextMeshProUGUI numberText;
    [Header("Player Attributes Levels")]
    public TextMeshProUGUI ContactLevelText;
    public TextMeshProUGUI PowerLevelText;
    public TextMeshProUGUI FieldingLevelText;
    public TextMeshProUGUI ThrowingLevelText;
    public TextMeshProUGUI RunningLevelText;
    public TextMeshProUGUI PitchingLevelText;
    [Header("Player Attributes TrainingPoints")]
    public TextMeshProUGUI ContactSkillPointsText;
    public TextMeshProUGUI PowerSkillPointsText;
    public TextMeshProUGUI FieldingSkillPointsText;
    public TextMeshProUGUI ThrowingSkillPointsText;
    public TextMeshProUGUI RunningSkillPointsText;
    public TextMeshProUGUI PitchingSkillPointsText;
    [Header("Player Training Buttons")]
    public Button contactTrainingButton;
    public Button powerTrainingButton;
    public Button fieldingTrainingButton;
    public Button throwingTrainingButton;
    public Button runningTrainingButton;
    public Button pitchingTrainingButton;
    [Header("Player LevelUp Buttons")]
    public Button contactLevelUpButton;
    public Button powerLevelUpButton;
    public Button fieldingLevelUpButton;
    public Button throwingLevelUpButton;
    public Button runningLevelUpButton;
    public Button pitchingLevelUpButton;
    [Header("Player LevelUp Texts")]
    public TextMeshProUGUI contactLevelUpCostText;
    public TextMeshProUGUI powerLevelUpCostText;
    public TextMeshProUGUI fieldingLevelUpCostText;
    public TextMeshProUGUI throwingLevelUpCostText;
    public TextMeshProUGUI runningLevelUpCostText;
    public TextMeshProUGUI pitchingLevelUpCostText;
    //Private Booleans
    private bool isTraining = false;
    private bool trainContact;
    private bool trainPower;
    private bool trainFielding;
    private bool trainThrowing;
    private bool trainRunning;
    private bool trainPitching;
    //private timers
    private float delayTime = .1f;
    private float timer = 0f;

    #region Update Displays
    public void UpdateDisplay() {
        nameText.text = PlayersManager.instance.allPlayers[playerIndex].name;
        numberText.text = PlayersManager.instance.allPlayers[playerIndex].number.ToString();
        positionText.text = PlayersManager.instance.allPlayers[playerIndex].position.ToString();
        //player attribute levels
        ContactLevelText.text = PlayersManager.instance.allPlayers[playerIndex].contactLevel.ToString();
        PowerLevelText.text = PlayersManager.instance.allPlayers[playerIndex].powerLevel.ToString();
        FieldingLevelText.text = PlayersManager.instance.allPlayers[playerIndex].fieldingLevel.ToString();
        ThrowingLevelText.text = PlayersManager.instance.allPlayers[playerIndex].throwingLevel.ToString();
        RunningLevelText.text = PlayersManager.instance.allPlayers[playerIndex].runningLevel.ToString();
        PitchingLevelText.text = PlayersManager.instance.allPlayers[playerIndex].pitchingLevel.ToString();
        //player skill points
        ContactSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].contactSkillPoints.ToString("F2");
        PowerSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].powerSkillPoints.ToString("F2");
        FieldingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].fieldingSkillPoints.ToString("F2");
        ThrowingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].throwingSkillPoints.ToString("F2");
        RunningSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].runningSkillPoints.ToString("F2");
        PitchingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].pitchingSkillPoints.ToString("F2");
        //player level up costs
        contactLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].contactIdleCost.ToString("F2");
        powerLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].powerIdleCost.ToString("F2");
        fieldingLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].fieldingIdleCost.ToString("F2");
        throwingLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].throwingIdleCost.ToString("F2");
        runningLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].runningIdleCost.ToString("F2");
        pitchingLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].pitchingIdleCost.ToString("F2");
    }

    #endregion

    private void Update() {
        if (isTraining) {
            timer += Time.deltaTime;
            if (timer > delayTime) {
                timer = 0f;
                if (trainContact) {
                    AddContactSkills();
                }
                if (trainPower) {
                    AddPowerSkills();
                }
                if (trainFielding) {
                    AddFieldingSkills();
                }
                if (trainThrowing) {
                    AddThrowingSkills();
                }
                if (trainRunning) {
                    AddRunningSkills();
                }
                if (trainPitching) {
                    AddPitchingSkills();
                }
                
            }
        }
    }

    #region Attribute Add Skill Points
    private void AddContactSkills() {
        PlayersManager.instance.allPlayers[playerIndex].contactSkillPoints += (PlayersManager.instance.allPlayers[playerIndex].contactIdleRate * delayTime);
        ContactSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].contactSkillPoints.ToString("F2");
    }
    private void AddPowerSkills() {
        PlayersManager.instance.allPlayers[playerIndex].powerSkillPoints += (PlayersManager.instance.allPlayers[playerIndex].powerIdleRate * delayTime);
        PowerSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].powerSkillPoints.ToString("F2");
    }
    private void AddFieldingSkills() {
        PlayersManager.instance.allPlayers[playerIndex].fieldingSkillPoints += (PlayersManager.instance.allPlayers[playerIndex].fieldingIdleRate * delayTime);
        FieldingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].fieldingSkillPoints.ToString("F2");
    }
    private void AddThrowingSkills() {
        PlayersManager.instance.allPlayers[playerIndex].throwingSkillPoints += (PlayersManager.instance.allPlayers[playerIndex].throwingIdleRate * delayTime);
        ThrowingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].throwingSkillPoints.ToString("F2");
    }
    private void AddRunningSkills() {
        PlayersManager.instance.allPlayers[playerIndex].runningSkillPoints += (PlayersManager.instance.allPlayers[playerIndex].runningIdleRate * delayTime);
        RunningSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].runningSkillPoints.ToString("F2");
    }
    private void AddPitchingSkills() {
        PlayersManager.instance.allPlayers[playerIndex].pitchingSkillPoints += (PlayersManager.instance.allPlayers[playerIndex].pitchingIdleRate * delayTime);
        PitchingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].pitchingSkillPoints.ToString("F2");
    }
    #endregion

    #region Attribute Training On Clicks
    public void vContactTrainingButtonOnClick() {
        if (trainContact) {
            return;
        }

        timer = 0f;
        isTraining = true;

        //all attributes
        trainContact = true;
        trainPower = false;
        trainFielding = false;
        trainThrowing = false;
        trainRunning = false;
        trainPitching = false;
    }
    public void vPowerTrainingButtonOnClick() {
        if (trainPower) {
            return;
        }

        timer = 0f;
        isTraining = true;

        //all attributes
        trainContact = false;
        trainPower = true;
        trainFielding = false;
        trainThrowing = false;
        trainRunning = false;
        trainPitching = false;
    }
    public void vFieldingTrainingButtonOnClick() {
        if (trainFielding) {
            return;
        }
        timer = 0f;
        isTraining = true;

        //all attributes
        trainContact = false;
        trainPower = false;
        trainFielding = true;
        trainThrowing = false;
        trainRunning = false;
        trainPitching = false;
    }
    public void vThrowingTrainingButtonOnClick() {
        if (trainThrowing) {
            return;
        }
        timer = 0f;
        isTraining = true;

        //all attributes
        trainContact = false;
        trainPower = false;
        trainFielding = false;
        trainThrowing = true;
        trainRunning = false;
        trainPitching = false;
    }
    public void vRunningTrainingButtonOnClick() {
        if (trainRunning) {
            return;
        }
        timer = 0f;
        isTraining = true;

        //all attributes
        trainContact = false;
        trainPower = false;
        trainFielding = false;
        trainThrowing = false;
        trainRunning = true;
        trainPitching = false;
    }
    public void vPitchingTrainingButtonOnClick() {
        if (trainPitching) {
            return;
        }
        timer = 0f;
        isTraining = true;

        //all attributes
        trainContact = false;
        trainPower = false;
        trainFielding = false;
        trainThrowing = false;
        trainRunning = false;
        trainPitching = true;
    }
    #endregion

    #region Attribute LevelUp On Clicks
    
    public void vContactLevelUpOnClick() {
        if (PlayersManager.instance.allPlayers[playerIndex].contactSkillPoints < PlayersManager.instance.allPlayers[playerIndex].contactIdleCost) {
            return;
        }

        //skills points
        PlayersManager.instance.allPlayers[playerIndex].contactSkillPoints -= PlayersManager.instance.allPlayers[playerIndex].contactIdleCost;
        //rate
        PlayersManager.instance.allPlayers[playerIndex].contactIdleRate += PlayersManager.instance.allPlayers[playerIndex].contactIdleBaseRate;
        //level
        PlayersManager.instance.allPlayers[playerIndex].contactLevel++;
        //cost
        PlayersManager.instance.allPlayers[playerIndex].contactIdleCost = PlayersManager.instance.allPlayers[playerIndex].contactIdleBaseCost* Mathf.Pow(PlayersManager.instance.allPlayers[playerIndex].contactMultiplier, PlayersManager.instance.allPlayers[playerIndex].contactLevel);

        //text displays
        ContactSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].contactSkillPoints.ToString("F2");
        ContactLevelText.text = PlayersManager.instance.allPlayers[playerIndex].contactLevel.ToString();
        contactLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].contactIdleCost.ToString("F2");
    }
    public void vPowerLevelUpOnClick() {
        if (PlayersManager.instance.allPlayers[playerIndex].powerSkillPoints < PlayersManager.instance.allPlayers[playerIndex].powerIdleCost) {
            return;
        }

        //skills points
        PlayersManager.instance.allPlayers[playerIndex].powerSkillPoints -= PlayersManager.instance.allPlayers[playerIndex].powerIdleCost;
        //rate
        PlayersManager.instance.allPlayers[playerIndex].powerIdleRate += PlayersManager.instance.allPlayers[playerIndex].powerIdleBaseRate;
        //level
        PlayersManager.instance.allPlayers[playerIndex].powerLevel++;
        //cost
        PlayersManager.instance.allPlayers[playerIndex].powerIdleCost = PlayersManager.instance.allPlayers[playerIndex].powerIdleBaseCost * Mathf.Pow(PlayersManager.instance.allPlayers[playerIndex].powerMultiplier, PlayersManager.instance.allPlayers[playerIndex].powerLevel);

        //text displays
        PowerSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].powerSkillPoints.ToString("F2");
        PowerLevelText.text = PlayersManager.instance.allPlayers[playerIndex].powerLevel.ToString();
        powerLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].powerIdleCost.ToString("F2");
    }

    public void vFieldingLevelUpOnClick() {
        if (PlayersManager.instance.allPlayers[playerIndex].fieldingSkillPoints < PlayersManager.instance.allPlayers[playerIndex].fieldingIdleCost) {
            return;
        }

        //skills points
        PlayersManager.instance.allPlayers[playerIndex].fieldingSkillPoints -= PlayersManager.instance.allPlayers[playerIndex].fieldingIdleCost;
        //rate
        PlayersManager.instance.allPlayers[playerIndex].fieldingIdleRate += PlayersManager.instance.allPlayers[playerIndex].fieldingIdleBaseRate;
        //level
        PlayersManager.instance.allPlayers[playerIndex].fieldingLevel++;
        //cost
        PlayersManager.instance.allPlayers[playerIndex].fieldingIdleCost = PlayersManager.instance.allPlayers[playerIndex].fieldingIdleBaseCost * Mathf.Pow(PlayersManager.instance.allPlayers[playerIndex].fieldingMultiplier, PlayersManager.instance.allPlayers[playerIndex].fieldingLevel);

        //text displays
        FieldingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].fieldingSkillPoints.ToString("F2");
        FieldingLevelText.text = PlayersManager.instance.allPlayers[playerIndex].fieldingLevel.ToString();
        fieldingLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].fieldingIdleCost.ToString("F2");
    }

    public void vThrowingLevelUpOnClick() {
        if (PlayersManager.instance.allPlayers[playerIndex].throwingSkillPoints < PlayersManager.instance.allPlayers[playerIndex].throwingIdleCost) {
            return;
        }

        //skills points
        PlayersManager.instance.allPlayers[playerIndex].throwingSkillPoints -= PlayersManager.instance.allPlayers[playerIndex].throwingIdleCost;
        //rate
        PlayersManager.instance.allPlayers[playerIndex].throwingIdleRate += PlayersManager.instance.allPlayers[playerIndex].throwingIdleBaseRate;
        //level
        PlayersManager.instance.allPlayers[playerIndex].throwingLevel++;
        //cost
        PlayersManager.instance.allPlayers[playerIndex].throwingIdleCost = PlayersManager.instance.allPlayers[playerIndex].throwingIdleBaseCost * Mathf.Pow(PlayersManager.instance.allPlayers[playerIndex].throwingMultiplier, PlayersManager.instance.allPlayers[playerIndex].throwingLevel);

        //text displays
        ThrowingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].throwingSkillPoints.ToString("F2");
        ThrowingLevelText.text = PlayersManager.instance.allPlayers[playerIndex].throwingLevel.ToString();
        throwingLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].throwingIdleCost.ToString("F2");
    }

    public void vRunningLevelUpOnClick() {
        if (PlayersManager.instance.allPlayers[playerIndex].runningSkillPoints < PlayersManager.instance.allPlayers[playerIndex].runningIdleCost) {
            return;
        }

        //skills points
        PlayersManager.instance.allPlayers[playerIndex].runningSkillPoints -= PlayersManager.instance.allPlayers[playerIndex].runningIdleCost;
        //rate
        PlayersManager.instance.allPlayers[playerIndex].runningIdleRate += PlayersManager.instance.allPlayers[playerIndex].runningIdleBaseRate;
        //level
        PlayersManager.instance.allPlayers[playerIndex].runningLevel++;
        //cost
        PlayersManager.instance.allPlayers[playerIndex].runningIdleCost = PlayersManager.instance.allPlayers[playerIndex].runningIdleBaseCost * Mathf.Pow(PlayersManager.instance.allPlayers[playerIndex].runningMultiplier, PlayersManager.instance.allPlayers[playerIndex].runningLevel);

        //text displays
        RunningSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].runningSkillPoints.ToString("F2");
        RunningLevelText.text = PlayersManager.instance.allPlayers[playerIndex].runningLevel.ToString();
        runningLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].runningIdleCost.ToString("F2");
    }
    public void vPitchingLevelUpOnClick() {
        if (PlayersManager.instance.allPlayers[playerIndex].pitchingSkillPoints < PlayersManager.instance.allPlayers[playerIndex].pitchingIdleCost) {
            return;
        }

        //skills points
        PlayersManager.instance.allPlayers[playerIndex].pitchingSkillPoints -= PlayersManager.instance.allPlayers[playerIndex].pitchingIdleCost;
        //rate
        PlayersManager.instance.allPlayers[playerIndex].pitchingIdleRate += PlayersManager.instance.allPlayers[playerIndex].pitchingIdleBaseRate;
        //level
        PlayersManager.instance.allPlayers[playerIndex].pitchingLevel++;
        //cost
        PlayersManager.instance.allPlayers[playerIndex].pitchingIdleCost = PlayersManager.instance.allPlayers[playerIndex].pitchingIdleBaseCost * Mathf.Pow(PlayersManager.instance.allPlayers[playerIndex].pitchingMultiplier, PlayersManager.instance.allPlayers[playerIndex].pitchingLevel);

        //text displays
        PitchingSkillPointsText.text = PlayersManager.instance.allPlayers[playerIndex].pitchingSkillPoints.ToString("F2");
        PitchingLevelText.text = PlayersManager.instance.allPlayers[playerIndex].pitchingLevel.ToString();
        pitchingLevelUpCostText.text = "Level Up\n" + PlayersManager.instance.allPlayers[playerIndex].pitchingIdleCost.ToString("F2");
    }
    #endregion
}
