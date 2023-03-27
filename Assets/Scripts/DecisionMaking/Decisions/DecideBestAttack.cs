using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DecideBestAttack : IDecision
{

    //  There is no need for a decision ref because it will act regardless
    //  always returns null
    //  end of tree

    public DecideBestAttack()
    {

    }

    public DecideBestAttack(Enemy agent)
    {

    }

    public IDecision MakeDecision(Enemy agent)
    {
        BasicAttack basicAttack = new BasicAttack();
        Player player = agent.combatManager.player;

        
        
        return null;
    }
}
