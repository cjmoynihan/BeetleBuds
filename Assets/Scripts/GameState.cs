using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public string state = "new";

    private void Start()
    {
        var copies = FindObjectsByType<GameState>(FindObjectsSortMode.None);
        foreach (var c in copies)
        {
            if (c.state == "new" && !c.Equals(this))
            {
                Destroy(c);
            }
        }

        DontDestroyOnLoad(gameObject);
    }
}
