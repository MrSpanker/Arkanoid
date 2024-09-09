#if UNITY_EDITOR
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        LevelData levelData = (LevelData)target;

        AddLevelDetails(levelData);
        DisplayLevelSlotsEditor(levelData);
        AddButtonReset(levelData);
        AddButtonUpdate(levelData);
    }

    private void AddLevelDetails(LevelData levelData)
    {
        levelData.Rows = EditorGUILayout.IntSlider("Rows: ", levelData.Rows, 1, 10);
        serializedObject.ApplyModifiedProperties();
    }

    private void DisplayLevelSlotsEditor(LevelData levelData)
    {
        EditorGUILayout.LabelField("Block per position:");

        for (int x = 0; x < levelData.Rows; x++)
        {
            GUILayout.BeginHorizontal();

            for (int y = 0; y < levelData.Columns; y++)
            {
                LevelSlot slot = FindLevelSlot(levelData.Slots, x, y);
                slot.BlockType = (BlockType)EditorGUILayout.EnumPopup(slot.BlockType);
            }

            GUILayout.EndHorizontal();
        }
    }

    private LevelSlot FindLevelSlot(List<LevelSlot> slots, int x, int y)
    {
        LevelSlot slot = slots.Find(i => i.Coordinates.x == x && i.Coordinates.y == y);

        if (slot == null)
        {
            slot = new LevelSlot(BlockType.None, new Vector2Int(x, y));
            slots.Add(slot);
        }

        return slot;
    }

    private void AddButtonReset(LevelData levelData)
    {
        if (GUILayout.Button("Reset"))
        {
            Undo.RecordObject(levelData, "Reset Level Slots");
            ResetSlots(levelData);
        }
    }

    private void AddButtonUpdate(LevelData levelData)
    {
        if (GUILayout.Button("Update"))
        {
            Undo.RecordObject(levelData, "Update Level Data");
            EditorUtility.SetDirty(levelData);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
    }

    private void ResetSlots(LevelData levelData)
    {
        levelData.Slots.Clear();

        for (int x = 0; x < levelData.Rows; x++)
        {
            for (int y = 0; y < levelData.Columns; y++)
            {
                LevelSlot levelSlot = new LevelSlot(BlockType.None, new Vector2Int(x, y));
                levelData.Slots.Add(levelSlot);
            }
        }
    }
}
#endif