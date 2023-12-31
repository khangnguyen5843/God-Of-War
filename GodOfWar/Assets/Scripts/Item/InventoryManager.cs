﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;

    [Header("List Item")]
    public List<InventoryItem> inventoryItems = new List<InventoryItem>();

    [Header("Panel Item")]
    public GameObject weaponPanel;
    public GameObject armorPanel;
    public GameObject helmetPanel;
    public GameObject shoesPanel;

    [Header("Stats Character")]
    public CharacterStat characterStat;

    private Dictionary<ItemType, GameObject> panelDictionary = new Dictionary<ItemType, GameObject>();
    private Dictionary<ItemType, List<InventoryItem>> panelItems = new Dictionary<ItemType, List<InventoryItem>>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        panelDictionary.Add(ItemType.Weapon, weaponPanel);
        panelDictionary.Add(ItemType.Armor, armorPanel);
        panelDictionary.Add(ItemType.Helmet, helmetPanel);
        panelDictionary.Add(ItemType.Shoes, shoesPanel);

        foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
        {
            panelItems[itemType] = new List<InventoryItem>();
        }
    }

    private void Start()
    {
    //LoadItemStatus();
    }


    //EQUIP ITEM
    public void EquipItem(InventoryItem item, ItemType panelType)
    {
        if (item.type != ItemType.Weapon && item.type != ItemType.Armor &&
            item.type != ItemType.Helmet && item.type != ItemType.Shoes)
        {
            return;
        }

        List<InventoryItem> itemsInPanel = panelItems[panelType];
        Transform content = InventoryUI.Instance.inventoryContent;

        // Kiểm tra xem có item trong slot không
        if (itemsInPanel.Count > 0)
        {
            // Nếu có, thực hiện lệnh Unequip trước
            InventoryItem oldItem = itemsInPanel[0];
            UnequipItem(oldItem);
        }

        // Di chuyển item từ inventory vào panel tương ứng
        inventoryItems.Remove(item);
        GameObject panel = panelDictionary[panelType];
        item.transform.SetParent(panel.transform);
        item.transform.position = panel.transform.position;

        if (characterStat != null)
        {
            if (item.type == ItemType.Weapon)
            {
                characterStat.strength += item.statModifier;
                characterStat.UpdateStats();
            }
            else
            {
                characterStat.health += item.statModifier;
                characterStat.UpdateStats();
            }
        }

        item.isEquipped = true;
        itemsInPanel.Add(item);
        SaveItemStatus(item, true); // Lưu trạng thái item

    }

    //Move ITEM to Inventory when unequip
    public void UnequipItem(InventoryItem item)
    {
        Debug.Log("Unequip");
        if (item.type != ItemType.Weapon && item.type != ItemType.Armor &&
            item.type != ItemType.Helmet && item.type != ItemType.Shoes)
        {
            return;
        }
        // Xác định vị trí content của InventoryUI
        Transform content = InventoryUI.Instance.inventoryContent;

        // Di chuyển item từ slot vũ khí vào content của InventoryUI
        inventoryItems.Add(item); // Thêm item vào inventory
        item.transform.SetParent(content); // Đặt item là con của content

        // Trừ đi thông số Strength của nhân vật
        if (characterStat != null)
        {
            if (item.type == ItemType.Weapon)
            {
                characterStat.strength -= item.statModifier;
                characterStat.UpdateStats();
            }
            else
            {
                characterStat.health -= item.statModifier;
                characterStat.UpdateStats();
            }
        }

        item.isEquipped = false;
        // Xóa item khỏi danh sách item trong panel tương ứng
        ItemType panelType = item.type;
        panelItems[panelType].Remove(item);
        SaveItemStatus(item, false);// trạng thái item
    }

    //UNEQUIP ITEM IN SLOT
    public void UnequipPanel(ItemType panelType)
    {
        List<InventoryItem> itemsInPanel = panelItems[panelType];

        foreach (InventoryItem item in itemsInPanel)
        {
            UnequipItem(item);
        }
    }

    //SWAP ITEM
    public void ReplaceWeapon(InventoryItem newWeapon)
    {
        UnequipPanel(ItemType.Weapon);
        EquipItem(newWeapon, ItemType.Weapon);
    }


    //Hover Item
    private void SaveItemStatus(InventoryItem item, bool isEquipped)
    {
        string key = "ItemStatus_" + item.itemName; // Sử dụng tên item làm key
        PlayerPrefs.SetInt(key, isEquipped ? 1 : 0); // Lưu 1 nếu đang equip, 0 nếu không
        PlayerPrefs.Save();
    }

    public void LoadItemStatus()
    {
        Debug.Log("Num of inventory items: " + inventoryItems.Count);
        InventoryItem[] temp = InventoryManager.Instance.inventoryItems.ToArray();
        for (int i = 0; i < temp.Length; ++i)
        {
            var item = temp[i];
            string key = "ItemStatus_" + item.itemName;
            if (PlayerPrefs.HasKey(key))
            {
                int status = PlayerPrefs.GetInt(key);
                item.isEquipped = status == 1; // Nếu status là 1 thì đang equip, ngược lại không
                if (item.isEquipped)
                {
                    Debug.Log("I :" + i);
                    // Thực hiện equip item vào panel tương ứng
                    InventoryManager.Instance.EquipItem(item, item.type);
                }
                else
                {
                    // Thực hiện đưa item vào inventory
                    InventoryManager.Instance.UnequipItem(item);
                }
                Debug.Log("Load IF");
            }
            Debug.Log("loadFor");
        }
    }
}
