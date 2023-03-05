using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    GameController gameController;

    public void Start()
    {
        var gameObject = GameObject.Find("GameController");
        gameController = gameObject.GetComponent<GameController>();
    }

    public void PlayGame()
    {
        gameController.PlayGame();

    }
    public void QuitGame()
    {
        Application.Quit();
    } 
}
