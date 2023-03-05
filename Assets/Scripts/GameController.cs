using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayController _levelController;
    public GameObject _player;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        _levelController = new PlayController();
    }

    public void PlayGame()
    {
        Instantiate(_player);
        _levelController.LoadNextLevel();

    }
    public void Next()
    {
        _levelController.Next();
    }
}
