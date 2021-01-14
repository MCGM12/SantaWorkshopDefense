using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    Rigidbody2D rb2;
    private void Start()
    {
        //Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Get Sniped ");
    }
    private void Update()
    {
        if (rb2.bodyType == RigidbodyType2D.Static && tag == "projectile")
        {
            rb2.bodyType = RigidbodyType2D.Dynamic;
            rb2.gravityScale = 0;
        }
        //transform.position += transform.right * 0.25f;

        //Debug.Log("KOBE");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
