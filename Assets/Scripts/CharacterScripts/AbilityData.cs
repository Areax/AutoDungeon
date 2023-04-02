using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newAbility", menuName = "ScriptableObjects/Ability", order = 1)]
public class AbilityData : ScriptableObject
{
    public string abilityName;
    public ActionEffect effect;
    public int cooldown;

    //  flags used for decision making
    public bool buff = false;
    public bool heal = false;
    public bool attack = false;
}
