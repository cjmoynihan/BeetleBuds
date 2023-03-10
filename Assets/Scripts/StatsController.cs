using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsController : MonoBehaviour
{
    // This controller applies status effects and controls things
    // like health, speed, etc for characters
    public class Stats
    {
        public int maxHealth;
        public int health;
        public float moveSpeed;
        public float attackSpeed;
        private List<StatEffect> statEffects;
        public Stats modifiedStats;

        // Initalizer
        public Stats()
        {

        }

        public void AddEffect(StatEffect effect)
        {
            statEffects.Add(effect);
            GetAppliedStats();
        }

        // Shallowcopy. Do not modify vars of children!
        public Stats ShallowCopy()
        {
            Stats tempStats = new Stats();
            tempStats.maxHealth = maxHealth;
            tempStats.health = health;
            tempStats.moveSpeed = moveSpeed;
            tempStats.attackSpeed = attackSpeed;
            return tempStats;
        }

        // Apply effects and return them
        // Since this stores a child version of this class when called,
        //   be careful about recursive child loop. Thar be dragons :)
        public Stats GetAppliedStats()
        {
            Stats tempStats = ShallowCopy();
            foreach (StatEffect effect in statEffects)
            {
                tempStats = effect.applyStats(tempStats);
            }
            modifiedStats = tempStats;
            return tempStats;
        }

    }

    // All of the get and set functions for these stats have been overloaded
    // Getting the variable returns the modified variable
    // Setting the variable changes the initial (unmodified by status effects)
    private Stats initialStats = new Stats();
    public int maxHealth
    {
        get { return initialStats.modifiedStats.maxHealth; }
        set { initialStats.maxHealth = value; }
    }
    public int health
    {
        get { return initialStats.modifiedStats.health; }
        set { initialStats.health = value; }
    }
    public float moveSpeed
    {
        get { return initialStats.modifiedStats.moveSpeed; }
        set { initialStats.moveSpeed = value; }
    }
    public float attackSpeed
    {
        get { return initialStats.modifiedStats.attackSpeed; }
        set { initialStats.moveSpeed = value; }
    }
    public void AddEffect(StatEffect effect)
    {
        initialStats.AddEffect(effect);
    }
}
