using UnityEngine;
using System.Collections;

public class RunnerAttack : MonoBehaviour
{
    public GameObject[] gos;
    public float projSpeed;
    public GameObject projectile;
    public GameObject closestEnemy;
    public bool shoot1, shoot2; //shoot1 is distance req & shoot2 is timer req
    private GameObject closest;
    public Transform target;
    public float timeLeft = 2f;
    [SerializeField] private float range;
   

    public void Start()
    {
        range = 6f;
        projSpeed = 2f;
        shoot2 = false;
    }
    public void FixedUpdate()
    {
        closestEnemy = closest;
        FindClosestEnemy();

        target = closestEnemy.transform;

        //Timer Stuffs

        if(shoot2 == false)
        {
            timeLeft -= Time.deltaTime;
        }
        if(timeLeft <= 0)
        {
            shoot2 = true;
            if(shoot2)
            {
                timeLeft = 2f;
            }
        }



        //timeLeft -= Time.deltaTime;
        //if (timeLeft < 0)
        //{
        //    shoot2 = true;
        //} 
        //if (timeLeft < 0 && shoot2 == false)
        //{
        //    timeLeft = 2f;
        //}


        if (Vector2.Distance(this.transform.position, closestEnemy.transform.position) < range)
        {
            Debug.Log("Elf Tower in sight.");
            shoot1 = true;
            //RotateTowards(target.position);
        } else
        {
            shoot1 = false;
        }

        if (gos.Length <= 0)
        {
            transform.rotation = Quaternion.Euler(Vector3.zero);
        }

        if (shoot1 == true && shoot2 == true)
        {
            GameObject newProj = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));
            Rigidbody2D rb = newProj.GetComponent<Rigidbody2D>();
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0;
            rb.tag = "Projectile";
            rb.velocity = (closestEnemy.transform.position - transform.position).normalized * 5;
            Destroy(newProj, 3);
            shoot2 = false;
            
        }
        //if(shoot2 == false)
        //{
        //    StartCoroutine(Timer(1.5f, shoot2));
        //}
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

    public IEnumerator Timer(float time, bool change)
    {
        yield return new WaitForSeconds(time);
        change = true;
    }
}