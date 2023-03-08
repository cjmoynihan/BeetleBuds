using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesBehavior : EnemyTypes.EnemyBehavior
{
    public int damage = 0;

    public float pushback = 1;

    public int gradualPushValue = 100;
    private void Start()
    {
        hitPoints = 1000;
    }

    protected override void PlayerCollision(Collision2D collision)
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

    public override void Behavior()
    {
    }
}
