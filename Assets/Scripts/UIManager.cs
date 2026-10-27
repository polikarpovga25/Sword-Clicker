using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI damageText;
    public TextMeshProUGUI upgradeCostText;
    public TextMeshProUGUI enemyHealthText;
    
    public Enemy enemy;
    public UpgradeManager upgradeManager;
    public Button upgradeButton;

    private void Start()
    {
        if (upgradeButton != null) upgradeButton.onClick.AddListener(OnUpgradeClicked);
    }

    private void Update()
    {
        if (GameData.Instance != null)
        {
            goldText.text = "Золото: " + GameData.Instance.Gold;
            levelText.text = "Уровень: " + GameData.Instance.PlayerLevel;
            damageText.text = "Урон: " + GameData.Instance.SwordDamage;
            upgradeCostText.text = "Цена улучшения: " + GameData.Instance.UpgradeCost;
        }

        if (enemy != null)
        {
            enemyHealthText.text = "HP: " + enemy.GetCurrentHealth() + " / " + enemy.GetMaxHealth();
        }
    }

    private void OnUpgradeClicked()
    {
        upgradeManager.TryUpgradeDamage();
    }
}