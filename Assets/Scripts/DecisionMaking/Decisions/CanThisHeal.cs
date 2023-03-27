using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanThisHeal : IDecision
{
    //  flag for if the Agent for this decision tree can heal
    bool canHeal = false;

    //  reference to the true branch of the decision tree
    //  assigned on initialization of the tree
    public IDecision trueBranch= null;
    //  reference to the false branch of the decision tree
    //  assigned on initialization of the tree
    public IDecision falseBranch= null;

    public CanThisHeal()
    {

    }

    public CanThisHeal(Character agent)
    {
        
    }

    public IDecision MakeDecision(Character agent)
    {
        if (canHeal)
        {
            Debug.Log("This unit can heal, entering threshold check decision.");
            return null;
        }

        else
        {
            Debug.Log("This unit cannot heal, entering can this unit buff decision.");
            return null;
        }
    }
}
