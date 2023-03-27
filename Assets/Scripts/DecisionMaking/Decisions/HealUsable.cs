using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealUsable : IDecision
{
    //  no true branch, if it executes to true it will act

    //  reference to the false branch of this decision
    //  assigned on initialization of the tree
    public IDecision falseBranch = null;

    public HealUsable()
    {

    }

    public HealUsable(Enemy agent)
    {

    }

    public IDecision MakeDecision(Enemy agent)
    {
        return null;
    }
}
