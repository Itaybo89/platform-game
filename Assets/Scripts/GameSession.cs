using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSession : MonoBehaviour
{
    [SerializeField] float deathLoadDelay = 3f;
    [SerializeField] int playerLives = 3;
    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] TextMeshProUGUI scoreText;
    CoinPicup coinPicup;
    int coinScore = 0;
    
    
    void Awake()
    {
        int numGameSessions = FindObjectsOfType<GameSession>().Length;
        if ( numGameSessions > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start() 
    {
        coinPicup = FindObjectOfType<CoinPicup>();
        livesText.text = playerLives.ToString();
        scoreText.text = playerLives.ToString();

        
    }

    public void ProcessPlayerDeath()
    {
        if (playerLives > 1)
        {
            Debug.Log("coroutine");
            StartCoroutine(TakeLife());
            
        }
        else
        {
            Debug.Log("Resetgamesession");
            ResetGameSession();
        }
    }

    void ResetGameSession()
    {
        FindObjectOfType<ScenePersist>().ResetScenePersist();
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    
    IEnumerator TakeLife()
    {

        livesText.text = playerLives.ToString();
        yield return new WaitForSecondsRealtime(deathLoadDelay);
        playerLives--;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
        livesText.text = playerLives.ToString();
    }

   public void CoinScoreIncrease(int coinValue)
    {
        coinScore += coinValue;
        scoreText.text = coinScore.ToString();
    }
   
}