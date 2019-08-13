using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    #region Variables
    [SerializeField] float screenUnits = 15f;
    [SerializeField] float minX = -7.5f;
    [SerializeField] float maxX = 7.5f;
    #endregion

    #region Main Methods
    // Update is called once per frame
    void Update()
    {
        float mousePosX = Input.mousePosition.x / Screen.width * screenUnits;
        Vector2 paddlePos = new Vector2(mousePosX - screenUnits/2, transform.position.y);
        paddlePos.x = Mathf.Clamp(paddlePos.x, minX, maxX);

        transform.position = paddlePos;
    }
    #endregion
}
