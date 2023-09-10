using UnityEngine;
using TMPro;

public class ItemInforPanel : MonoBehaviour
{
    public TMP_Text itemNameText;
    public TMP_Text itemStrengthText;
    public TMP_Text itemHealthText;
    public TMP_Text itemTypeText;
    public GameObject itemImage;

    public void ShowItemInfo(InventoryItem item)
    {
        itemNameText.text = item.itemName;
        itemStrengthText.text = "Strength: " + item.statModifier;
        itemHealthText.text = "Health: " + item.statModifier;
        itemTypeText.text = "Type: " + item.type;

        // Đặt hình ảnh của item vào itemImage (cần có hình ảnh của item để làm điều này)
        // Ví dụ:
        // itemImage.GetComponent<SpriteRenderer>().sprite = item.itemSprite;

        gameObject.SetActive(true);
    }

    public void HideItemInfo()
    {
        gameObject.SetActive(false);
    }
}
