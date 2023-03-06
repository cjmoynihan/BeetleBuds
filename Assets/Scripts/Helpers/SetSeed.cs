using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetSeed : MonoBehaviour
{
    public string seedText;

    private int seed = 1;

    public bool useRandomSeed;

    public bool usePlayerSeed;

    public TMP_Text seedbox;


    public void SetGameSeed()
    {
        if (useRandomSeed)
        {
            seed = Random.Range(0, 10000);
        }
        
        if (usePlayerSeed)
        {
            seed = seedbox.text.GetHashCode();
        }

        Random.InitState(seed);
    }

}
