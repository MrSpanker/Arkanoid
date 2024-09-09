using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    [SerializeField] private PlatformResizer _platformResizer;

    private List<Upgrade> _upgrades = new();

    private void Update()
    {
        foreach (Upgrade upgrade in _upgrades)
        {
            upgrade.ActionTime -= Time.deltaTime;
            if (upgrade.ActionTime < 0)
            {
                RemoveUpgrade(upgrade);
            }
        }
    }

    public void AddUpgrade(Upgrade upgrade)
    {
        ActivateUpgrade(upgrade.Type);
        _upgrades.Add(upgrade);
    }

    private void RemoveUpgrade(Upgrade upgrade)
    {
        DeactivateUpgrade(upgrade.Type);
        _upgrades.Remove(upgrade);
    }

    private void ActivateUpgrade(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.Expansion:
                _platformResizer.ResizePlatformX(1.5f);
                break;

            default:
                Debug.LogError("Не назначен тип улучшения");
                break;
        }
    }

    private void DeactivateUpgrade(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.Expansion:
                _platformResizer.ResetToInitialScale();
                break;

            default:
                Debug.LogError("Не назначен тип улучшения");
                break;
        }
    }
}