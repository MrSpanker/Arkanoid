using System;
using UnityEngine;

[Serializable]
public class LevelSlot
{
    public BlockType BlockType;
    public Vector2Int Coordinates;

    // ���� ����������� ����������� ��� ������ ����� ������ ������ ��� ������� ����� ����������
    public LevelSlot(BlockType blockType, Vector2Int coordinates)
    {
        BlockType = blockType;
        Coordinates = coordinates;
    }
}