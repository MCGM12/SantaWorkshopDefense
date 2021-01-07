using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : SnowballTower
{
    public Transform pivot;
    public Transform barrel;
    public GameObject Snowball;
    protected override void Shoot()
    {
        base.Shoot();

        GameObject newSnowball = Instantiate(Snowball,barrel.position,pivot.rotation);
        

        Debug.Log("Shoot");
    }
}
