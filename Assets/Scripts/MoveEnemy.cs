﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : PhysicsObject
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rayCastOffset = 0.5f;
    [SerializeField] private float _rayCastDistance = 1f;
    PlayerPlatformerController player;
    private float _moveDir = 1;
    SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rb;

    public static bool isAttacking = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<PlayerPlatformerController>();
        animator = GetComponent<Animator>();
    }



    void Update()
    {
        Move();
        if (isAttacking)
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }
    void FixedUpdate()
    {
        if (!isAttacking)
        {
            rb.velocity = new Vector2(_moveDir * _speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
    void TurnLeft()
    {
        //sets the movement direction to -1 to make the gameObject move left
        _moveDir = -1;
        spriteRenderer.flipX = false;
    }

    void TurnRight()
    {
        //sets the movement direction to 1 to make the gameObject move right
        _moveDir = 1;
        spriteRenderer.flipX = true;
    }

    public void Move()
    {
        //Setting up the start position of both raycasts
        Vector2 rayCastOriginRight = transform.position + new Vector3(_rayCastOffset, 0, 0);
        //Only difference is that we flip the rayCastOffset because we want it to point towards the left, therefore the "-" in front
        Vector2 rayCastOriginLeft = transform.position + new Vector3(-_rayCastOffset, 0, 0);

        //Moves the Gameobject every frame based on the _moveDir variable;
        //transform.Translate(new Vector2(_moveDir * _speed * Time.deltaTime, 0));
        transform.Translate(new Vector2(_moveDir * _speed * Time.deltaTime, 0));


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("virar"))
        {
            if (_moveDir == 1)
            {
                TurnLeft();
            }
            else if (_moveDir == -1)
            {
                TurnRight();
            }
        }
    }

}
