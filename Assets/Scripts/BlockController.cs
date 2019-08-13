using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    #region Variables
    #endregion

    #region Main Methods
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
    #endregion

    #region Helper Methods
    #endregion
}
