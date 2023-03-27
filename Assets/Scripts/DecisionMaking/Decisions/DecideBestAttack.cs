using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecideBestAttack : IDecision
{

    //  There is no need for a decision ref because it will act regardless
    //  always returns null
    //  end of tree

    public DecideBestAttack()
    {

    }

    public DecideBestAttack(Character agent)
    {

    }

    public IDecision MakeDecision(Character agent)
    {
        return null;
    }
}
