using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, Action
{
    public SpellData spellData;
    private int tickLastUsed = -1;

    public ActionEffect GetEffect(Stats playerStats)
    {
        return spellData.effect;
    }

    public string GetName()
    {
        return spellData.spellName;
    }

    public int GetNextUsableTick()
    {
        if (tickLastUsed < 0)
        {
            return 0;
        }

        return tickLastUsed + spellData.cooldown;
    }

    public void UseAction(int currTick)
    {
        tickLastUsed = currTick;
    }
}
