using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballTower : MonoBehaviour
{
    [SerializeField]  private float range;
   [SerializeField] private float damage;
    [SerializeField] private float TimeBetweenShots; //How long it takes to shot and to shoot again 
    [SerializeField ]private float NextTimeToShoot;

    public GameObject currentTarget;
    private void Start()
    {
        NextTimeToShoot = Time.time;
    }



    public void UdateNearestEnemy()
    {
        GameObject CurrentNearestEnemy = null;
        float distance = Mathf.Infinity;

        foreach( GameObject enemy in EnCount.enemies)
        {
            float _distance = (transform.position - enemy.transform.position).magnitude;
            if (_distance < distance)
            {
                distance = _distance;
                CurrentNearestEnemy = enemy;
            }
        }
        if (distance <= range)
        {
            currentTarget = CurrentNearestEnemy;
            Debug.Log("FOUnd YOu");
        }
        else
        {
            currentTarget = null; 
        }
        
    }
   protected virtual void Shoot()
    {
     
        
            Enemie enemyScript = currentTarget.GetComponent<Enemie>();

            enemyScript.takeDamage(damage);
        Debug.Log("Shoot");
        
    }


    private void Update()
    {
        UdateNearestEnemy();
        if(Time.time >= NextTimeToShoot)
        {
            if (currentTarget != null)
            {
                Shoot();
                NextTimeToShoot = Time.time + TimeBetweenShots;
            }
        }
    }
}