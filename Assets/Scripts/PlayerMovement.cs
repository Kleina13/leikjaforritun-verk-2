using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb; // Creates a reference to the Rigidbody component
    public float FORCE = 100f; // Determines how much the player moves forward

    private bool m_IsOnGround;
 
    public bool IsOnGround
    {
        get
        {
            if (m_IsOnGround)
            {
                m_IsOnGround = false;
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    void OnCollisionStay(Collision collisionInfo)
    {
        m_IsOnGround = true;
        // Debug-draw all contact points and normals
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // If the up or w key is pressed the player will be moved forwards
        if ( Input.GetKey("w") | Input.GetKey("up") )
        {
            rb.AddForce(0, 0, FORCE * Time.deltaTime, ForceMode.VelocityChange); // Moves the player by what the FORCE variable equals
        }
        // If the down or s key is pressed the player will be moved backwards
        if ( Input.GetKey("s") | Input.GetKey("down") )
        {
            rb.AddForce(0, 0, -FORCE * Time.deltaTime, ForceMode.VelocityChange); // Moves the player by what the -FORCE variable equals
        }
        // If the right or d key is pressed the player will be moved to the right
        if ( Input.GetKey("d") | Input.GetKey("right") )
        {
            rb.AddForce(FORCE * Time.deltaTime, 0, 0, ForceMode.VelocityChange); // Moves the player by what the FORCE variable equals
        }
        // If the left or a key is pressed the player will be moved to the left
        if ( Input.GetKey("a") | Input.GetKey("left") )
        {
            rb.AddForce(-FORCE * Time.deltaTime, 0, 0, ForceMode.VelocityChange);// Moves the player by what the -FORCE variable equals
        }
        // Jump
        if ( Input.GetKeyDown(KeyCode.Space) )
        {
            if(IsOnGround)
            {
                rb.AddForce(0, 175 * Time.deltaTime, 0, ForceMode.Impulse);// Moves the player by what the -FORCE variable equals
            }
        }
        if ( rb.position.y <= -1f)
        {
            FindObjectOfType<GameManager>().GameOver();
        }
    }
}
