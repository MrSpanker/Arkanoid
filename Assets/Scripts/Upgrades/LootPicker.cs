using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LootPicker : MonoBehaviour
{
    [SerializeField] private PlayerUpgradeManager _upgradeManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (TryGetComponent(out LootComponent loot))
        {
            _upgradeManager.AddUpgrade(loot.GetUpgrade());
        }
        else
        {
            Debug.LogError("В луте не было улучшения");
        }
    }
}
