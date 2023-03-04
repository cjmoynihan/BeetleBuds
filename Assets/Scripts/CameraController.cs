using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        // Change position to match player, except not rotation
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
