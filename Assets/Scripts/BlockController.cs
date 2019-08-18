using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BlockController : MonoBehaviour
{
    #region Variables
    [SerializeField] AudioClip destroyClip;
    [SerializeField] GameObject destroyEffect;
    [SerializeField] Sprite[] hitSprites;

    LevelControl level;
    GameStatus game;

    //states
    int maxHit;
    int timesHit = 0;
    #endregion

    #region Main Methods
    private void Start()
    {
        maxHit = hitSprites.Length + 1;
        game = FindObjectOfType<GameStatus>();
        CountBlock();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(tag == "Breakable")
        {
            HandleHit();
        }
        
    }
    #endregion

    #region Helper Methods
    private void CountBlock()
    {
        if (tag == "Breakable")
        {
            level = FindObjectOfType<LevelControl>();
            level.RegisterBlock();
        }
    }

    private void HandleHit()
    {
        timesHit++;
        if(timesHit >= maxHit)
        {
            BreakBlock();
        }
        else
        {
            DamageBlock();
        }
    }

    private void DamageBlock()
    {
        if(timesHit <= hitSprites.Length)
        {
            int spriteIndex = timesHit - 1;
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block sprite missing from " + gameObject.name);
        }

        TriggerDestroyVFX();
    }

    private void BreakBlock()
    {
        game.AddToScore();
        AudioSource.PlayClipAtPoint(destroyClip, Camera.main.transform.position);
        level.BreakBlock();
        Destroy(gameObject);
        TriggerDestroyVFX();
    }

    private void TriggerDestroyVFX()
    {
        GameObject destroyBurst = Instantiate(destroyEffect, transform.position, transform.rotation);
        Destroy(destroyBurst, 1f);
    }
    #endregion
}
