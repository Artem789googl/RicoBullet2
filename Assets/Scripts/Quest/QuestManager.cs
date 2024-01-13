using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instanse;

    public Text TextQ;
    public Animator anim;
    public Quest[] quests;
    public bool b = false;
    int y = 0;
    int z = 0;
    float dist;

    int a;
    bool g = false;

    private string WhoSetTask;
    private void Awake()
    {
        Instanse = this;
    }

    public void isOn()
    {
        StartAnim();
        b = true;
    }

    public void StartAnim()
    {
        switch (quests[y].Questtype)
        {
            case Quest.Type.Go: TextQ.text = $"{quests[y].nameQuest} ({dist.ToString("F2")})"; break;
            case Quest.Type.Take: TextQ.text = $"{quests[y].nameQuest}({0}/{quests.Length})"; break;
            case Quest.Type.Kill: TextQ.text = $"{quests[y].nameQuest}"; break;
        }
        anim.SetTrigger("Play");
    }

    public void Start()
    {
        isOn();
    }

    private void Update()
    {
        if(b == true)
        {
            if(Quest.Type.Go == quests[y].Questtype)
            {
                
                quests[y].EndCoord.SetActive(true);
                dist = (quests[y].EndCoord.GetComponent<Transform>().transform.position - quests[y].StartCoord.GetComponent<Transform>().transform.position).magnitude;
                TextQ.text = $"{quests[y].nameQuest} ({dist.ToString("F2")})";
                if (For_Button.isClick == true && Take.other2.name == quests[y].EndCoord.transform.parent.name)
                {
                    if (quests[y].needDialogST == true)
                    {
                        quests[y].DialogueStart.TriggerDialogue();
                    }
                    WhoSetTask = quests[y].EndCoord.transform.parent.name;
                    For_Button.isClick = false;
                    quests[y].EndCoord.SetActive(false);
                    GetAwards();
                    y++;
                    
                    
                }
            } else if(Quest.Type.Take == quests[y].Questtype)
            {
                
                if(g == false)
                {
                    a = quests[y].WhatToTake.Count;
                    g = true;
                }
                
                TextQ.text = $"{quests[y].nameQuest}({z}/{a})";
                for (int i = 0; i < InventoryManager.Instance.Items.Count; i++)
                {
                    if(InventoryManager.Instance.Items[i] != null)
                    {
                        for (int j = 0; j < quests[y].WhatToTake.Count; j++)
                        {
                            if(InventoryManager.Instance.Items[i].id == quests[y].WhatToTake[j].GetComponent<ItemPickup>().Item.id)
                            {
                                z++;
                                quests[y].WhatToTake.RemoveAt(j);
                                
                            }
                        }
                    }
                }
                if (quests[y].needDialogST == true)
                {
                    if (For_Button.isClick && WhoSetTask == Take.other2.name)
                    {                        
                        quests[y].DialogueStart.TriggerDialogue();
                        For_Button.isClick = false;
                    }
                }
                TextQ.text = $"{quests[y].nameQuest}({z}/{a})";
                if (quests[y].WhatToTake.Count == 0)
                {
                    g = false;
                    GetAwards();
                    y++;
                    StartAnim();
                }
            }
            else if (Quest.Type.Kill == quests[y].Questtype)
            {
                //Потом будет код;
            }
        }
        if(y == quests.Length)
        {
            b = false;
        }
    }

    public void GetAwards()
    {
        if(quests[y].needAward == true)
        {
            if(quests[y].Predmets.Type == Item.ItemType.Weapon)
            {

                InventoryManager.Instance.Add(quests[y].Predmets);
                For_Button.Instance.GetText.gameObject.GetComponent<Text>().text = $"Get: {quests[y].Predmets.name}";
                For_Button.Instance.GetText.SetTrigger("Play");
            } 
            else
            {
                InventoryManager.Instance.Add2(quests[y].Predmets);
                For_Button.Instance.GetText.gameObject.GetComponent<Text>().text = $"Get: {quests[y].Predmets.name}";
                For_Button.Instance.GetText.SetTrigger("Play");
            }
        }
    }


}
