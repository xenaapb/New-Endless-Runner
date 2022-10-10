using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject groundchecker;
    public LayerMask whatIsGround;

    float maxSpeed = 15.0f;
    bool isOnGround = false;
    bool doubleJump = false;


    //Create a reference to the Rigidbody2D so we can manipulate it
    Rigidbody2D playerObject;


    // Start is called before the first frame update
    void Start()
    {
        //Find the RigidBody2D component that is attached to the same object as this script
        playerObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            maxSpeed = 10.0f;
        } else
        {
            maxSpeed = 5.0f;
        }

        //Create a 'float' that will be equal to the players horizontal input


        //Set movementValueX to 1.0f, so that we always run forward and no longer care about player input
        float movementValueX = 1.0f;

        //Change the X velocity of the Rigidbody2D to be equal to the movement value
        playerObject.velocity = new Vector2(movementValueX * maxSpeed, playerObject.velocity.y);

        //Check to see if the ground object is touching the ground 
        isOnGround = Physics2D.OverlapCircle(groundchecker.transform.position, 0.0100f, whatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround == true)
        {
            playerObject.AddForce(new Vector2(0.0f, 350.0f));
        } 
        else if (Input.GetKeyDown(KeyCode.Space) && isOnGround == false && doubleJump == false)
        {
            playerObject.velocity = new Vector2(0f, 0f);
            playerObject.AddForce(new Vector2(0.0f, 350.0f));
            doubleJump = true;
        }

        if (isOnGround == true)
        {
            doubleJump = false;
        }

    }
}