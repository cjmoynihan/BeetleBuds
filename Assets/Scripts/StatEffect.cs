using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static StatsController;

public abstract class StatEffect : MonoBehaviour
{
    // TODO: make Parts inherit StatEffect
    public abstract Stats applyStats(Stats initialStats);
}
