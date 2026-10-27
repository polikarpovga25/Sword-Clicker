using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class Enemy : MonoBehaviour, IPointerDownHandler
{
    public event Action OnEnemyDefeated;

    public GameObject weakPointPrefab;
    public RectTransform weakPointContainer;

    public int maxHealth = 10;
    private int currentHealth;
    private GameObject activeWeakPoint;

    private void Start()
    {
        if (weakPointContainer == null)
        {
            weakPointContainer = GetComponent<RectTransform>();
        }

        ResetEnemy();

        if (weakPointPrefab != null && weakPointContainer != null)
        {
            activeWeakPoint = Instantiate(weakPointPrefab, weakPointContainer);
            activeWeakPoint.GetComponent<WeakPoint>().Initialize(this);
            activeWeakPoint.SetActive(false);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TakeDamage(GameData.Instance.SwordDamage);
        SpawnWeakPoint();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void TakeCritDamage()
    {
        int critDamage = Mathf.RoundToInt(GameData.Instance.SwordDamage * GameData.Instance.CritMultiplier);
        TakeDamage(critDamage);
    }

    private void Die()
    {
        if (activeWeakPoint != null) activeWeakPoint.SetActive(false);
        OnEnemyDefeated?.Invoke();
        ResetEnemy();
    }

    private void ResetEnemy()
    {
        if (GameData.Instance != null)
        {
            maxHealth = Mathf.RoundToInt(10 * Mathf.Pow(1.15f, GameData.Instance.PlayerLevel - 1));
        }
        else
        {
            maxHealth = 10;
        }
        currentHealth = maxHealth;
    }

    private void SpawnWeakPoint()
    {
        if (activeWeakPoint == null) return;

        RectTransform rectTransform = GetComponent<RectTransform>();
        float width = rectTransform.rect.width / 2f;
        float height = rectTransform.rect.height / 2f;

        float randomX = UnityEngine.Random.Range(-width + 20f, width - 20f);
        float randomY = UnityEngine.Random.Range(-height + 20f, height - 20f);

        activeWeakPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(randomX, randomY);
        activeWeakPoint.SetActive(true);
    }

    public int GetCurrentHealth() => currentHealth;
    public int GetMaxHealth() => maxHealth;
}
