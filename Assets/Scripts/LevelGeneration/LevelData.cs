using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arkanoid/New Level")]
public class LevelData : ScriptableObject
{
    public List<LevelSlot> Slots = new List<LevelSlot>();
    public readonly int Columns = 8;
    public int Rows = 3;
}