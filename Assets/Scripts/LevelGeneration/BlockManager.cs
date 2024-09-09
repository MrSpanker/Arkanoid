using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BlockManager : MonoBehaviour
{
    [SerializeField] private UpgradeItemSpawner _upgradeItemSpawner;
    [SerializeField] private GameObject _winMenu;

    private List<GameObject> _blocks = new();

    public void AddBlock(GameObject block)
    {
        _blocks.Add(block);
        block.GetComponent<BreakableBlockComponent>().OnDestroyed += RemoveBlock;
    }

    private void RemoveBlock(GameObject block)
    {
        if (_blocks.Contains(block))
        {
            if (TryGetComponent(out BreakableBlockComponent breakableBlockComponent))
                breakableBlockComponent.OnDestroyed -= RemoveBlock;

            _upgradeItemSpawner.TrySpawnUpgrade(block.transform.position);
            GameProgress.AddScore();
            _blocks.Remove(block);

            if (_blocks.Count == 0)
            {
                _winMenu.SetActive(true);
            }
        }
    }
}