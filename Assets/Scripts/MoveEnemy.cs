using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rayCastOffset = 0.5f;
    [SerializeField] private float _rayCastDistance = 1f;

    private float _moveDir = 1;


    void Update()
    {
        Move();
    }

    void TurnLeft()
    {
        //sets the movement direction to -1 to make the gameObject move left
        _moveDir = -1;
    }

    void TurnRight()
    {
        //sets the movement direction to 1 to make the gameObject move right
        _moveDir = 1;
    }

    void Move()
    {
        //Setting up the start position of both raycasts
        Vector2 rayCastOriginRight = transform.position + new Vector3(_rayCastOffset, 0, 0);
        //Only difference is that we flip the rayCastOffset because we want it to point towards the left, therefore the "-" in front
        Vector2 rayCastOriginLeft = transform.position + new Vector3(-_rayCastOffset, 0, 0);

        if (Physics2D.Raycast(rayCastOriginRight, Vector2.right, _rayCastDistance))
        {
            TurnLeft();
        }
        if (Physics2D.Raycast(rayCastOriginLeft, Vector2.left, _rayCastDistance))
        {
            TurnRight();
        }
       
        //Moves the Gameobject every frame based on the _moveDir variable;
        transform.Translate(new Vector2(_moveDir * _speed * Time.deltaTime, 0));


        //Debug rays to visualize the raycasts, can be deleted, has no impact on gameplay;
        Debug.DrawRay(rayCastOriginRight, Vector2.right * _rayCastDistance, Color.red);
        Debug.DrawRay(rayCastOriginLeft, Vector2.left * _rayCastDistance, Color.blue);
    }
}
