using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public int Gold { get; set; } = 0;
    public int Experience { get; set; } = 0;
    public int PlayerLevel { get; set; } = 1;
    public int SwordDamage { get; set; } = 1;
    public int UpgradeCost { get; set; } = 10;
    public float CritMultiplier { get; set; } = 2.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}