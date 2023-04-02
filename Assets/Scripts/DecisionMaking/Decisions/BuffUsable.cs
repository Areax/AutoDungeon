using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffUsable : IDecision
{
    //  If the decision evaluates to true--
    //  actions will be taken, no more decisions

    //  reference to the false branch of the decision tree
    //  assigned on initialization of the tree
    public IDecision falseBranch = null;

    public BuffUsable()
    {

    }

    public BuffUsable(Enemy agent)
    {

    }

    public IDecision MakeDecision(Enemy agent)
    {
        Debug.Log("This unit would be determining if a buff is usable but that logic is not implemented");
        return null;
    }
}

