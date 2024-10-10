using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    //Handles the X and Y movement of the player
    private void PlayerMove()
    {
        float horizontalInput = (Input.GetAxis("Horizontal") * Time.deltaTime * speed) + transform.position.x;
        float verticalInput = (Input.GetAxis("Vertical") * Time.deltaTime * speed) + transform.position.y;
        
        transform.position = PlayerWithinBounds(ref horizontalInput, ref verticalInput);
    }

    //Sets the bounds for the movement
    private Vector3 PlayerWithinBounds(ref float xMove, ref float yMove)
    {
        Vector3 screenMinBounds = Camera.main.ScreenToWorldPoint(new Vector3(0f,0f,Camera.main.nearClipPlane));
        Vector3 screenMaxBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height,Camera.main.nearClipPlane));

        float newX = Mathf.Clamp(xMove, screenMinBounds.x, screenMaxBounds.x);
        float newY = Mathf.Clamp(yMove, screenMinBounds.y, screenMaxBounds.y);

        return new Vector3(newX, newY, 0f);
    }
}
