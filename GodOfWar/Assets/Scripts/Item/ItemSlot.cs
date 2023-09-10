using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private InventoryItem equippedItem;
    public CharacterStat characterStat; // Thêm tham chiếu đến CharacterStat script


    public void EquipItem(InventoryItem item)
    {
        if (equippedItem != null)
        {
            // Trả item hiện tại về lại inventory
            InventoryManager.Instance.UnequipItem(equippedItem);
        }

        equippedItem = item;

        switch (item.type)
        {
            case ItemType.Weapon:
                item.transform.SetParent(InventoryManager.Instance.weaponPanel.transform);
                break;
            case ItemType.Armor:
                item.transform.SetParent(InventoryManager.Instance.armorPanel.transform);
                break;
            case ItemType.Helmet:
                item.transform.SetParent(InventoryManager.Instance.helmetPanel.transform);
                break;
            case ItemType.Shoes:
                item.transform.SetParent(InventoryManager.Instance.shoesPanel.transform);
                break;
            default:
                // Xử lý một loại item không xác định (nếu cần)
                break;
        }

        item.transform.position = transform.position;
    }

    public void UnequipItem()
    {
        if (equippedItem != null)
        {
            // Trả item về lại inventory
            InventoryManager.Instance.UnequipItem(equippedItem);
            equippedItem = null;
        }
    }
}
