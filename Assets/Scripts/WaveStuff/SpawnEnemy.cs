/*
 * Copyright (c) 2017 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using UnityEngine;
using System.Collections;

[System.Serializable]
public class Wave
{
    public GameObject enemyPrefab;
    public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public float spawnInterval = 2;
    public int maxEnemies = 20;
}

public class SpawnEnemy : MonoBehaviour
{

    public GameObject[] waypoints;
    public GameObject testEnemyPrefab;
    public Wave[] waves;
    public int timeBetweenWaves = 5;
    [SerializeField] private int wave;
    private GameManagerBehavior gameManager;

    private float lastSpawnTime;
    [SerializeField]private int enemiesSpawned = 0;
    [SerializeField]private int enemiesSpawned2 = 0;
    [SerializeField]private int enemiesSpawned3 = 0;

    
    void Start()
    {
        //waypoints = GameObject.FindGameObjectsWithTag("Waypoint");
        Instantiate(testEnemyPrefab).GetComponent<MoveEnemy>().waypoints = waypoints;

        lastSpawnTime = Time.time;
        gameManager =
            GameObject.Find("GameManager").GetComponent<GameManagerBehavior>();
        wave = 1;
    }

   
    void Update()
    {

        //If you want to do anything about specific waves.....
        //
        // do " if(currentWave >= (wave))
        //         { stuff here }
        //
       

        // 1
        int currentWave = gameManager.Wave;
        if (currentWave < waves.Length)
        {
            // 2
            float timeInterval = Time.time - lastSpawnTime;
            float spawnInterval = waves[currentWave].spawnInterval;
            if (((enemiesSpawned == 0 && enemiesSpawned2 == 0 && timeInterval > timeBetweenWaves) ||
                 timeInterval > spawnInterval) &&
                enemiesSpawned < waves[currentWave].maxEnemies)
            {
                // 3  
                lastSpawnTime = Time.time;
                GameObject newEnemy = (GameObject)
                    Instantiate(waves[currentWave].enemyPrefab);
                if (waves[currentWave].enemyPrefab2 != null)
                {
                    GameObject newEnemy2 = (GameObject)Instantiate(waves[currentWave].enemyPrefab2);
                    newEnemy2.GetComponent<MoveEnemy>().waypoints = waypoints;
                    enemiesSpawned2++;
                }
                if (waves[currentWave].enemyPrefab3 != null)
                {
                    if (enemiesSpawned3 <= 3 || wave == 5)
                    {
                        GameObject newEnemy3 = (GameObject)Instantiate(waves[currentWave].enemyPrefab3);
                        newEnemy3.GetComponent<MoveEnemy>().waypoints = waypoints;
                        enemiesSpawned3++;
                    }
                    else if (enemiesSpawned3 <= 5 || wave == 7)
                    {
                        GameObject newEnemy3 = (GameObject)Instantiate(waves[currentWave].enemyPrefab3);
                        newEnemy3.GetComponent<MoveEnemy>().waypoints = waypoints;
                        enemiesSpawned3++;
                    }
                    else if (enemiesSpawned3 <= 7 || wave == 9)
                    {
                        GameObject newEnemy3 = (GameObject)Instantiate(waves[currentWave].enemyPrefab3);
                        newEnemy3.GetComponent<MoveEnemy>().waypoints = waypoints;
                        enemiesSpawned3++;
                    }
                    else if (enemiesSpawned3 <= 10 || wave == 10)
                    {
                        GameObject newEnemy3 = (GameObject)Instantiate(waves[currentWave].enemyPrefab3);
                        newEnemy3.GetComponent<MoveEnemy>().waypoints = waypoints;
                        enemiesSpawned3++;
                    }
                    
                }

                newEnemy.GetComponent<MoveEnemy>().waypoints = waypoints;
                enemiesSpawned++;
            }
            // 4 
            if (enemiesSpawned == waves[currentWave].maxEnemies &&
                GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                gameManager.Wave++; wave++;
                Debug.Log("Wave is " + gameManager.Wave);
                //gameManager.Gold = Mathf.RoundToInt(gameManager.Gold * 1.1f);
                enemiesSpawned = 0;
                enemiesSpawned2 = 0;
                enemiesSpawned3 = 0;
                lastSpawnTime = Time.time;
            }
            // 5 
        }
        else
        {
            gameManager.gameOver = true;
            //GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            //gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
        if (wave >= 10)
        {
            gameManager.gameWon = true;
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            gameManager.gameWon = true;
        }

    }

}
