using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject hazard1;
    public GameObject hazard2;
    public GameObject hazard3;
    public GameObject enemy;

    public Vector3 spawnValues;
    
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public Text ScoreText;
    public Text RestartText;
    public Text GameOverText;
    private int score;
    public Text winText;


    private bool gameOver;
    private bool restart;


    private void Start()
    {
        gameOver = false;
        restart = false;
        RestartText.text = "";
        GameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }


   void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);
                Instantiate(enemy, spawnPostion, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }


            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard1, spawnPostion, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
                for (int i = 0; i < hazardCount; i++)
                {
                    Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard2, spawnPostion, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }

            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard3, spawnPostion, spawnRotation);

                yield return new WaitForSeconds(spawnWait);
            }

            


            if (gameOver)
            {
                RestartText.text = "Press 'F' to Restart";
                restart = true;
                break;
            }
        }
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();

        if (score >= 100)
        {
            winText.text = "You win, Created by Jeff Fox!";
            gameOver = true;
            restart = true;
        }
    }

    void UpdateScore()
    {
        ScoreText.text = "Points: " + score;

    }

    public void GameOver()
    {
        GameOverText.text = "Game Over!";
        gameOver = true;

    }





}