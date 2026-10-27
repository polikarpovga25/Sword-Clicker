using UnityEngine;
using UnityEngine.EventSystems;

public class WeakPoint : MonoBehaviour, IPointerDownHandler
{
    private Enemy enemy;

    public void Initialize(Enemy targetEnemy)
    {
        enemy = targetEnemy;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (enemy != null)
        {
            enemy.TakeCritDamage();
            gameObject.SetActive(false);
        }
    }
}