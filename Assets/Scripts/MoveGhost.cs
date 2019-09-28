using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGhost : PhysicsObject
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rayCastOffset = 0.5f;
    [SerializeField] private float _rayCastDistance = 1f;
    PlayerPlatformerController player;
    public float _moveDir = 1;
    public Animator animator;
    public Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    public static bool isAttacking = false;
    public Transform target;//set target from inspector instead of looking in Update
    public Transform myTransform;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        animator = GetComponent<Animator>();
        myTransform = this.GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (player.seguir)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, _moveDir * Time.deltaTime);
            
        }
        else
        {
            Move();
        }
    }
  

    void TurnLeft()
    {
        //sets the movement direction to -1 to make the gameObject move left
        _moveDir = -1;
        spriteRenderer.flipX = true;
    }

    void TurnRight()
    {
        //sets the movement direction to 1 to make the gameObject move right
        _moveDir = 1;
        spriteRenderer.flipX = false;
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
