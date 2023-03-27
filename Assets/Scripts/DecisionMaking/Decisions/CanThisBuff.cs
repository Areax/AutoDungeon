using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanThisBuff : IDecision
{
    //  flag for if the Agent for this decision tree can heal
    bool canBuff = false;

    //  reference to the true branch of the decision tree
    //  assigned on initialization of the tree
    public IDecision trueBranch = null;
    //  reference to the false branch of the decision tree
    //  assigned on initialization of the tree
    public IDecision falseBranch = null;

    public CanThisBuff()
    {

    }

    public CanThisBuff(Enemy agent)
    {
        canBuff = agent.canBuff;
    }

    public IDecision MakeDecision(Enemy agent)
    {
        if (canBuff)
        {
            Debug.Log("This unit can buff, entering buff usable decision.");
            return trueBranch.MakeDecision(agent);
        }

        else
        {
            Debug.Log("This unit cannot heal, entering attack calculation decision.");
            return falseBranch.MakeDecision(agent);
        }
    }
}

