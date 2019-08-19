using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    #region Variables
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] AudioClip levelWinSound;
    [SerializeField] bool finalLevel = false;
    [SerializeField] int blockCount = 0;

    bool levelWon = false;
    #endregion
 

    #region Helper Methods
    public void RegisterBlock()
    {
        blockCount++;
    }

    public void BreakBlock()
    {
        blockCount--;
        if(blockCount <= 0)
        {
            if (!levelWon)
            {
                levelWon = true;
                AudioSource.PlayClipAtPoint(levelWinSound, Camera.main.transform.position);
                Invoke("EndLevel", .9f);
            }
        }
    }

    private void EndLevel()
    {
        if (!finalLevel)
        {
            FindObjectOfType<GameStatus>().UpDifficulty();
            sceneLoader.LoadNextScene();
        }
        else
            sceneLoader.LoadScene("Win");
    }
    #endregion
}
