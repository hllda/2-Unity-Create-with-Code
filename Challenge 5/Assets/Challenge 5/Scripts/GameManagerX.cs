using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerX : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public GameObject gameOverScreen;
    public Button restartButton;

    public List<GameObject> targetPrefabs;

    private int time = 60;
    private int score = 0;
    private float spawnRate = 2f;
    public bool isGameActive;  

    public int difficultyScreen;

    private float spaceBetweenSquares = 2.5f; 
    private float minValueX = -3.75f; //  x value of the center of the left-most square
    private float minValueY = -3.75f; //  y value of the center of the bottom-most square
    
    // Start the game, remove title screen, reset score, and adjust spawnRate based on difficulty button clicked
    public void StartGame(int difficulty)
    {
        difficultyScreen = difficulty;
        spawnRate /= difficulty;
        isGameActive = true;

        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        titleScreen.SetActive(false);

        InvokeRepeating("UpdateTime", 1.0f, 1.0f);
    }

    public void Update()
    {
        scoreText.text = "Score: " + score;
        timerText.text = "Time: " + time;
    }

    // While game is active spawn a random target
    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targetPrefabs.Count);

            if (isGameActive)
            {
                Instantiate(targetPrefabs[index], RandomSpawnPosition(), targetPrefabs[index].transform.rotation);
            }            
        }
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;
    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex()
    {
        return Random.Range(0, 4);
    }

    // Update score with value from target clicked
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if(score < 0)
        {
            score = 0;
        }

        scoreText.text = "Score: " + score;
    }

    public void UpdateTime()
    {
        if (time > 0)
        {
            time--;
        }

        if (time <= 0)
        {
            GameOver();
        }
    }

    // Stop game, bring up game over text and restart button
    public void GameOver()
    {
        CancelInvoke("UpdateTime");
        gameOverScreen.gameObject.SetActive(true);
        isGameActive = false;
    }

    // Restart game by reloading the scene
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  

}