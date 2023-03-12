using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QueenBeeHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject HealthNib;
    public GameObject HealthText;
    private float rightnib = 609.34f;
    private float leftnib = -740f;
    private float range => rightnib - leftnib;

    private QueenBeeController playerController;

    // Update is called once per frame
    void Update()
    {
        try
        {
            HealthBar.GetComponent<Image>().fillAmount = (float)((float)playerController.hitPoints) / ((float)playerController.maxHitPoints);
            HealthNib.transform.localPosition = new Vector3(leftnib + range * HealthBar.GetComponent<Image>().fillAmount, HealthNib.transform.localPosition.y, 0);
            HealthText.GetComponent<TMP_Text>().text = $"{playerController.hitPoints}/{playerController.maxHitPoints} hp";
        }
        catch
        {
            playerController = GameObject.FindGameObjectWithTag("Boss").GetComponent<QueenBeeController>();
        }
    }
}
