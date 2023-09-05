using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementEnemySurvival : MonoBehaviour
{
    public Transform playerTransform;
    [SerializeField]
    private float enemySpeed = 1f;
    [SerializeField]
    private Animator enemyAnimator;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private int damage;

    [SerializeField] private GameObject xpPrefab;

    void SetEnemyDeath(bool isDead)
    {
        enemyAnimator.SetBool("IsDead", isDead);
    }

    void Start()
    {
        playerTransform = MovementPlayerSurvival.playerObj.transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        currentHealth = maxHealth; // Khởi đầu máu
        UpdateHealthBar(); // Cập nhật thanh máu khi khởi đầu
    }
    void Update()
    {
        Vector3 EP = playerTransform.position - transform.position;
        EP.Normalize();
        if (EP.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        enemyAnimator.SetFloat("Speed", EP.magnitude);
        transform.Translate(EP * enemySpeed * Time.deltaTime);
        // Điều kiện xử lý máu
        /*if (currentHealth <= 0)
        {
            SetEnemyDeath(true);
        }*/
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            // Xử lý khi enemy bị tiêu diệt
            // Ví dụ: gọi hàm để enemy biến mất
            Destroy(gameObject);
            if (xpPrefab != null)
            {
                Instantiate(xpPrefab, transform.position, Quaternion.identity);
            }
        }
        UpdateHealthBar();
    }
    void UpdateHealthBar()
    {
        if (healthSlider != null)
        {
            // Tính toán giá trị dựa vào máu hiện tại và máu tối đa
            float healthPercentage = (float)currentHealth / maxHealth;
            healthSlider.value = healthPercentage;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MovementPlayerSurvival player = collision.GetComponent<MovementPlayerSurvival>();
            if (player != null)
            {
                player.TakeDamage(damage);
            }
        }
    }
}
