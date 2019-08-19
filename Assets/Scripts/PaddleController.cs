using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    #region Variables
    [SerializeField] float screenUnits = 15f;
    [SerializeField] float minX = -7.5f;
    [SerializeField] float maxX = 7.5f;

    // targeted components
    GameStatus game;
    BallController ball;
    #endregion

    #region Main Methods
    private void Start()
    {
        game = FindObjectOfType<GameStatus>();
        ball = FindObjectOfType<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePaddle();
    }
    #endregion

    #region Helper Methods
    private void MovePaddle()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);

        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if (game.isAutoplayEnabled())
        {
            return ball.transform.position.x;
        }
        else
        {
            return (Input.mousePosition.x / Screen.width * screenUnits) - screenUnits / 2;
        }
            
    }
    #endregion
}
