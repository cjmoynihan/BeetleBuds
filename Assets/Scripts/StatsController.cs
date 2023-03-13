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
        public float attackCooldown;
        public float attackRange;
        public float attackDamage;
        public float slowDuration;
        private List<Func<Stats, Stats>> statEffects = new List<Func<Stats, Stats>>();
        private Stats modifiedStats;
        public Stats _parentStats = null;
        public Stats ModifiedStats
        {
            get
            {
                if (statEffects.Count == 0)
                {
                    return this;
                }
                else
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
            if (statEffects.Remove(effect))
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
                // Set _parentStats to the upmost stats
                _parentStats = (_parentStats != null ? _parentStats : this),
                maxHealth = maxHealth,
                health = health,
                moveSpeed = moveSpeed,
                attackCooldown = attackCooldown,
                attackRange = attackRange,
                attackDamage = attackDamage,
                slowDuration = slowDuration
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
        public void UpdateStats()
        {
            ModifiedStats = GetAppliedStats();
            if (ModifiedStats.health > ModifiedStats.maxHealth)
            {
                ModifiedStats.health = ModifiedStats.maxHealth;
            }
        }
    }

    // All of the get and set functions for these stats have been overloaded
    // Getting the variable returns the modified variable
    // Setting the variable changes the initial (unmodified by status effects)
    private Stats initialStats = new Stats();
    public Animator anim;

    public Stats ModifiedStats
    {
        get { return initialStats.ModifiedStats; }
    }

    public int maxHealth
    {
        get { return initialStats.maxHealth;  }
        set
        {
            initialStats.maxHealth = value;
            initialStats.UpdateStats();
        }
    }
    public int health
    {
        get { return initialStats.health; }
        set
        {
            if (value < health)
            {
                anim.SetBool("TakeDamage", true);
                StartCoroutine(StopAnimation());
            }
            initialStats.health = value;
            initialStats.UpdateStats();
        }
    }
    public float moveSpeed
    {
        get { return initialStats.moveSpeed; }
        set
        {
            initialStats.moveSpeed = value;
            initialStats.UpdateStats();
        }
    }
    public float attackCooldown
    {
        get { return initialStats.attackCooldown; }
        set
        {
            initialStats.attackCooldown = value;
            initialStats.UpdateStats();
        }
    }
    public float attackRange
    {
        get { return initialStats.attackRange; }
        set
        {
            initialStats.attackRange = value;
            initialStats.UpdateStats();
        }
    }
    public float attackDamage
    {
        get { return initialStats.attackDamage; }
        set
        {
            initialStats.attackDamage = value;
            initialStats.UpdateStats();
        }
    }
    public float slowDuration
    {
        get { return initialStats.slowDuration; }
        set
        {
            initialStats.slowDuration = value;
            initialStats.UpdateStats();
        }
    }
    public void AddEffect(Func<Stats, Stats> effect)
    {
        initialStats.AddEffect(effect);
    }
    public void RemoveEffect(Func<Stats, Stats> effect)
    {
        initialStats.RemoveEffect(effect);
    }
    public IEnumerator StopAnimation()
    {
        AnimatorStateInfo curState = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForEndOfFrame();
        anim.SetBool("TakeDamage", false);
    }
}
