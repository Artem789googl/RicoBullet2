using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]
public class Item : ScriptableObject
{
    public int id;
    public string ItemName;
    public int Damage;
    public int MaxCartridges;
    public int HowToReplace;
    public float fireRateItem;

    public int x;
    public int y;
    [TextArea(3, 10)]
    public string Diraction;
    public GameObject BodyWGun;
    public Sprite icon;

    public WeaponType WT;
    public WeapT weapt;
    public TypeCatridges ValueCartridges;
    public ItemType Type;

    public enum ItemType { 
        Weapon,
        Object
    }

    public enum WeaponType
    {
        None,
        Easy,
        Hard
    }

    public enum WeapT
    {
        None,
        Weapon,
        Weapon_Sa
    }

    public enum TypeCatridges
    {
        None,
        Gun,
        FustGun,
        ShutGun
    }
}
