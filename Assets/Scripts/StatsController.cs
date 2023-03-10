using System;
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
        private List<Func<Stats, Stats>> statEffects = new List<Func<Stats, Stats>>();
        public Stats modifiedStats
        {
            get
            {
                if(statEffects.Count == 0)
                {
                    return this;
                } else
                {
                    return modifiedStats;
                }
            }
            set { modifiedStats = value; }
        }

        // Note, may have to add or remove effects during update instead...
        public void AddEffect(Func<Stats, Stats> effect)
        {
            statEffects.Add(effect);
            UpdateStats();
        }
        public void RemoveEffect(Func<Stats, Stats> effect)
        {
            if(statEffects.Remove(effect))
            {
                // Returns false if object has already been removed
                UpdateStats();
            }
        }

        // Shallowcopy. Do not modify vars of children!
        public Stats ShallowCopy()
        {
            Stats tempStats = new()
            {
                maxHealth = maxHealth,
                health = health,
                moveSpeed = moveSpeed,
                attackSpeed = attackSpeed
            };
            return tempStats;
        }

        // Apply effects and return them
        // Since this stores a child version of this class when called,
        //   be careful about recursive child loop. Thar be dragons :)
        public Stats GetAppliedStats()
        {
            Stats tempStats = ShallowCopy();
            foreach (Func<Stats, Stats> effect in statEffects)
            {
                tempStats = effect(tempStats);
            }
            return tempStats;
        }
        private void UpdateStats()
        {
            modifiedStats = GetAppliedStats();
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
    public void AddEffect(Func<Stats, Stats> effect)
    {
        initialStats.AddEffect(effect);
    }
    public void RemoveEffect(Func<Stats, Stats> effect)
    {
        initialStats.RemoveEffect(effect);
    }
}
