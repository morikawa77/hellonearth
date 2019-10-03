using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  PlayerPlatformerController player;
  public LayerMask layerEnemy;
  public Transform verifica;
  public float radiusAtack = 1.50f;
  private Transform target;
  public float distancia;
  public bool Atacando = false;
  float timeNextAtack;
  public float naoEmpurra;
  SpriteRenderer spriteRenderer;
  public Animator animator;
  // Start is called before the first frame update
  void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
  }

  // Update is called once per frame
  void Update()
  {
    if (Vector2.Distance(transform.position, target.position) <= naoEmpurra)
    {

      if (player.flipar)
      {

        spriteRenderer.flipX = false;
        animator.Play("Enemy-Attack");
        InimigoAtack();
      }
      else if (player.flipar == false)
      {
        spriteRenderer.flipX = true;
        animator.Play("Enemy-Attack");
        InimigoAtack();
      }

    }
    else
    {
      animator.Play("Enemy");
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
        timeNextAtack = 5f;
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
    player.jamesDamaged(10);
  }
}
