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

    public HealthWithinThreshold(Character agent)
    {

    }

    public IDecision MakeDecision(Character agent)
    {
        return null;
    }
}
