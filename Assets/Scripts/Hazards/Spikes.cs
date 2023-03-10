using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : IHazard
{
    public int damage = 0;

    public float pushback = 1;

    public int gradualPushValue = 100;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Behavior(collision);
        }
    }

    protected void Behavior(Collision2D collision)
    {
        // Deal damage!! Spike damage!
        var player = FindPlayer().GetComponent<PlayerController>();

        var transform = player.transform;
        player.GetComponent<PlayerController>().health -= damage;
        Debug.Log($"Health:{FindPlayer().GetComponent<PlayerController>().health}");

        Vector3 direction = new Vector3(Mathf.Cos(Mathf.Deg2Rad*(90 - transform.eulerAngles.z)), Mathf.Sin(Mathf.Deg2Rad*(90 - transform.eulerAngles.z)), Mathf.Sin(Mathf.Deg2Rad*(90 - transform.eulerAngles.y))) * -1;
        StartCoroutine(PushBack(player,direction));
    }

    public IEnumerator PushBack(PlayerController player, Vector3 pushbackDirection)
    {
        for (int i = 0; i < pushback; i += gradualPushValue)
        {
            player.rb.AddRelativeForce(pushbackDirection*gradualPushValue);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
