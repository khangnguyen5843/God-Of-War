using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    public ItemType type;
    public string itemName;
    public int statModifier;

    public bool isEquipped = false;
    private Button button;

    private void Start()
    {
        // Kiểm tra vị trí ban đầu của item và thiết lập trạng thái isEquipped dựa trên đó
        if (transform.parent == InventoryManager.Instance.weaponPanel.transform
            || transform.parent == InventoryManager.Instance.armorPanel.transform
            || transform.parent == InventoryManager.Instance.helmetPanel.transform
            || transform.parent == InventoryManager.Instance.shoesPanel.transform)
        {
            isEquipped = true;
        }
        else
        {
            isEquipped = false;
        }

        // Tìm Button component trong item
        button = GetComponent<Button>();

        // Đăng ký sự kiện Click cho Button
        if (button != null)
        {
            button.onClick.AddListener(OnClick);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Do nothing when clicking with a pointer; handle click in the Button's OnClick event instead
    }

    public void OnClick()
    {
        // Xử lý sự kiện khi người chơi nhấn vào item
        ToggleItem();
    }

    public void ToggleItem()
    {
        switch (type)
        {
            case ItemType.Weapon:
                ToggleEquipment(InventoryManager.Instance.weaponPanel, ItemType.Weapon);
                break;
            case ItemType.Armor:
                ToggleEquipment(InventoryManager.Instance.armorPanel, ItemType.Armor);
                break;
            case ItemType.Helmet:
                ToggleEquipment(InventoryManager.Instance.helmetPanel, ItemType.Helmet);
                break;
            case ItemType.Shoes:
                ToggleEquipment(InventoryManager.Instance.shoesPanel, ItemType.Shoes);
                break;
            default:
                // Xử lý một loại item không xác định (nếu cần)
                break;
        }
    }

    private void ToggleEquipment(GameObject equipmentPanel, ItemType equipmentType)
    {
        if (isEquipped)
        {
            // Nếu item đang được equip, thực hiện lệnh Unequip
            InventoryManager.Instance.UnequipItem(this);
            isEquipped = false;
        }
        else
        {
            // Nếu item không được equip, thực hiện lệnh Equip
            InventoryManager.Instance.EquipItem(this, equipmentType);
            isEquipped = true;
        }

        // Sau khi toggle, cập nhật trạng thái của Button (nếu cần)
        UpdateButton();
    }

    private void UpdateButton()
    {
        // Cập nhật trạng thái của Button dựa trên trạng thái isEquipped (nếu cần)
    }
}
