using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPoint : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;

    public DamageEffect damageEffect;
    public GameObject loseMenuPrefab;
    public Collider2D tilemapCollider;

    public Image healthImage;
    public Sprite[] healthSprites;

    private bool isDead = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return;

        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Health: " + currentHealth);

        damageEffect.PlayEffect();

        UpdateHealthUI();

        if (currentHealth == 1)
        {
            damageEffect.StartLowHealthEffect();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthImage != null && healthSprites.Length > 0)
        {
            healthImage.sprite = healthSprites[currentHealth];
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");

        if (loseMenuPrefab != null)
        {
            Instantiate(loseMenuPrefab);
        }

        if (tilemapCollider != null)
        {
            tilemapCollider.enabled = false;
        }
    }
}