using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public int maxHealth = 4;
    public int currentHealth;
    public DamageEffect damageEffect;
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Health: " + currentHealth);
        damageEffect.PlayEffect();
        if (currentHealth == 1)
        {
            damageEffect.StartLowHealthEffect();
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("GAME OVER");
        // TODO: reset game / reload scene
    }
}
