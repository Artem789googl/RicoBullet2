using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Dialogue dialogue1;

    public Text dialogueText;
    public Text nameText;
    public Image imgper;

    public Animator boxAnim;

    private Queue<string> namePer;
    private Queue<string> sentences;
    private Queue<Sprite> spritePer;


 
    private void Start()
    {
        
        namePer = new Queue<string>();
        sentences = new Queue<string>();
        spritePer = new Queue<Sprite>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        boxAnim.SetBool("StartOpen", true);

        dialogue1 = dialogue;
        
        namePer.Clear();
        sentences.Clear();
        spritePer.Clear();

        foreach(string nameone in dialogue.name)
        {
            namePer.Enqueue(nameone);
        }
        foreach (string sentence in dialogue.sentenses)
        {
            sentences.Enqueue(sentence);
        }
        foreach (Sprite spriteone in dialogue.sprites)
        {
            spritePer.Enqueue(spriteone);
        }
        DisplayNextScene();
    }

    public void DisplayNextScene()
    {
        if(sentences.Count == 0 && namePer.Count == 0 && spritePer.Count == 0)
        {
            EndDialogue(dialogue1);
            return;
        }
        nameText.text = namePer.Dequeue();
        string sentence = sentences.Dequeue();
        imgper.sprite = spritePer.Dequeue();
        imgper.SetNativeSize();
        imgper.gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.85f, 0.85f, 0.85f);
        imgper.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(61f, 95f);
        imgper.gameObject.GetComponent<RectTransform>().rotation = Quaternion.Euler(0f, 0f, 2.97f);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    public IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue(Dialogue dialogue)
    {
        For_Button.isClick = false;
        boxAnim.SetBool("StartOpen", false);
        if (dialogue.director.state == PlayState.Playing)
        {
            if (dialogue.HaveCutScene)
            {
                dialogue.director.Stop();
                
            }
            else if (dialogue.NextCutScene)
            {
                dialogue.director.Stop();
                CutsceneManager.Instance.StartCutscene(dialogue.KeyCutscene);
            }
            if (dialogue.needMusic)
            {
                dialogue.SetFight.Stop();
                dialogue.SetFight.PlayOneShot(dialogue.FightMusic);
            }
            foreach (GameObject obj in dialogue.objectsToKeepActive)
            {
                obj.SetActive(true);
            }
        }
        if (dialogue.FightNeed)
        {
            FightManager.Instance.StartFight();
        }
    }
}
