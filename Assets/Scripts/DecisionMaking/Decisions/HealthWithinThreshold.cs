using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthWithinThreshold : IDecision
{
    //  reference to the true branch of this decision
    //  assigned on initialization of the tree
    public IDecision trueBranch = null;

    //  reference to the false branch of this decision
    //  assigned on initialization of the tree
    public IDecision falseBranch = null;

    public HealthWithinThreshold()
    {

    }

    public HealthWithinThreshold(Enemy agent)
    {

    }

    public IDecision MakeDecision(Enemy agent)
    {
        //  just check if below 50% health to be lazy
        if (agent.enemyStats.curHitPoints < agent.enemyStats.baseHitPoints / 2)
        {
            Debug.Log("Entering true branch of HealWithinThreshold Deicion -> heal usable decision");
            return trueBranch.MakeDecision(agent);
        }
        else
        {
            Debug.Log("Entering false branch of HealWithinThreshold Decision -> CanThisBuff decision");
            return falseBranch.MakeDecision(agent);
        }
    }
}
