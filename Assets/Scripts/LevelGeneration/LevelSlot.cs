using System;
using UnityEngine;

[Serializable]
public class LevelSlot
{
    public BlockType BlockType;
    public Vector2Int Coordinates;

    // Ётот конструктор гарантирует что объект будет создан только при задании обоих параметров
    public LevelSlot(BlockType blockType, Vector2Int coordinates)
    {
        BlockType = blockType;
        Coordinates = coordinates;
    }
}