using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeItemSpawner : MonoBehaviour
{
    [SerializeField] private List<Upgrade> _availableUpgrades;
    [SerializeField] private GameObject _lootTemplate;
    [SerializeField] private float _initialSpawnProbability = 0.1f; 
    [SerializeField] private float _probabilityChangeRate = 0.05f; 

    private float _currentSpawnProbability;

    private void Start()
    {
        _currentSpawnProbability = _initialSpawnProbability;
    }

    public void TrySpawnUpgrade(Vector2 position)
    {
        if (Random.value <= _currentSpawnProbability)
        {
            SpawnUpgrade(position);
            _currentSpawnProbability = _initialSpawnProbability;
        }
        else
        {
            _currentSpawnProbability = Mathf.Min(1.0f, _currentSpawnProbability + _probabilityChangeRate);
        }
    }

    private void SpawnUpgrade(Vector2 position)
    {
        Upgrade upgrade = _availableUpgrades[Random.Range(0, _availableUpgrades.Count)];
        GameObject upgradeObject = Instantiate(_lootTemplate, position, Quaternion.identity);

        LootComponent lootComponent = upgradeObject.GetComponent<LootComponent>();
        if (lootComponent != null)
        {
            lootComponent.Initialize(upgrade);
        }

        Debug.Log("Случайный лут заспавнился");
    }
}
