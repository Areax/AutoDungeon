using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class DecideBestAttack : IDecision
{

    //  There is no need for a decision ref because it will act regardless
    //  always returns null
    //  end of tree

    List<Action> attacks = new List<Action>();

    public DecideBestAttack()
    {

    }

    public DecideBestAttack(Enemy agent)
    {
        BasicAttack basicAttack = new BasicAttack();
        attacks.Add(basicAttack);

        if (agent.spells.Count == 0 && agent.abilities.Count == 0)
        {
            Debug.Log("This unit has no spells or abilities--");
        }
        else
        {
            if (agent.spells.Count != 0)
            {

                Debug.Log("Checking for spells that can be used as attacks...");

                //  iterate through the spells on this agent
                foreach (Spell spell in agent.spells)
                {
                    if (spell.IsAttack())
                    {
                        attacks.Add(spell);
                    }
                    //  otherwise, do nothing
                }
            }
            if (agent.abilities.Count != 0)
            {
                Debug.Log("Checking for abilities that can be used as attacks...");

                //  iterate through the spells on this agent
                foreach (Ability ability in agent.abilities)
                {
                    if (ability.IsAttack())
                    {
                        attacks.Add(ability);
                    }
                    //  otherwise, do nothing
                }
            }
        }
    }

    public IDecision MakeDecision(Enemy agent)
    {

        Debug.Log("this agent is determining the best attack to use: ");

        //  cache ref to player
        Player player = agent.combatManager.player;
        
        //  if the list of attacks is greater than 1
        if (attacks.Count > 1)
        {
            //  calc best usable attack
        }

        //  otherwise, just use a basic attack
        ActionEffect attackEffect = attacks[0].GetEffect(agent.GetCurrentStats());

        //  cast the player as a character
        Character playerCharacter = player;

        Debug.Log("Player HP before: " + player.playerStats.currentHitPoints);

        //  apply damage to player
        playerCharacter.ApplyStatsEffect(attackEffect.effectStats);

        Debug.Log("Player HP after: " + player.playerStats.currentHitPoints);

        //  exit from decision tree
        return null;
    }
}
