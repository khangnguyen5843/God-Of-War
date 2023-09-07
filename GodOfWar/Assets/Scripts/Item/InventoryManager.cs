using UnityEngine;
using System.Collections.Generic;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    public List<InventoryItem> inventoryItems = new List<InventoryItem>();
    public GameObject weaponPanel;
    public GameObject armorPanel;
    public GameObject helmetPanel;
    public GameObject shoesPanel;

    private InventoryItem selectedItem;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void EquipItem(InventoryItem item)
    {
        switch (item.type)
        {
            case ItemType.Weapon:
                weaponPanel.GetComponent<ItemSlot>().EquipWeapon(item);
                break;
            case ItemType.Armor:
                /*armorPanel.GetComponent<ArmorSlot>().EquipArmor(item);*/
                break;
            case ItemType.Helmet:
                /*helmetPanel.GetComponent<HelmetSlot>().EquipHelmet(item);*/
                break;
            case ItemType.Shoes:
                /*shoesPanel.GetComponent<ShoeSlot>().EquipShoes(item);*/
                break;
            default:
                break;
        }

        inventoryItems.Remove(item);
    }

    public void UnequipItem(InventoryItem item)
    {
        inventoryItems.Add(item);

        switch (item.type)
        {
            case ItemType.Weapon:
                weaponPanel.GetComponent<ItemSlot>().UnequipWeapon();
                break;
            case ItemType.Armor:
                /*armorPanel.GetComponent<ArmorSlot>().UnequipArmor();*/
                break;
            case ItemType.Helmet:
                /*helmetPanel.GetComponent<HelmetSlot>().UnequipHelmet();*/
                break;
            case ItemType.Shoes:
                /*shoesPanel.GetComponent<ShoeSlot>().UnequipShoes();*/
                break;
            default:
                break;
        }
    }

    public void SelectItem(InventoryItem item)
    {
        selectedItem = item;
        item.ShowButtons();
    }
}
