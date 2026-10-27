using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public event Action OnEnemyDefeated;

    public int maxHealth = 10;
    private int currentHealth;

    private void Start()
    {
        ResetEnemy();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        OnEnemyDefeated?.Invoke();
        ResetEnemy();
    }

    private void ResetEnemy()
    {
        maxHealth = Mathf.RoundToInt(10 * Mathf.Pow(1.15f, GameData.Instance.PlayerLevel - 1));
        currentHealth = maxHealth;
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}