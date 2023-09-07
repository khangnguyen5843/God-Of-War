using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStat : MonoBehaviour
{
    public int strength = 10;
    public int health = 100;

    public TMP_Text strengthText;
    public TMP_Text healthText;

    private void Start()
    {
        // Liên kết Text UI với các giá trị stats
        strengthText.text = strength.ToString();
        healthText.text = health.ToString();
    }

    // Hàm này có thể được gọi khi bạn muốn cập nhật các giá trị stats
    public void UpdateStats()
    {
        strengthText.text = strength.ToString();
        healthText.text = health.ToString();
    }
}
