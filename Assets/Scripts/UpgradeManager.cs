using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public bool TryUpgradeDamage()
    {
        if (GameData.Instance.Gold >= GameData.Instance.UpgradeCost)
        {
            GameData.Instance.Gold -= GameData.Instance.UpgradeCost;
            GameData.Instance.SwordDamage += 1;
            GameData.Instance.UpgradeCost = Mathf.RoundToInt(GameData.Instance.UpgradeCost * 1.5f);
            return true;
        }
        return false;
    }
}