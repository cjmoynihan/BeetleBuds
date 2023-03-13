using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Animator anim;
    private PlayerController playerController;


    public GameObject attackObject;
    public Transform attackTransform;
    public bool canAttack = true;
    public float attackRotation = -45;
    public int ninetyRotations = 3;
    public float playerSlow = 0.5f;
    public Vector3 adjustment = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        anim = playerObj.GetComponent<Animator>();
        playerController = playerObj.GetComponent<PlayerController>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

    }

    public Vector2 rotate90(Vector2 v2)
    {
        return new Vector2(-v2.y, v2.x);
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        }
        catch
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        }

        Vector3 rotation = mousePos - transform.position;
        Vector2 afterRotations = new Vector2(rotation.x, rotation.y);
        int numRotations;
        for (numRotations = 0; numRotations < ninetyRotations; numRotations++)
        {
            afterRotations = rotate90(afterRotations);
        }

        float rotZ = Mathf.Atan2(afterRotations.y, afterRotations.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, (rotZ));

        // Handle Attacking
        if (Input.GetMouseButton(0) && canAttack)
        {
            anim.SetBool("IsAttacking", true);

            canAttack = false;
            GameObject attack = Instantiate(attackObject, attackTransform.position + transform.rotation * adjustment, transform.rotation * Quaternion.Euler(0, 0, attackRotation));
            attack.transform.localScale *= playerController.ModifiedStats.attackRange;
            StartCoroutine(StopAttackAnimation());
            StartCoroutine(WaitAttackCooldown());
            StartCoroutine(SlowPlayer());
            StartCoroutine(DestroyAttack(attack));
        }
    }

    public StatsController.Stats slowAttacker(StatsController.Stats initialStats)
    {
        initialStats.moveSpeed *= playerSlow;
        return initialStats;
    }
    private IEnumerator SlowPlayer()
    {
        Func<StatsController.Stats, StatsController.Stats> slowFunc = slowAttacker;
        playerController.AddEffect(slowFunc);
        yield return new WaitForSeconds(playerController.ModifiedStats.slowDuration);
        playerController.RemoveEffect(slowFunc);
    }


    IEnumerator WaitAttackCooldown()
    {
        yield return new WaitForSeconds(playerController.ModifiedStats.attackCooldown);
        canAttack = true;
    }
    private IEnumerator StopAttackAnimation()
    {
        AnimatorStateInfo curState = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForEndOfFrame();
        anim.SetBool("IsAttacking", false);
    }
    private IEnumerator DestroyAttack(GameObject attack)
    {
        yield return new WaitForSeconds(1);
        Destroy(attack);
    }
}
