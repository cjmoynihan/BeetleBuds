using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    // Attack information
    public GameObject attackObject;
    public Transform attackTransform;
    public bool canAttack = true;
    public float attackRotation = -45;
    public float attackCooldown;
    public int ninetyRotations = 3;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        transform.rotation = Quaternion.Euler(0, 0, (180 + 90 * ninetyRotations) % 360);
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
        } catch
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        }

        // Calculate the amount we need to rotate
        Vector3 rotation = mousePos - transform.position;

        // (-45, 45) is right, (45, 135) is up, (135, 180) (-180, -135) is left, (-135, -45) is down
        // With 2 directions, (-90, 90) is right, (-180, -90) (90, 180) is left
        float directionVar = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        //Debug.Log(Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg);
        Vector2 afterRotations = new Vector2(rotation.x, rotation.y);
        int numRotations;
        for (numRotations = 0; numRotations < ninetyRotations; numRotations++)
        {
            afterRotations = rotate90(afterRotations);
        }

        // Apply math to rotate + 90 degrees
        float rotZ = Mathf.Atan2(afterRotations.y, afterRotations.x) * Mathf.Rad2Deg;
        //Debug.Log(rotZ);

        //if (rotZ < 180)
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, (180 + 90 * ninetyRotations) % 360);
        //} else
        //{
        //    transform.rotation = Quaternion.Euler(0, 0, 0 + (90 * ninetyRotations) % 360);
        //}
        //transform.rotation = Quaternion.Euler(0, 0, (rotZ));


        // (-45, 45) is right, (45, 135) is up, (135, 180) (-180, -135) is left, (-135, -45) is down
        // With 2 directions, (-90, 90) is right, (-180, -90) (90, 180) is left
        float rotationAmount;
        SpriteRenderer[] spriteChildren = GetComponentsInChildren<SpriteRenderer>();
        if (directionVar < 90 && directionVar > -90)
        {
            // Right direction
            //rotationAmount = 0;
            // Instead of rotating, just set flip x to be right
            transform.localScale = new Vector3(-Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        } else
        {
            // Left direction
            //rotationAmount = 180;
            transform.localScale = new Vector3(Math.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        //transform.rotation = Quaternion.Euler(0, 0, (rotationAmount + 90 * ninetyRotations) % 360);

        //transform.rotation = Quaternion.Euler(0, 0, (directionVar + 90 * ninetyRotations) % 360);
        //Debug.Log(transform.rotation);

        
        //// Handle attacking
        //if (Input.GetMouseButton(0) && canAttack)
        //{
            

        //    canAttack = false;
        //    Instantiate(attackObject, attackTransform.position, transform.rotation * Quaternion.Euler(0, 0, attackRotation));
        //    StartCoroutine(WaitAttackCooldown());
            

        //}
    }

    //IEnumerator WaitAttackCooldown()
    //{
    //    yield return new WaitForSeconds(attackCooldown);
    //    canAttack = true;
    //}
}
