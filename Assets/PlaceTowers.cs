using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTowers : MonoBehaviour
{
    public GameObject TowersPrefab;
    private GameObject Tower;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool CanPlaceTower()
    {
        return Tower == null;
    }

    private void OnMouseUp()
    {
        if (CanPlaceTower())
        {
            Tower = (GameObject)
                Instantiate(TowersPrefab, transform.position, Quaternion.identity);

        }
    }
}
