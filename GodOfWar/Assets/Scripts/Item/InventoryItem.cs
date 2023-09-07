using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public ItemType type;
    public string itemName;
    public int statModifier;

    private GameObject equipButtonGO;
    private Button equipButton;
    private GameObject unequipButtonGO;
    private Button unequipButton;

    private bool isEquiped;

    private void Awake()
    {
        equipButtonGO = transform.Find("Equip").gameObject;
        equipButton = equipButtonGO.GetComponent<Button>();
        equipButton.onClick.AddListener(EquipItem);

        unequipButtonGO = transform.Find("Unequip").gameObject;
        unequipButton = unequipButtonGO.GetComponent<Button>();
        unequipButton.onClick.AddListener(UnequipItem);

        HideButtons();
    }

    public void ShowButtons(bool isEquiped)
    {
        this.isEquiped = isEquiped;
        equipButtonGO.SetActive(!isEquiped);
        unequipButtonGO.SetActive(isEquiped);
    }

    public void HideButtons()
    {
        equipButtonGO.SetActive(false);
        unequipButtonGO.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Xử lý sự kiện khi người chơi nhấn vào item
        if (eventData.clickCount == 1) // Kiểm tra single click
        {
            SelectItem();
        }
    }

    private void EquipItem()
    {
        InventoryManager.Instance.EquipItem(this);
    }

    private void UnequipItem()
    {
        InventoryManager.Instance.UnequipItem(this);
    }

    private void SelectItem()
    {
        // Gọi khi người chơi single click vào item
        InventoryManager.Instance.SelectItem(this);
    }
}

