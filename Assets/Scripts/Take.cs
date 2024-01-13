using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Take : MonoBehaviour
{
    public GameObject texts;
    public GameObject Button_Take;

    public Sprite Talk;
    public Sprite Take_Spr;

    public static Collider2D other2;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Weapon" | other.tag == "Object" | other.name == "Radio")
        {
            texts.SetActive(true);
            Button_Take.SetActive(true);
            Button_Take.GetComponent<Image>().sprite = Take_Spr;
            Text a = texts.gameObject.GetComponent<Text>();
            a.text = other.name.ToString();

        }else if(other.tag == "People")
        {
            texts.SetActive(true);
            Button_Take.SetActive(true);
            Button_Take.GetComponent<Image>().sprite = Talk;
            Text a = texts.gameObject.GetComponent<Text>();
            a.text = other.name.ToString();
        }
        other2 = other;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Weapon" | other.tag == "Object" | other.name == "Radio" | other.tag == "People")
        {
            texts.SetActive(false);
            Button_Take.SetActive(false);
        }
    }
}
