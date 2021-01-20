using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    public bool snowball, fast;
    Rigidbody2D rb2;
    public Vector3 startPos, endPos;
    public float moveSpeed;
    private bool atEnd;
    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, endPos, moveSpeed * Time.deltaTime);
        if(transform.position == endPos)
        {
            atEnd = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (fast)
        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<MoveEnemy>().health--;
                Destroy(gameObject);
            }
        } else if (snowball)
        {
            if (collision.tag == "Enemy")
            {
                collision.gameObject.GetComponent<MoveEnemy>().health -= 2;
                Destroy(gameObject);
            }
        }
        if(collision == null && atEnd == true)
        {
            Destroy(gameObject);
        }
       
    }

  
}
