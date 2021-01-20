using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowballTower : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float damage;
    [SerializeField] private float TimeBetweenShots; //How long it takes to shot and to shoot again 
    [SerializeField] private float NextTimeToShoot;
    GameObject[] gos;
    private GameObject closest;

    public GameObject currentTarget;
    public GameObject snowball;
    private void Start()
    {
        NextTimeToShoot = Time.time;
    }




    public GameObject FindClosestEnemy()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    protected virtual void Shoot()
    {
        Debug.Log("Shoot");
        GameObject newSnowBall = Instantiate(snowball);
        Vector3 startPosition = gameObject.transform.position;
        Vector3 endPosition = currentTarget.transform.position;
        newSnowBall.transform.position = Vector2.Lerp(startPosition, endPosition, 1);
        if(this.tag == "SnowballShooter")
        {
            newSnowBall.GetComponent<Snowball>().snowball = true;
        }
        else if (this.tag == "FastShooter")
        {
            newSnowBall.GetComponent<Snowball>().fast = true;
        }
        
       
        
        
    }


    public void Update()
    {
        FindClosestEnemy();
        currentTarget = closest;

        if(Time.time >= NextTimeToShoot && Vector2.Distance(transform.position, currentTarget.transform.position) <= range)
        {
            if (currentTarget != null)
            {
                Shoot();
                NextTimeToShoot = Time.time + TimeBetweenShots;
            }
        }
    }
}