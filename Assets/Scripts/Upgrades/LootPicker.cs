using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class LootPicker : MonoBehaviour
{
    [SerializeField] private PlayerUpgradeManager _upgradeManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out LootComponent loot))
        {
            _upgradeManager.AddUpgrade(loot.GetUpgrade());
            Debug.Log("�������� ���");
        }
        else
        {
            Debug.LogError("� ���� �� ���� ���������" + loot);
        }
    }
}
