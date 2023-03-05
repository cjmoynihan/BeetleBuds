using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitController : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                var controllerObject = GameObject.FindGameObjectWithTag("GameController");
                var gameController = controllerObject.GetComponent<GameController>();
                gameController.Next();
            }
        }
    }
}
