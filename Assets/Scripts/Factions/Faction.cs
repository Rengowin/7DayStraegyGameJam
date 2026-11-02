using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class Faction : MonoBehaviour
{
    //is serialized for testing purposes
    [SerializeField]
    int gold = 0;
    [SerializeField]
    FactionEnum factionEnum;

    public int Gold => gold;
    public FactionEnum GetFactionEnum()
    {
        return factionEnum;
    }

    //buff list for the faction, buffs are applied to all units of the faction

}
