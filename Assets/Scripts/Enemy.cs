using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    float distancia = 0.6f;
    public float naoEmpurra;
    public float naoEmpurra2;
    private Transform target;
    PlayerPlatformerController player;
    //AtaqueInimigo ataque;
    Animator animator;
    SpriteRenderer sript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        animator = GetComponent<Animator>();
        sript = GetComponent<SpriteRenderer>();
        //ataque = GetComponent<AtaqueInimigo>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.position) < distancia)
        {
            if (Vector2.Distance(transform.position, target.position) > naoEmpurra)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (player.ladodireito)
                {
                    animator.Play("Enemy");
                    sript.flipX = false;
                }
                else if (player.ladoEsquerdo)
                {
                    animator.Play("Enemy");
                    sript.flipX = true;
                }
            }
            else
            {
                if (player.ladodireito && Vector2.Distance(transform.position, target.position) <= naoEmpurra2)
                {
                    animator.Play("Enemy");
                    sript.flipX = true;
                }
                else if (player.ladoEsquerdo && Vector2.Distance(transform.position, target.position) <= naoEmpurra2)
                {
                    animator.Play("enemy");
                    sript.flipX = false;
                }
            }
        }
    }
}
