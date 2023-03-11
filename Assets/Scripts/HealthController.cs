using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public TextMeshPro healthText;

    private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        try
        {
            healthText.text = "HEALTH: " + playerController.health.ToString();
        } catch
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
