using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public PlayController _playController;
    public GameObject _hud;
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
        LoadPersistentObjects();
        _playController.LoadNextLevel();
    }

    public void LoadPersistentObjects()
    {
        DontDestroyOnLoad(Instantiate(_player));
        DontDestroyOnLoad(Instantiate(_hud));
    }

    public void Next()
    {
        _playController.Next();
    }
}
