using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameHead : MonoBehaviour
{
    FlameHead enemy;
    public LayerMask layerEnemy;
    public Transform verifica;
    public float radiusAtack = 1.50f;
    private bool colide = false;
    public float speed = -2;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    PlayerPlatformerController player;
    public float timeNextAtack = 0.5f;
    Animator animator;
    private Transform target;
    public float naoEmpurra;
    // Start is called before the first frame update
    void Start()
    {
          rb = GetComponent<Rigidbody2D>();
          spriteRenderer = GetComponent<SpriteRenderer>();
          player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
          animator = GetComponent<Animator>();
          target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
        if (colide)
        {
            flip();
        }

        if (Vector2.Distance(transform.position, target.position) <= naoEmpurra)
        {

            if (player.flipar)
            {

                spriteRenderer.flipX = true;
                animator.Play("Enemy-Attack");

                InimigoAtack();
            }
            else if (player.flipar == false)
            {
                spriteRenderer.flipX = false;
                animator.Play("Enemy-Attack");

                InimigoAtack();
            }

        }
        else
        {
            animator.Play("Enemy");
        }
    }
    private void flip()
    {
        speed *= -1;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        colide = false;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("virar"))
        {
            colide = true;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verifica.position, radiusAtack);
    }
    void InimigoAtack()
    {
        Collider2D[] enimiesAttack = Physics2D.OverlapCircleAll(verifica.position, radiusAtack, layerEnemy);
        for (int i = 0; i < enimiesAttack.Length; i++)
        {

            if (timeNextAtack <= 0)
            {
                Debug.Log(enimiesAttack[i].name);
                timeNextAtack = 0.5f;
                InimigoAttackHandler();
            }
            else
            {
                timeNextAtack -= Time.deltaTime;
            }
        }
    }

    public void InimigoAttackHandler()
    {
        Debug.Log("James recebeu ataque");
        player.jamesDamaged(25);
    }

}
