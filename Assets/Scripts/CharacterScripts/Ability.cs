using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : Object, Action
{
    AbilityData abilityData;
    private int tickLastUsed = -1;


    ActionEffect Action.GetEffect(Stats playerStats)
    {
        return abilityData.effect;
    }

    string Action.GetName()
    {
        return abilityData.abilityName;
    }

    int Action.GetNextUsableTick()
    {
        if (tickLastUsed < 0)
        {
            return 0;
        }

        return tickLastUsed + abilityData.cooldown;
    }

    void Action.UseAction(int currTick)
    {
        tickLastUsed = currTick;
    }

    public bool IsBuff()
    {
        return abilityData.buff;
    }
    public bool IsHeal()
    {
        return abilityData.heal;
    }
    public bool IsAttack()
    {
        return abilityData.attack;
    }
}
