//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class WaveManagerMe : MonoBehaviour
//{
//    Wave w1, w2, w3, w4, w5, w6, w7, w8, w9, w10;
//    public bool gameStart, runnerDone, gumballDone, monsterDone, debugstartWave = false;
//    [SerializeField] private float runnerTimer, gumTimer, monsterTimer;
//    Wave currentWave;

//    Transform spawn;

//    private void Awake()
//    {
//        DefineWaves();
//    }

//    void DefineWaves() //Open for like 60 lines of code, this is absurdly long bcus im dumb but we dont have time to make it better... 
//    {
//        //Wave One
//        w1.EnemyCount = 10;
//        w1.runnerCount = 7;
//        w1.gumballCount = 3;

//        //Wave Two
//        w2.EnemyCount = 20;
//        w2.runnerCount = 15;
//        w2.gumballCount = 5;

//        //Wave Three
//        w3.EnemyCount = 30;
//        w3.runnerCount = 20;
//        w3.gumballCount = 9;
//        w3.monsterCount = 1;

//        //Wave Four
//        w4.EnemyCount = 45;
//        w4.runnerCount = 30;
//        w4.gumballCount = 15;


//        //Wave Five
//        w5.EnemyCount = 60;
//        w5.runnerCount = 38;
//        w5.gumballCount = 20;
//        w5.monsterCount = 2;

//        //Wave Six
//        w6.EnemyCount = 75;
//        w6.runnerCount = 45;
//        w6.gumballCount = 26;
//        w6.monsterCount = 4;

//        //Wave Seven
//        w7.EnemyCount = 90;
//        w7.runnerCount = 65;
//        w7.gumballCount = 25;

//        //Wave Eight
//        w8.EnemyCount = 120;
//        w8.runnerCount = 80;
//        w8.gumballCount = 40;

//        //Wave Nine
//        w9.monsterCount = 200;
//        w9.runnerCount = 100;
//        w9.gumballCount = 40;
//        w9.monsterCount = 10;

//        //Wave Ten
//        w10.EnemyCount = 200;
//        w10.runnerCount = 100;
//        w10.gumballCount = 75;
//        w10.monsterCount = 25;
//    }
//    void WaveLogic() //This will define what next wave is and all logic related stuff
//    {
//        if (currentWave.ended == true)
//        {
//            if (currentWave = w1)
//            {
//                currentWave = w2;
//            }
//            else if (currentWave = w2)
//            {
//                currentWave = w3;
//            }
//            else if (currentWave = w3)
//            {
//                currentWave = w4;
//            }
//            else if (currentWave = w4)
//            {
//                currentWave = w5;
//            }
//            else if (currentWave = w5)
//            {
//                currentWave = w6;
//            }
//            else if (currentWave = w6)
//            {
//                currentWave = w7;
//            }
//            else if (currentWave = w7)
//            {
//                currentWave = w8;
//            }
//            else if (currentWave = w8)
//            {
//                currentWave = w9;
//            }
//            else if (currentWave = w9)
//            {
//                currentWave = w10;
//            }
//        }
//        if (currentWave.ended == false)
//        {
//            //NOTE TO SELF: HOW TO DOCUMENT ENEMIES DESTROYED AND NEXT WAVE
//            //Need component on enemies that recognize when their health is 0, contact the WaveManager.currentWave and then subtract one from the enemy count.
//            //Once enemycount = 0, currentWave.ended == true;
//            if (currentWave.EnemyCount <= 0)
//            {
//                currentWave.ended = true;
//            }
//        }
//    }
//    void StartWave(Wave Wave, int EnemyCount, int RunnerCount, int GumballCount, int MonsterCount)
//    {

//        //Runner Spawn
//        if (RunnerCount > 0 && runnerDone == false)
//        {
//            //StartCoroutine(RunnerSpawn(runnerTimer, Wave.runnerPreset, currentWave.runnerCount));
//        }
//        else if (RunnerCount <= 0)
//        {
//            runnerDone = true;
//        }

//        //Gumball Spawn

//        //Monster Spawn
//    }
//    void Start()
//    {
//        spawn = gameObject.transform;
//    }


//    void Update()
//    {
//        if (debugstartWave)
//        {
//            StartWave(w1, w1.EnemyCount, w1.runnerCount, w1.gumballCount, w1.monsterCount);
//            InvokeRepeating("RunnerSpawn(Wave.runnerPreset, currentWave.runnerCount)", 1f, 1);
//        }
//        if (gameStart)
//        {
//            StartWave(w1, w1.EnemyCount, w1.runnerCount, w1.gumballCount, w1.monsterCount); //starts first wave
//        }
//        if (currentWave.ended)
//        {
//            WaveLogic(); //if wave is ended, run the logic to determine next
//        }
//    }

//    void RunnerSpawn(GameObject prefab, int reductable)
//    {

//        Instantiate(prefab, spawn.position, Quaternion.Euler(0, 0, 0));
//        reductable--;

//    }
//}
