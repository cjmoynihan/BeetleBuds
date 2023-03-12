using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverMenuController : MonoBehaviour
{
    public GameObject player;
    public GameObject causeOfDeathTextbox;
    public GameObject roomsClearedTextBox;
    public GameObject foundLimbsTextBox;   
    public GameObject timeTextBox;
    public GameObject killsTextBox;

    private TMP_Asset causeOfDeathText;
    private TMP_Asset roomsClearedText;
    private TMP_Asset foundLimbsText;
    private TMP_Asset timeText;
    private TMP_Asset killsText;


    public string CauseOfDeath;
    public int roomsCleared;
    public int foundLimbs;
    public string time;
    public int numKills;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameObject.activeSelf)
            {
                gameObject.SetActive(false);
            }
        }
        
    }
}
