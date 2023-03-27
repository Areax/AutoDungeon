using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private int currentTick = 0;
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();
    private Dictionary<Enemy, List<EffectManager>> activeEffects = new Dictionary<Enemy, List<EffectManager>>();

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
        enemies.ForEach((Enemy enemy) =>
        {
            if (!activeEffects.ContainsKey(enemy))
            {
                activeEffects[enemy] = new List<EffectManager>();
            }
            activeEffects[enemy].Add(new EffectManager(attackEffect));
        });
        int castTime = action.GetCastTime();
        for (int tick = 0; tick < castTime; tick++)
        {
            ProcessTick();
        }
    }

    private class EffectManager {
        public int relativeTick = 0;
        public ActionEffect effect;
        public EffectManager(ActionEffect effectIn)
        {
            relativeTick = 0;
            effect = effectIn;
        }
    }


    public void ProcessTick()
    {
        foreach (Enemy enemy in activeEffects.Keys)
        {
            List<EffectManager> actionEffects = activeEffects[enemy];
            foreach (EffectManager effectManager in actionEffects)
            {
                ActionEffect effect = effectManager.effect;
                ((Character)enemy).ApplyStatsEffect(effect.effectStats[effectManager.relativeTick]);
                effectManager.relativeTick += 1;
            }
            // Loop over the effects backwards, removing the ones which have finished
            for(int i = actionEffects.Count - 1; i >= 0; i--)
            {
                EffectManager effectManager = actionEffects[i];
                if (effectManager.relativeTick >= effectManager.effect.effectStats.Count)
                {
                    actionEffects.RemoveAt(i);
                }
            }
        }
        currentTick += 1;
        foreach (Enemy enemy in activeEffects.Keys)
        {
            Debug.Log("After tick " + currentTick + " enemy " + enemy.GetName() + " stats: " + enemy.GetStats());
        }
    }

    public List<Action> GetUsableActions()
    {
        // TODO
        return new List<Action>();
    }

    public List<Spell> GetSpells()
    {
        return player.spells;
    }

    public List<Ability> GetAbilities()
    {
        return player.abilities;
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
