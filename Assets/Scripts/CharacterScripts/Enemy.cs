using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour, Character
{

    //  field for this enemies name
    public string enemyName;

    //  reference for this enemies stats struct
    public EnemyStats enemyStats;

    //  system.serializable allows this struct to be shown in the inspector
    [System.Serializable]
    public struct EnemyStats
    {
        //  fields for max / cur hp
        public int baseHitPoints;
        public int curHitPoints;
        [Space]

        // fields for max / cur speed
        public int baseSpeed;
        public int curSpeed;
        [Space]

        // fields for max / cur dex
        public int baseDexterity;
        public int curDexterity;
        [Space]

        // fields for max / cur strength
        public int baseStrength;
        public int curStrength;
        [Space]

        //   fields for max / cur wisdom
        public int baseWisdom;
        public int curWisdom;
        [Space]

        //  fields for max / cur intelligence
        public int baseIntelligence;
        public int curIntelligence;
        [Space]

        //  fields for the max / cur charisma
        public int baseCharisma;
        public int curCharisma;
    }

    //  field for the level of this unit
    public int level;

    public EnemyData enemyData;

    [SerializeField] private Player playerRef;
    [SerializeField] private GameObject targetIndicator;
    [SerializeField] private CombatManager combatManager;

    public bool isTargeted = false;

    private BasicAttack basicAttack = new BasicAttack();

    public BasicAttack GetBasicAttack()
    {
        return basicAttack;
    }

    public int GetLevel()
    {
        return enemyData.level;
    }

    public string GetName()
    {
        return enemyData.enemyName;
    }

    public Stats GetStats()
    {
        return enemyData.enemyStats;
    }


    //  for debugging enemy death--
    public void Awake()
    {

        // initialize this enemies stats using the base stats in enemyData
        this.enemyStats.baseHitPoints = enemyData.enemyStats.maxHitPoints;
        this.enemyStats.curHitPoints = this.enemyStats.baseHitPoints;
        
        this.enemyStats.baseSpeed = enemyData.enemyStats.maxSpeed;
        this.enemyStats.curSpeed = this.enemyStats.baseSpeed;

        this.enemyStats.baseDexterity = enemyData.enemyStats.maxDexterity;
        this.enemyStats.curDexterity = this.enemyStats.baseDexterity;

        this.enemyStats.baseStrength = enemyData.enemyStats.maxStrength;
        this.enemyStats.curStrength = this.enemyStats.baseStrength;

        this.enemyStats.baseWisdom = enemyData.enemyStats.maxWisdon;
        this.enemyStats.curWisdom = this.enemyStats.baseWisdom;

        this.enemyStats.baseIntelligence = enemyData.enemyStats.maxIntelligence;
        this.enemyStats.curIntelligence = this.enemyStats.baseIntelligence;

        this.enemyStats.baseCharisma = enemyData.enemyStats.maxCharisma;
        this.enemyStats.curCharisma = this.enemyStats.baseCharisma;

        //  initialize ref to player in the jankiest way possible
        playerRef = FindObjectOfType<Player>();
        //  initialize ref to the combat manager in the jankiest way possible
        combatManager = FindObjectOfType<CombatManager>();
    }

    public void OnMouseOver()
    {
        //  check if the left mouse button is pressed over this enemy
        if(Input.GetMouseButtonDown(0))
        {
            //  check if the player currently has a target selected:
            if (playerRef.target != null)
            {
                if (playerRef.target == this)
                {
                    this.isTargeted = false;
                    playerRef.target = null;
                }
                else
                {
                    //  if so, unselect that target
                    playerRef.target.isTargeted = false;
                    //  assign the target to this
                    playerRef.target = this;
                    //  mark this as targeted
                    this.isTargeted = true;
                }
            }
            //  otherwise, we have no target
            else
            {
                playerRef.target = this;
                this.isTargeted = true;
            }
        }
    }

    void Update()
    {
        //  check if this enemy has been targeted
        //  update the active status of the targetIndicator accordingly
        switch (isTargeted)
        {
            case true:
                targetIndicator.SetActive(isTargeted);
                break;
            case false:
                targetIndicator.SetActive(isTargeted);
                break;
        }
    }

    //  method for updating the current stats of this character
    public void UpdateCharacterStats(Stats changes)
    {
        this.enemyStats.curHitPoints += changes.currentHitPoints;
        this.enemyStats.curSpeed += changes.currentSpeed;
        this.enemyStats.curDexterity += changes.currentDexterity;
        this.enemyStats.curStrength += changes.currentStrength;
        this.enemyStats.curWisdom += changes.currentWisdom;
        this.enemyStats.curIntelligence += changes.currentIntelligence;
        this.enemyStats.curCharisma += changes.currentCharisma;

        //  check death state here so it is not done in update/every frame
        if (this.enemyStats.curHitPoints <= 0)
        {
            //  remove this enemy from the combat manager enemies list
            combatManager.enemies.Remove(this);
            //  destroy this game object
            Destroy(this.gameObject);
        }
    }
}
