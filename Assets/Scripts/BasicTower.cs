using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTower : SnowballTower
{
    public GameObject Snowball;
    protected override void Shoot()
    {
        base.Shoot();

        GameObject newSnowball = Instantiate(Snowball);

        Debug.Log("Shoot");
    }
}
