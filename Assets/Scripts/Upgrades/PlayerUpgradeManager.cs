using System.Collections.Generic;
using UnityEngine;

public class PlayerUpgradeManager : MonoBehaviour
{
    [SerializeField] private PlatformResizer _platformResizer;

    public List<Upgrade> _upgrades = new();

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
        // Проверка на наличие улучшения того же типа
        Upgrade existingUpgrade = _upgrades.Find(u => u.Type == upgrade.Type);

        if (existingUpgrade != null)
        {
            existingUpgrade.ActionTime = upgrade.ActionTime;
            Debug.Log("Улучшение уже активно, Обновил время действия");
        }
        else
        {
            Upgrade upgradeClone = upgrade.Clone();
            ActivateUpgrade(upgradeClone.Type);
            _upgrades.Add(upgradeClone);
            Debug.Log("Добавил новое улучшение (копию)");
        }
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

        Debug.Log("Активаировал апгрейд");
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

        Debug.Log("Действие улучшения закончилось");
    }
}