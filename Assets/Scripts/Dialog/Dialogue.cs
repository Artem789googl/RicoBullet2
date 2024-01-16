using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class Dialogue
{
    public string[] name;
    [TextArea(3, 10)]
    public string[] sentenses;
    public Sprite[] sprites;


    [Header("CutScene")]
    public bool HaveCutScene = false;
    public bool NextCutScene = false;
    public string KeyCutscene;
    public bool needMusic = false;
    public PlayableDirector director;
    public GameObject[] objectsToKeepActive;
    public AudioSource SetFight;
    public AudioClip FightMusic;

    [Header("Fight")]
    public bool FightNeed;
}
