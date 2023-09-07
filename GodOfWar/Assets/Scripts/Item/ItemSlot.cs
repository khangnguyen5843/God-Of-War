using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    private InventoryItem equippedWeapon;
    public CharacterStat characterStat; // Thêm tham chiếu đến CharacterStat script

    public void EquipWeapon(InventoryItem weapon)
    {
        if (equippedWeapon != null)
        {
            // Trả vũ khí hiện tại về lại inventory
            InventoryManager.Instance.UnequipItem(equippedWeapon);
        }

        equippedWeapon = weapon;

        // Gắn vũ khí vào panel
        weapon.transform.SetParent(transform);
        weapon.transform.position = transform.position;

        // Cập nhật thông số Strength của nhân vật
        if (characterStat != null)
        {
            characterStat.strength += equippedWeapon.statModifier;
            characterStat.UpdateStats();
        }
    }

    public void UnequipWeapon()
    {
        if (equippedWeapon != null)
        {
            // Trả vũ khí về lại inventory
            InventoryManager.Instance.UnequipItem(equippedWeapon);

            // Trừ đi thông số Strength của nhân vật
            if (characterStat != null)
            {
                characterStat.strength -= equippedWeapon.statModifier;
                characterStat.UpdateStats();
            }

            equippedWeapon = null;
        }
    }
}
