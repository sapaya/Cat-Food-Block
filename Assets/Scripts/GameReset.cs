using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameReset : MonoBehaviour
{
    #region Variables
    [SerializeField] Score finalScore;
    #endregion

    #region Main Methods
    // Start is called before the first frame update
    void Start()
    {
        ResetGame();
    }
    #endregion

    #region Helper Methods
    void ResetGame()
    {
        GameStatus game = FindObjectOfType<GameStatus>();
        if (game == null)
            return;

        game.PullScore(finalScore);
        game.ResetGame();
    }
    #endregion
}
