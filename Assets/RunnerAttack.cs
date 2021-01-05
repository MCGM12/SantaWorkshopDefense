using UnityEngine;
using System.Collections;

public class RunnerAttack : MonoBehaviour
{
    public GameObject[] gos;

    public void Start()
    {
        
    }
    public void Update()
    {
        
    }

    public GameObject FindClosestEnemy()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
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