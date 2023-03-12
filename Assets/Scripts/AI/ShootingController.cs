using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    private Animator anim;


    public GameObject attackObject;
    public Transform attackTransform;
    public bool canAttack = true;
    public float attackRotation = -45;
    public float attackCooldown = 0.3f;
    public int ninetyRotations = 3;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
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
            Instantiate(attackObject, attackTransform.position, transform.rotation * Quaternion.Euler(0, 0, attackRotation));
            StartCoroutine(StopAttackAnimation());
            StartCoroutine(WaitAttackCooldown());

        }
    }

    IEnumerator WaitAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
    private IEnumerator StopAttackAnimation()
    {
        AnimatorStateInfo curState = anim.GetCurrentAnimatorStateInfo(0);
        yield return new WaitForEndOfFrame();
        anim.SetBool("IsAttacking", false);
    }
}
