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
    public bool canAttack;
    public float attackCooldown;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // Find mouse
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the amount we need to rotate
        Vector3 rotation = mousePos - transform.position;

        // Apply math to rotate + 90 degrees
        float rotZ = Mathf.Atan2(-rotation.x, rotation.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotZ);



        // Handle attacking
        if (Input.GetMouseButton(0) && canAttack)
        {
            canAttack = false;
            Instantiate(attackObject, attackTransform.position, transform.rotation * Quaternion.Euler(0, 0, -45));
            StartCoroutine(WaitAttackCooldown());
        }
    }

    IEnumerator WaitAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
