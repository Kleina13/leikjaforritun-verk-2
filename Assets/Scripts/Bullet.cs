using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed=20f;
    public Rigidbody rb;
    public int damage = 10;
    void Start()
    {
       // rb.velocity = transform.forward  * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {  
        if (collision.collider.tag=="ovinur")
        {
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
        else if (collision.collider.name != "Player")
        {
            gameObject.SetActive(false);
        }
    }   
}
