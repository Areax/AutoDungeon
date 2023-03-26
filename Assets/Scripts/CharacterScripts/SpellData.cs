using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSpell", menuName = "ScriptableObjects/Spell", order = 1)]
public class SpellData : ScriptableObject
{
    public string spellName;
    public ActionEffect effect;
    public int cooldown;
}
