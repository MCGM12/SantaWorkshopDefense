using UnityEngine;
using System.Collections;

public class RunnerAttack : MonoBehaviour
{
    public GameObject[] gos;
    public float projSpeed;
    public GameObject projectile;
    public GameObject closestEnemy;
    public bool shoot1, shoot2, shoot3; //shoot1 is distance req, shoot2 is timer req, and shoot3 is if all reqs are satisfied
    private GameObject closest;
    public Transform target;
   

    public void Start()
    {
        projSpeed = 2f;
    }
    public void Update()
    {
        closestEnemy = closest;
        FindClosestEnemy();
        closestEnemy = closest;
        target = closestEnemy.transform;




        if (Vector2.Distance(this.transform.position, closestEnemy.transform.position) < 10)
        {
            Debug.Log("Elf Tower in sight.");
            shoot1 = true;
            RotateTowards(target.position);
        } else
        {
            shoot1 = false;
        }
        if (gos.Length <= 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }
        shoot3 = shoot1;
            if (shoot3)
            {
                GameObject newProj = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));
                newProj.transform.position = Vector2.MoveTowards(newProj.transform.position, closestEnemy.transform.position, 20);

            }
        
    }

    public GameObject FindClosestEnemy()
    {
        gos = GameObject.FindGameObjectsWithTag("Player");
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
    private void RotateTowards(Vector2 target)
    {
        var offset = 90f;
        Vector2 direction = target - (Vector2)transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle + offset));
    }
}