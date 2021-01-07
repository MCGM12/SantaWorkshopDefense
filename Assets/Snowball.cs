using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball : MonoBehaviour
{
    private void Update()
    {
        
        transform.position += transform.right * 0.25f;

        Debug.Log("KOBE");
    }
}
