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
    [SerializeField] int currentScore = 0;
    Score scoreText;

    #endregion

    #region Main Methods
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
    #endregion
}
