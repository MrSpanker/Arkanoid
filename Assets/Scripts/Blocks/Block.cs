using System;
using UnityEngine;

[Serializable]
public class Block
{
    public BlockType Type;
    public GameObject Prefab;
}

[Serializable]
public enum BlockType
{
    None,
    Weak,
    Medium,
    Strong
}