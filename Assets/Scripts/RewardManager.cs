using UnityEngine;

public class RewardManager : MonoBehaviour
{
    public Enemy enemy;

    private void OnEnable()
    {
        if (enemy != null) enemy.OnEnemyDefeated += HandleEnemyDefeated;
    }

    private void OnDisable()
    {
        if (enemy != null) enemy.OnEnemyDefeated -= HandleEnemyDefeated;
    }

    private void HandleEnemyDefeated()
    {
        int goldReward = Mathf.RoundToInt(5 * Mathf.Pow(1.1f, GameData.Instance.PlayerLevel - 1));
        int expReward = 2;

        GameData.Instance.Gold += goldReward;
        GameData.Instance.Experience += expReward;

        CheckLevelUp();
    }

    private void CheckLevelUp()
    {
        int requiredExp = GameData.Instance.PlayerLevel * 10;
        if (GameData.Instance.Experience >= requiredExp)
        {
            GameData.Instance.Experience -= requiredExp;
            GameData.Instance.PlayerLevel++;
        }
    }
}