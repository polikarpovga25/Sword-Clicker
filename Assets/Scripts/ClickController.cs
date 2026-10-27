using UnityEngine;

public class ClickController : MonoBehaviour
{
    public Enemy targetEnemy;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null && hit.collider.gameObject == targetEnemy.gameObject)
            {
                targetEnemy.TakeDamage(GameData.Instance.SwordDamage);
            }
        }
    }
}