using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public PlayController _playController;
    public GameObject _hud;
    public GameObject seedGenerator;
    public GameObject _player;
    public GameObject _pauseMenu;
    public TMP_Text seedBox;
    private GameObject activeMenu;


    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayGame()
    {
        var seedGen = Instantiate(seedGenerator);
        var seedGenCon = seedGenerator.GetComponent<SetSeed>();
        seedGenCon.SetGameSeed(seedBox);
        try
        {
            //Destroy(seedGenerator);
            seedGenerator.SetActive(false);
        } finally
        {
            LoadPersistentObjects();
            _playController = new PlayController();
            _playController.LoadNextLevel();
        }
        
    }

    public void LoadPersistentObjects()
    {
        //if (_player != null) Destroy(_player);
        //if (_hud != null) Destroy(_hud);
        DontDestroyOnLoad(Instantiate(_player));
        DontDestroyOnLoad(Instantiate(_hud));
        DontDestroyOnLoad(_pauseMenu);
    }

    public void Next()
    {
        _playController.Next();
    }

    public void Restart()
    {
        var obj = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach(var item in obj)
        {
            Destroy(item);
        }
        SceneManager.LoadScene("Main Menu");
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Escape))
    //    {
    //        if (activeMenu== null)
    //        {
    //            activeMenu = Instantiate(_pauseMenu);
    //            activeMenu.SetActive(true);
    //        }
    //        else
    //        {
    //            Destroy(activeMenu);
    //        }
    //    }
    //}
}
