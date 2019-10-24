using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHead : MonoBehaviour
{
    private bool colide = false;
    public float speed = -2;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    PlayerPlatformerController player;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
          spriteRenderer = GetComponent<SpriteRenderer>();
          player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
          animator = GetComponent<Animator>();
          

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(verifica.position, distanciaMov);
    //}

    //void TurnLeft()
    //{
    //    //sets the movement direction to -1 to make the gameObject move left
    //    _moveDir = -1;
    //    spriteRenderer.flipX = true;
    //}

    //void TurnRight()
    //{
    //    //sets the movement direction to 1 to make the gameObject move right
    //    _moveDir = 1;
    //    spriteRenderer.flipX = false;
    //}

    //public void Move()
    //{
    //    //Setting up the start position of both raycasts
    //    Vector2 rayCastOriginRight = transform.position + new Vector3(_rayCastOffset, 0, 0);
    //    //Only difference is that we flip the rayCastOffset because we want it to point towards the left, therefore the "-" in front
    //    Vector2 rayCastOriginLeft = transform.position + new Vector3(-_rayCastOffset, 0, 0);

    //    //Moves the Gameobject every frame based on the _moveDir variable;
    //    //transform.Translate(new Vector2(_moveDir * _speed * Time.deltaTime, 0));
    //    transform.Translate(new Vector2(_moveDir * _speed * Time.deltaTime, 0));


    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{

    //    if (collision.gameObject.CompareTag("virar"))
    //    {


    //        if (_moveDir == 1)
    //        {
    //            TurnLeft();
    //        }
    //        else if (_moveDir == -1)
    //        {
    //            TurnRight();
    //        }
    //    }


    //}
}
