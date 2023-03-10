using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// NOT PROPERLY IMPLEMENTED
public class StatusEffect : StatEffect
{
    private Func<StatsController.Stats, StatsController.Stats> statFunc;

    public StatusEffect(Func<StatsController.Stats, StatsController.Stats> statModifier)
    {
        throw new NotImplementedException("Can't initialize monobehavior");
        //statFunc = statModifier;
    }

    public override StatsController.Stats applyStats(StatsController.Stats initialStats)
    {
        return statFunc(initialStats);
    }
}
