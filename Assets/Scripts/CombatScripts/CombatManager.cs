using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    private int currentTick = 0;
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();
    private Dictionary<Character, List<EffectManager>> activeEffects = new Dictionary<Character, List<EffectManager>>();

    public void UseAction(Action action, List<Enemy> enemies)
    {
        action.UseAction(currentTick);

        Character target = getTarget(action);
        Stats playerStats = GetPlayer().playerStats;
        ActionEffect actionEffect = action.GetEffect(playerStats).Clone();
        if (!activeEffects.ContainsKey(target))
        {
            activeEffects[target] = new List<EffectManager>();
        }
        activeEffects[target].Add(new EffectManager(actionEffect));
        int castTime = action.GetCastTime();
        for (int tick = 0; tick < castTime; tick++)
        {
            ProcessTick();
        }
    }

    private Character getTarget(Action action)
    {
        if (action.ShouldSelfTarget())
        {
            return player;
        }
        Enemy target = player.target;
        //  if the player does not have a target set it to the first enemy
        if (target == null)
        {
            target = enemies[0];
        }
        return target;
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
        foreach (Character character in activeEffects.Keys)
        {
            Debug.Log("Before tick " + currentTick + " character " + character.GetName() + " health: " + character.GetHealth());
        }
        Debug.Log("Starting to process tick " + currentTick);
        foreach (Character character in activeEffects.Keys)
        {
            List<EffectManager> actionEffects = activeEffects[character];
            foreach (EffectManager effectManager in actionEffects)
            {
                ActionEffect effect = effectManager.effect;
                character.UpdateCharacterStats(effect.effectStats[effectManager.relativeTick]);
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
        foreach (Character character in activeEffects.Keys)
        {
            Debug.Log("After tick " + currentTick + " character " + character.GetName() + " health: " + character.GetHealth());
        }
    }

    public List<Action> GetUsableActions()
    {
        List<Action> usableActions = new();
        List<Spell> usableSpells = GetUsableSpells();
        List<Ability> usableAbilities = GetUsableAbilities();
        usableSpells.ForEach((spell) => { usableActions.Add(spell); });
        usableAbilities.ForEach((ability) => { usableActions.Add(ability); });
        return usableActions;
    }

    public List<Spell> GetUsableSpells()
    {
        List<Spell> usableSpells = new();
        List<Spell> allSpells = GetSpells();
        foreach (Spell spell in allSpells)
        {
            if (spell.GetNextUsableTick() <= currentTick)
            {
                usableSpells.Add(spell);
            }
        }
        return usableSpells;
    }

    public List<Ability> GetUsableAbilities()
    {
        List<Ability> usableAbilities = new();
        List<Ability> allAbilities = GetAbilities();
        foreach (Ability ability in allAbilities)
        {
            if (ability.GetNextUsableTick() <= currentTick)
            {
                usableAbilities.Add(ability);
            }
        }
        return usableAbilities;
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
