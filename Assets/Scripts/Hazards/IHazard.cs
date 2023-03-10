using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHazard : MonoBehaviour
{
    protected GameObject FindPlayer()
    {
        return GameObject.FindWithTag("Player");
    }


}
