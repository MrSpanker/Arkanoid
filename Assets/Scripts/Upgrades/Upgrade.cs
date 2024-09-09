using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Arkanoid/New upgrade")]
public class Upgrade : ScriptableObject
{
    public UpgradeType Type;
    public Sprite View;
    public float ActionTime;

    public Upgrade Clone()
    {
        return (Upgrade)this.MemberwiseClone();
    }
}
