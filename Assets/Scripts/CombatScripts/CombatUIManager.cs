using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class CombatUIManager : MonoBehaviour
{
    public CombatManager combatManager;
    public GameObject fightButton;
    public GameObject spellButton;
    public GameObject abilityButton;
    public GameObject dynamicSpellButton;
    public UnityEngine.UI.VerticalLayoutGroup verticalLayoutGroup;
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
        List<Spell> spells = combatManager.GetSpells();
        populateActionButtons(spells.Cast<Action>().ToList());
    }
    public void ClickAbilityButton()
    {
        List<Ability> abilities = combatManager.GetAbilities();
        populateActionButtons(abilities.Cast<Action>().ToList());
    }

    private void populateActionButtons(List<Action> actions)
    {
        for (int i = 0; i < actions.Count; i++)
        {
            Action action = actions[i];
            var actionButton = Instantiate(dynamicSpellButton, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            TextMeshProUGUI buttonGUI = actionButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonGUI.text = action.GetName();
            // TODO enemy selection
            actionButton.GetComponent<Button>().onClick.AddListener(
                delegate
                {
                    combatManager.UseAction(action, combatManager.GetEnemies());
                    // After using the button, destroy the action options
                    for (int childI = verticalLayoutGroup.transform.childCount - 1; childI >= 0; childI--)
                    {
                        Destroy(verticalLayoutGroup.transform.GetChild(childI).gameObject);
                    }
                    fightButton.gameObject.SetActive(true);
                    abilityButton.gameObject.SetActive(true);
                    spellButton.gameObject.SetActive(true);
                }
                );
            actionButton.transform.parent = verticalLayoutGroup.transform;
        }
    }
}
