using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour, Action
{
    public AbilityData abilityData;
    private int tickLastUsed = -1;
    private int currentEffectIndex = 0;

    public int GetCastTime()
    {
        return abilityData.castTime;
    }

    public ActionEffect GetEffect(Stats playerStats)
    {
        return abilityData.effect;
    }

    public string GetName()
    {
        return abilityData.abilityName;
    }

    public int GetNextUsableTick()
    {
        if (tickLastUsed < 0)
        {
            return 0;
        }

        return tickLastUsed + abilityData.cooldown;
    }

    public void UseAction(int currTick)
    {
        tickLastUsed = currTick;
    }
}
