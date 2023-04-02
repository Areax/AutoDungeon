using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour, Action
{
    SpellData spellData;
    private int tickLastUsed = -1;

    ActionEffect Action.GetEffect(Stats playerStats)
    {
        return spellData.effect;
    }

    string Action.GetName()
    {
        return spellData.spellName;
    }

    int Action.GetNextUsableTick()
    {
        if (tickLastUsed < 0)
        {
            return 0;
        }

        return tickLastUsed + spellData.cooldown;
    }

    void Action.UseAction(int currTick)
    {
        tickLastUsed = currTick;
    }

    public bool IsBuff()
    {
        return spellData.buff;
    }
    public bool IsHeal()
    {
        return spellData.heal;
    }
    public bool IsAttack()
    {
        return spellData.attack;
    }
}
