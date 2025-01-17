﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Teleporter : MonoBehaviour
{
    public AudioClip winSound;
    public int index;
    CheckpointSystem checkpoint;
    CheckpointSystem nextCheckPoint;
    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    public Sprite onSprite;
    public Sprite offSprite;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
        circleCollider.isTrigger = true;
        checkpoint = Respawner.instance.GetCheckpointSystem(index);
        if (index < 17)
        {
            nextCheckPoint = Respawner.instance.GetCheckpointSystem(index + 1);
        }

    }

    private void FixedUpdate()
    {
        spriteRenderer.sprite = (checkpoint.reciever.gameObject.activeSelf) ? offSprite : onSprite;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            if (checkpoint.reciever.gameObject.activeSelf == false)
            {
                if (Respawner.instance.CompleteLetter())
                {
                    collision.GetComponent<PlayerController>().transform.position = nextCheckPoint.spawnpoint.transform.position;
                    
                }
                AudioManager.instance.PlaySFX(winSound);
                gameObject.SetActive(false);

            }          
        }
    }
}
