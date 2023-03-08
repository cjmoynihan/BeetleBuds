using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    Rigidbody2D playerRb;
    public GameObject _player;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) {
            Instantiate(_player);
            player = _player;
        }

        player.GetComponent<Transform>().position = transform.position;

        //var player = GameObject.FindGameObjectWithTag("Player");
        //playerRb = player.GetComponent<Rigidbody2D>();
        //playerRb.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
