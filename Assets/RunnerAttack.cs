using UnityEngine;
using System.Collections;

public class RunnerAttack : MonoBehaviour
{
    public GameObject[] gos;
    public float projSpeed;
    public static GameObject projectile;
    public GameObject closestEnemy;
    public bool shoot1, shoot2, shoot3; //shoot1 is distance req, shoot2 is timer req, and shoot3 is if all reqs are satisfied
    private GameObject closest;
   

    public void Start()
    {
        projSpeed = 2f;
    }
    public void Update()
    {
        closestEnemy = closest;
        FindClosestEnemy();
        closestEnemy = closest;




        if (Vector2.Distance(this.transform.position, closestEnemy.transform.position) < 10)
        {
            Debug.Log("Elf Tower in sight. Sending an Alma.");
            shoot1 = true;
        }

        if(shoot3)
        {
            GameObject newProj = GameObject.Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));
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
}