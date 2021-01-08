using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        Debug.Log("Get Sniped ");
    }
    private void Update()
    {
        
        transform.position += transform.right * 0.25f;

        Debug.Log("KOBE");
    }
}
