using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioClip destroyClip;
    LevelControl level;
    GameStatus game;
    #endregion

    #region Main Methods
    private void Start()
    {
        game = FindObjectOfType<GameStatus>();
        level = FindObjectOfType<LevelControl>();
        level.RegisterBlock();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DestroyBlock();
    }
    #endregion

    #region Helper Methods
    private void DestroyBlock()
    {
        game.AddToScore();

        AudioSource.PlayClipAtPoint(destroyClip, Camera.main.transform.position);
        level.BreakBlock();
        Destroy(gameObject);
    }
    #endregion
}
