using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayController _levelController;

    public void Start()
    {
        _levelController = new PlayController();
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGame()
    {
        _levelController.LoadNextLevel();

    }
}
