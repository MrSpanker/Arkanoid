using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private BlockManager _blockManager;
    [SerializeField] private List<Block> _blocks = new();

    private readonly float _horizontalPadding = 2.2f; // Отступ от левой стены
    private readonly float _verticalPadding = 1.5f; // Отступ от верхней стены

    private void Start()
    {
        GameProgress.LoadProgress();
        LevelData currentLevel = GameProgress.GetCurrentLevelData();

        if (currentLevel == null)
        {
            Debug.LogError("Текущий уровень не найден! Возможно, уровни закончились.");
            return;
        }

        Camera.main.aspect = 16.0f / 9.0f;

        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;

        Vector2 startPosition = new Vector2(-width / 2, height / 2);

        if (_blocks.Count > 0)
        {
            Vector2 blockSize = _blocks[0].Prefab.GetComponent<SpriteRenderer>().bounds.size;
            Initialize(startPosition, blockSize, currentLevel);
        }
        else
        {
            Debug.LogWarning("Список блоков пуст!");
        }
    }

    private void Initialize(Vector2 start, Vector2 blockSize, LevelData levelData)
    {
        foreach (LevelSlot slot in levelData.Slots)
        {
            Block block = _blocks.Find(item => item.Type == slot.BlockType);

            if (block == null)
                continue;

            float x = start.x + _horizontalPadding + (slot.Coordinates.y * blockSize.x);
            float y = start.y - _verticalPadding - (slot.Coordinates.x * blockSize.y);

            GameObject blockObject = Instantiate(block.Prefab, new(x, y), Quaternion.identity, _blockManager.transform);
            _blockManager.AddBlock(blockObject);
        }
    }
}
