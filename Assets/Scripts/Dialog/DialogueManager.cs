using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

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
            EndDialogue();
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

    public void EndDialogue()
    {
        For_Button.isClick = false;
        boxAnim.SetBool("StartOpen", false);
    }
}
