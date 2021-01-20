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
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerBehavior : MonoBehaviour
{

    public Text goldLabel;
    private int gold;
    public Text waveLabel;
    public GameObject gameOverImage;
    //public GameObject[] nextWaveLabels;
    public bool gameOver = false;
    public bool gameWon = false;
    public Text gameOverText;
    public Text gameOverText2;
    public Text waveText;
    
    public Sprite healthUI1, healthUI2, healthUI3, healthUI4, healthUI5, healthUI6, healthUI7, healthUI8, healthUI9, healthUI10;
    public Image healthUI;

    public int Gold
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
            //goldLabel.GetComponent<Text>().text = "GOLD: " + gold;
        }
    }
    private int wave;
    public int Wave
    {
        get
        {
            return wave;
        }
        set
        {
            wave = value;
            if (!gameOver)
            {
                //for (int i = 0; i < nextWaveLabels.Length; i++)
                //{
                //    nextWaveLabels[i].GetComponent<Animator>().SetTrigger("nextWave");
                //}
            }
            //waveLabel.text = "WAVE: " + (wave + 1);
        }
    }
    public Text healthLabel;
    public GameObject[] healthIndicator;

    [SerializeField]private int health;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            //healthLabel.text = "HEALTH: " + health;
            // 3
            if (health <= 0) // && !gameOver)
            {
                gameOver = true;
               
                gameOverText.text = "GAME OVER";
                gameOverText2.text = "Press R to Retry, M for main Menu"; 
                Debug.Log("Ruh roh, no health left");
                GameObject gameManager = GameObject.Find("GameManager");
                gameManager.GetComponent<SpawnEnemy>().enabled = false;

                
            }
            // 4 
            for (int i = 0; i < healthIndicator.Length; i++)
            {
                if (i < Health)
                {
                    healthIndicator[i].SetActive(true);
                }
                else
                {
                    healthIndicator[i].SetActive(false);
                }
            }
        }
    }



    // Use this for initialization
    void Start()
    {
        //gameOverText = GameObject.FindGameObjectWithTag("GameOver");
        Wave = 0;
        Health = 10;
        gameOver = false;
        Gold = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameWon)
        {
            gameOverText.text = "GAME WON!";
            gameOverText2.text = "Press R to Replay, M for main Menu";
            Time.timeScale = 0.0f;
        }
        if(health == 10)
        {
            healthUI.sprite = healthUI10;
        }
        else if (health == 9)
        {
            healthUI.sprite = healthUI9;
        }
        else if (health == 8)
        {
            healthUI.sprite = healthUI8;
        }
        else if (health == 7)
        {
            healthUI.sprite = healthUI7;
        }
        else if (health == 6)
        {
            healthUI.sprite = healthUI6;
        }else if (health == 5)
        {
            healthUI.sprite = healthUI5;
        }
        else if(health == 4)
        {
            healthUI.sprite = healthUI4;
        }
        else if(health == 3)
        {
            healthUI.sprite = healthUI3;
        }
        else if(health == 2)
        {
            healthUI.sprite = healthUI2;
        }
        else if(health == 1)
        {
            healthUI.sprite = healthUI1;
        }



        if (gameOver)
        {
            //gameOverImage.SetActive(true);
            //audio stuff if time?
        }
    }

}
