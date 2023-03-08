using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    PlayController _playController;
    public GameObject seedGenerator;
    public GameObject _player;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    public void Start()
    {
        _playController = new PlayController();
    }

    public void PlayGame()
    {
        var seedGen = seedGenerator.GetComponent<SetSeed>();
        seedGen.SetGameSeed();
        Instantiate(_player);
        _playController.LoadNextLevel();

    }
    public void Next()
    {
        _playController.Next();
    }
}
