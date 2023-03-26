using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private int currentTick = 0;
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();

    public void UseAction(Action action, List<Enemy> enemies)
    {
        Stats playerStats = GetPlayer().playerStats;
        ActionEffect attackEffect = action.GetEffect(playerStats);
        enemies.ForEach((Enemy enemy) =>
        {
            Debug.Log("Applying effect: " + attackEffect.effectStats.ToString());
            ((Character)enemy).ApplyStatsEffect(attackEffect.effectStats);
            Debug.Log(enemy.enemyData.enemyStats);
        });
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
