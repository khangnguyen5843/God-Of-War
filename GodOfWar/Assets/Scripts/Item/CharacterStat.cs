using TMPro;
using UnityEngine;

public class CharacterStat : MonoBehaviour
{
    public int strength = 100;
    public int health = 1000;
    public TMP_Text strengthText;
    public TMP_Text healthText;

    // Tạo một Singleton cho CharacterStat
    public static CharacterStat Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Không hủy đối tượng khi chuyển scene
        }
        else
        {
            Destroy(gameObject); // Đảm bảo chỉ có một đối tượng CharacterStat tồn tại
        }
    }

    private void Start()
    {
        // Liên kết Text UI với các giá trị stats và tính toán sát thương ban đầu
        UpdateStats();
    }

    // Hàm này có thể được gọi khi bạn muốn cập nhật các giá trị stats
    public void UpdateStats()
    {
        strengthText.text = strength.ToString();
        healthText.text = health.ToString();
    }

    public int CalculateDamage()
    {
        return strength * 20 / 100;
    }

    public int CalculateHealth()
    {
        return health;
    }
}
