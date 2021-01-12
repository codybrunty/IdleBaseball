using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[System.Serializable]
public class Player {
    public enum Position { Catcher, First, Second, ShortStop, Third, Left, Center, Right, Pitcher }

    [Header("Player Information")]
    public string name;
    public int number;
    public Position position;

    [Header("Player Attributes")]
    public int contactLevel;
    public float contactSkillPoints;
    public int powerLevel;
    public float powerSkillPoints;
    public int fieldingLevel;
    public float fieldingSkillPoints;
    public int throwingLevel;
    public float throwingSkillPoints;
    public int runningLevel;
    public float runningSkillPoints;
    public int pitchingLevel;
    public float pitchingSkillPoints;

    [Header("Contact Idle Mechanics")]
    public float contactIdleBaseRate = 5f;
    public float contactIdleRate = 5f;
    public float contactIdleBaseCost = 50f;
    public float contactIdleCost = 50f;
    public float contactMultiplier = 1.07f;

    [Header("Power Idle Mechanics")]
    public float powerIdleBaseRate = 5f;
    public float powerIdleRate = 5f;
    public float powerIdleBaseCost = 50f;
    public float powerIdleCost = 50f;
    public float powerMultiplier = 1.07f;

    [Header("Fielding Idle Mechanics")]
    public float fieldingIdleBaseRate = 5f;
    public float fieldingIdleRate = 5f;
    public float fieldingIdleBaseCost = 50f;
    public float fieldingIdleCost = 50f;
    public float fieldingMultiplier = 1.07f;

    [Header("Fielding Idle Mechanics")]
    public float throwingIdleBaseRate = 5f;
    public float throwingIdleRate = 5f;
    public float throwingIdleBaseCost = 50f;
    public float throwingIdleCost = 50f;
    public float throwingMultiplier = 1.07f;


    [Header("Running Idle Mechanics")]
    public float runningIdleBaseRate = 5f;
    public float runningIdleRate = 5f;
    public float runningIdleBaseCost = 50f;
    public float runningIdleCost = 50f;
    public float runningMultiplier = 1.07f;


    [Header("Pitching Idle Mechanics")]
    public float pitchingIdleBaseRate = 5f;
    public float pitchingIdleRate = 5f;
    public float pitchingIdleBaseCost = 50f;
    public float pitchingIdleCost = 50f;
    public float pitchingMultiplier = 1.07f;


}
