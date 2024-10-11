using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    private float speed = 2f;
    public bool hasSeenEnemy;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (hasSeenEnemy)
        {
            followEnemy();
        }
    }

    private void followEnemy()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.gameObject.tag == "Player")
            {
                hasSeenEnemy = true;
                player = collision.gameObject;
                Debug.Log("Player detected and assigned.");

            }
        }
        else
        {
            Debug.LogWarning("Collision object is null in OnTriggerEnter2D method.");

        }
    }
}
