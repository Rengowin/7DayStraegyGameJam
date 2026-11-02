using UnityEngine;

[System.Flags]
public enum UnitType
{
    None = 0,
    Tank = 1 << 0,
    Melee = 1 << 1,
    Range = 1 << 2,
    AoE = 1 << 3,
    Assassin = 1 << 4   
}
