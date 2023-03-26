using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class Room
{
    [SerializeField]
    public RoomAlignment alignment;
    
    [SerializeField]
    public int level;

    [SerializeField]
    public List<Door> doors = new List<Door>();
}

public enum RoomAlignment
{
    Generic, 
    Acrobatics_Dex,
    AnimalHandling_Wis,
    Arcana_Int,
    Athletics_Str,
    Deception_Cha,
    History_Int,
    Insight_Wis,
    Intimidation_Cha,
    Investigation_Int,
    Medicine_Wis,
    Nature_Int,
    Perception_Wis,
    Performance_Cha,
    Persuasion_Cha,
    Religion_Int,
    SleightOfHand_Dex,
    Stealth_Dex,
    Survival_Wis,
}