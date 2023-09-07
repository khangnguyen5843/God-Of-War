using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ItemType
    {
        Weapon,
        Armor,
        Helmet,
        Shoes
    }
public class Item : MonoBehaviour
{
    public string itemName;
    public ItemType typeItem;
    public int addStrength;
    public int statModifier;
}
