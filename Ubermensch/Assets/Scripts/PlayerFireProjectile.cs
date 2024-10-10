using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireProjectile : MonoBehaviour
{
    
    public GameObject projectile;
    public float minRange = 5f;
    public float firingSpeed = 5f;
    public float projectileLifeTime = 2f;

    enum FireDirection{
        Left,
        Right,
        Up,
        Down,
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PressToFire();
    }

    void PressToFire()
    {
        if (Input.GetButtonDown("FireUp")){
            FireProjectile(FireDirection.Up);
        }
        if (Input.GetButtonDown("FireDown")){
            FireProjectile(FireDirection.Down);
        }
        if (Input.GetButtonDown("FireLeft")){
            FireProjectile(FireDirection.Left);
        }
        if (Input.GetButtonDown("FireRight")){
            FireProjectile(FireDirection.Right);
        }
    }

    void FireProjectile(FireDirection fireDirection)
    {
        switch (fireDirection) {
            case FireDirection.Left:
                SpawnProjectile(Vector2.left, -minRange, 0f, Quaternion.Euler(0f,0f,180f));
                break;
            case FireDirection.Right:
                SpawnProjectile(Vector2.right, minRange, 0f, Quaternion.identity);
                break;
            case FireDirection.Up:
                SpawnProjectile(Vector2.up, 0f, minRange, Quaternion.Euler(0f,0f,90f));
                break;
            case FireDirection.Down:
                SpawnProjectile(Vector2.down, 0f, -minRange, Quaternion.Euler(0f,0f,270f));
                break;
            default:
                Debug.Log("No fire direction was pressed.");
                Debug.Break();
                break;
        }        
    }

    void SpawnProjectile(Vector2 direction, float xRange, float yRange, Quaternion rotationDirection)
    {
        var projectileTemp = Instantiate(projectile, transform.position + new Vector3(xRange, yRange,0f), rotationDirection);
        projectileTemp.GetComponent<Rigidbody2D>().AddForce(direction * firingSpeed);
        Destroy(projectileTemp, projectileLifeTime);
    }
}
