using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private int currentTick = 0;
    public List<Player> players = new List<Player>();
    public Player player;

    public List<Enemy> enemies = new List<Enemy>();

    private void Awake()
    {
        //  this is a hacky way of making sure we have a "list" of enemies for the enemy ai to use actions
        player = players[0];
    }

    public void UseAction(Action action, List<Enemy> enemies)
    {
        Stats playerStats = GetPlayer().playerStats;
        ActionEffect attackEffect = action.GetEffect(playerStats);

        //  if the player does not have a target:
        if (player.target == null)
        {
            //  default to the first enemy in the list
            Debug.Log("Applying effect: " + attackEffect.effectStats.ToString());
            enemies[0].UpdateCharacterStats(attackEffect.effectStats);
            Debug.Log(enemies[0].enemyStats.curHitPoints);

        }
        //  otherwise, we have a target
        else
        {
            Debug.Log("Applying effect: " + attackEffect.effectStats.ToString());
            player.target.UpdateCharacterStats(attackEffect.effectStats);
            Debug.Log(player.target.enemyStats.curHitPoints);
        }
    }

    public List<Action> GetUsableActions()
    {
        return new List<Action>();
    }

    public Player GetPlayer()
    {
        return player;
    }

    public List<Enemy> GetEnemies()
    {
        return enemies;
    }
}
