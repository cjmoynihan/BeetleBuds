using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatEffect : MonoBehaviour
{
    // TODO: make Parts inherit StatEffect
    public abstract StatsController.Stats applyStats(StatsController.Stats initialStats);
}
