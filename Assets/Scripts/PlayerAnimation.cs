﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private PlayerController playerController;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        if (playerController.direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (playerController.direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
       // spriteRenderer.flipX = (playerController.direction.x > 0) ? false : true;
        animator.SetFloat("speed", playerController.direction.magnitude);
    }
}
