using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) 
    { 
        if (collision.gameObject.CompareTag("Enemy")) 
        { 
            collision.gameObject.SendMessage("ApplyDamage", 1);
            DestoryThisProjectile();
        } 
    }

    void DestoryThisProjectile()
    {
        Destroy(gameObject);
    }
}
