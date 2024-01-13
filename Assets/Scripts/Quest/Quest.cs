using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string nameQuest;
    public Type Questtype;
    [Header("Find")]
    public GameObject StartCoord;
    public GameObject EndCoord;
    [Header("Take")]
    public List<GameObject> WhatToTake;
    [Header("Kill")]
    public int HowManyKill;
    
    [Header("Dialogue")]
    public DialogueTrigger DialogueStart;
    public bool needDialogST = false;


    [Header("Award")]
    public Item Predmets;
    public bool needAward = false;
    public enum Type
    {
        Go,
        Take,
        Kill
    }
}

