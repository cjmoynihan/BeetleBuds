using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GameObject HealthBar;
    public GameObject HealthNib;
    public GameObject HealthText;
    private float rightnib = -685.0582f;
    private float leftnib = -1695;
    private float range => rightnib - leftnib;

    private PlayerController playerController;

    // Update is called once per frame
    void Update()
    {
        try
        {
            HealthBar.GetComponent<Image>().fillAmount = (float)((float)playerController.maxHealth) / ((float)playerController.health);
            HealthNib.transform.localPosition = new Vector3(leftnib + range * HealthBar.GetComponent<Image>().fillAmount, HealthNib.transform.localPosition.y, 0);
            HealthText.GetComponent<TMP_Text>().text = $"{playerController.health}/{playerController.maxHealth} hp";
        } catch
        {
            playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }
    }
}
