using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Health related info
    public int hitPoints;
    public Transform playerTransform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Attack")
        {
            hitPoints -= 1;
            if(hitPoints <= 0)
            {
                Destroy(gameObject);
            }
        }
    }



}
