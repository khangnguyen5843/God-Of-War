﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MovementPlayerSurvival : MonoBehaviour
{   
    //MoveMent
    public static GameObject playerObj;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private Animator animator;
    [SerializeField]
    UnityAction<bool> Dead;
    private SpriteRenderer spriteRenderer;

    private PlayerInputSurvival input;
    Vector3 movementDirection;
    //Health
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider healthSlider;
    //Exp
    [SerializeField] private Slider experienceSlider;
    [SerializeField] private int currentExperience = 0;
    [SerializeField] private int experienceToLevelUp = 100;
    [SerializeField] private int currentLevel = 1;
    [SerializeField] private TMP_Text levelText;
    // List chứa tất cả các button kỹ năng
    [SerializeField] private SkillPanelController skillManager;

    private CharacterStat characterStat;



    void SetAnimationDead(bool isDead)
    {
        animator.SetBool("DeathFront", isDead);    
    }
    private void Awake()
    {      
        playerObj = gameObject;
        input = GetComponent<PlayerInputSurvival>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        Dead += SetAnimationDead;
        //Health
        int health = CharacterStat.Instance.CalculateHealth();
        maxHealth = health;
        currentHealth = maxHealth;
        //
        UpdateHealthBar(); // Cập nhật thanh máu khi khởi đầu
        currentLevel = 1; // Đặt cấp độ ban đầu thành 1
        if (skillManager != null)
        {
            skillManager.ActivateSkillPanel(); // Mở bảng chọn kỹ năng khi bắt đầu cấp độ mới
        }
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel.ToString();
        }
    }

    void Update()
    {
        movementDirection.Set(input.horizontalInput, input.verticalInput, 0f);
        movementDirection.Normalize();
        animator.SetFloat("Speed", movementDirection.magnitude);
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);
        if(input.horizontalInput > 0) transform.localScale = new Vector3(1, 1, 1);
        if (input.horizontalInput < 0) transform.localScale = new Vector3(-1, 1, 1);
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            SetAnimationDead(true);
        }
         // Đảm bảo máu không bị âm   
        UpdateHealthBar(); // Cập nhật thanh máu
    }

    public void AddExperience(int amount)
    {
        currentExperience += amount;
        UpdateExperienceBar();

        // Kiểm tra nếu người chơi đủ kinh nghiệm để lên cấp
        if (currentExperience >= experienceToLevelUp)
        {
            LevelUp();
        }
    }

    void LevelUp()
    {
        Debug.Log("LEVEL UP");
        // Xử lý khi người chơi lên cấp, ví dụ: tăng stats, reset kinh nghiệm
        currentLevel++;
        currentExperience = 0;
        experienceToLevelUp = CalculateExperienceForNextLevel(); // Hàm tính toán kinh nghiệm cần cho cấp tiếp theo
        UpdateExperienceBar(); 
        if (levelText != null)
        {
            levelText.text = "Level: " + currentLevel.ToString();
        }
        // Hiển thị ngẫu nhiên 3 trong 4 button kỹ năng
        if (skillManager != null)
        {
            skillManager.ActivateSkillPanel();
        }
    }

    //SKILL

    public void CloseSkillPanel()
    {
        // Gọi hàm này khi nhân vật đã chọn xong kỹ năng
        
        if (skillManager != null)
        {
            skillManager.CloseSkillPanel();
        }
    }


    //EXP
    int CalculateExperienceForNextLevel()
    {

        return experienceToLevelUp + experienceToLevelUp * 20/100;
    }


    void UpdateExperienceBar()
    {
        if (experienceSlider != null)
        {
            // Tính toán giá trị dựa vào kinh nghiệm hiện tại và kinh nghiệm cần cho cấp tiếp theo
            float experiencePercentage = (float)currentExperience / experienceToLevelUp;
            experienceSlider.value = experiencePercentage;
        }
    }

    public void ChangeMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = Mathf.Min(currentHealth, maxHealth);
        UpdateHealthBar();
    }

    public void SetCharacterStat(CharacterStat healStat)
    {
        characterStat = healStat;
    }

    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            float healthPercentage = (float)currentHealth / maxHealth;
            healthSlider.value = healthPercentage;
        }
    }
}
