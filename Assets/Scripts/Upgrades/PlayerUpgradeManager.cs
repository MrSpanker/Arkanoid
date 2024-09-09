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
        // �������� �� ������� ��������� ���� �� ����
        Upgrade existingUpgrade = _upgrades.Find(u => u.Type == upgrade.Type);

        if (existingUpgrade != null)
        {
            existingUpgrade.ActionTime = upgrade.ActionTime;
            Debug.Log("��������� ��� �������, ������� ����� ��������");
        }
        else
        {
            Upgrade upgradeClone = upgrade.Clone();
            ActivateUpgrade(upgradeClone.Type);
            _upgrades.Add(upgradeClone);
            Debug.Log("������� ����� ��������� (�����)");
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
                Debug.LogError("�� �������� ��� ���������");
                break;
        }

        Debug.Log("������������ �������");
    }

    private void DeactivateUpgrade(UpgradeType upgradeType)
    {
        switch (upgradeType)
        {
            case UpgradeType.Expansion:
                _platformResizer.ResetToInitialScale();
                break;

            default:
                Debug.LogError("�� �������� ��� ���������");
                break;
        }

        Debug.Log("�������� ��������� �����������");
    }
}