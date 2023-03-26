using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatUIManager : MonoBehaviour
{
    public CombatManager combatManager;
    public GameObject fightButton;
    public GameObject spellButton;
    public GameObject dynamicSpellButton;
    public void ClickFightButton()
    {
        BasicAttack basicAttack = new BasicAttack();
        // TODO enemy selection
        List<Enemy> enemies = combatManager.GetEnemies();
        if (enemies.Count == 0)
        {
            Debug.LogError("Combat manager returned empty list of enemies!");
            return;
        }
        // Enemy selectedEnemy = enemies[0];
        combatManager.UseAction(basicAttack, enemies);
    }
    public void ClickSpellButton()
    {
        List<Spell> spells = combatManager.GetPlayer().spells;
        for (int i = 0; i < spells.Count; i++)
        {
            Spell spell = spells[i];
        }
    }
}
