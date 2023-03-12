using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject TextObject;

    private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        try
        {
            var textbox = TextObject.GetComponent<TMP_Text>();
            textbox.text = "HEALTH: " + playerController.ModifiedStats.health.ToString();
        } catch
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
