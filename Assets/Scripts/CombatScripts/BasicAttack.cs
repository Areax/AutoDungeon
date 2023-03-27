using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAttack : Action
{
    private string name = "Attack";

    public int GetCastTime()
    {
        return 1;
    }

    public ActionEffect GetEffect(Stats playerStats)
    {
        ActionEffect attackEffect = new ActionEffect();
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
        throw new System.NotImplementedException();
    }

    public void UseAction(int currTick)
    {
        throw new System.NotImplementedException();
    }
}
