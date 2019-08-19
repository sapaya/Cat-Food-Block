using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    #region Variables
    [Range(0.1f, 5f)]
    [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlock = 15;

    // state variables
    [SerializeField] bool autoplayEnabled = false;
    [SerializeField] int currentScore = 0;
    Score scoreText;

    protected static GameStatus _instance;
    private const float difficultyIncrease = .1f;
    #endregion

    #region Main Methods
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            gameObject.SetActive(false); //Destroy is called last, so prevent this from being used
            Destroy(gameObject);
        }
        else {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        scoreText = FindObjectOfType<Score>();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;
    }
    #endregion

    #region Helper Methods

    public void AddToScore()
    {
        currentScore += pointsPerBlock;
        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        scoreText.UpdateScore(currentScore);
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public void PullScore(Score scoreDisplay)
    {
        scoreDisplay.UpdateScore(currentScore);
    }

    public bool isAutoplayEnabled()
    {
        return autoplayEnabled;
    }

    public void UpDifficulty()
    {
        gameSpeed += difficultyIncrease;
    }
    #endregion
}
