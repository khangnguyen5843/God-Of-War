using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        // Đảm bảo bạn đã đọc CharacterStat từ PlayerPrefs khi khởi tạo scene Game
        LoadCharacterStat();
    }

    // Đọc CharacterStat từ PlayerPrefs
    private void LoadCharacterStat()
    {
        if (PlayerPrefs.HasKey("Strength") && PlayerPrefs.HasKey("Health"))
        {
            CharacterStat characterStat = FindObjectOfType<CharacterStat>();
            if (characterStat != null)
            {
                characterStat.strength = PlayerPrefs.GetInt("Strength");
                characterStat.health = PlayerPrefs.GetInt("Health");
                characterStat.UpdateStats();
            }
        }
    }
}
