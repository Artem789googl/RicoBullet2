using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Table_INV : MonoBehaviour
{
    public static Table_INV Instance;


    public Text Name_T;
    public Text Damage_T;
    public Text Dir_T;

    private void Awake()
    {
        Instance = this;
    }
    public void Dobav(string Name, int Damage, string Diraction)
    {
        Name_T.text = Name;
        Damage_T.text = Damage.ToString();
        Dir_T.text = Diraction;
    }

}
