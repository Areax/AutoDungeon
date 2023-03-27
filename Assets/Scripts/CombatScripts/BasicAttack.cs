using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Action
{
    private string name = "Attack";
    private int tickLastUsed = -1;
    private ActionEffect attackEffect;

    public int GetCastTime()
    {
        return 1;
    }

    public ActionEffect GetEffect(Stats playerStats)
    {
        attackEffect = new ActionEffect();
        attackEffect.effectStats = new List<Stats>();
        attackEffect.effectStats.Add(new Stats());
        attackEffect.effectStats[0].currentHitPoints = (-1) * playerStats.currentStrength;
        attackEffect.numberOfApplications = 1;
        return attackEffect;
    }

    public string GetName()
    {
        return name;
    }

    public int GetNextUsableTick()
    {
        if (tickLastUsed < 0)
        {
            return 0;
        }

        return tickLastUsed + 1;
    }

    public void UseAction(int currTick)
    {
        tickLastUsed = currTick;
    }

    public bool ShouldSelfTarget()
    {
        return false;
    }
}
