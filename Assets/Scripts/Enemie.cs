using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public float Enemihealth;
    private int killReward; // Amount of XP or money 
    private int Damage; // Amount done on santa health bar
                        // Start is called before the first frame update

    private void Awake()
    {
        EnCount.enemies.Add(gameObject);
    }
    public void takeDamage(float ammount)
    {
        Enemihealth -= ammount;
        if (Enemihealth <= 0)
        {
            die("Enemy");
        }
        Debug.Log("owww");
    }
    private void die( string destroyTag)
    {
        EnCount.enemies.Remove(gameObject);
        GameObject[] destroyObject;
         destroyObject = GameObject.FindGameObjectsWithTag(destroyTag);
        foreach (GameObject oneObject in destroyObject)
            Destroy(oneObject);
        Debug.Log("I died");
    }

    private void Update()
    {
        takeDamage(0);
    }
}
