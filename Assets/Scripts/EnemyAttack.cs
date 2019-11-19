using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
  PlayerPlatformerController player;

  EnemyAttack enemy;
  public LayerMask layerEnemy;
  public Transform verifica;
  public float radiusAtack = 1.50f;
  private Transform target;
  public float distancia;
  public float timeNextAtack = 0f;
  public float naoEmpurra;
  SpriteRenderer spriteRenderer;
  public Animator animator;
  AudioSource audioData;

  bool damaged = false;

  HealthSystem healthSystem = new HealthSystem(100);

  // Health System
  public Transform pfHealthBar;

  GameObject[] enemies;




  void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
    audioData = GetComponent<AudioSource>();


    // health system

    // GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    // for (int i = 0; i < enemies.Length; i++)
    // {
    //   Vector3 pos = enemies[i].transform.position;
    //   Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(pos.x, pos.y + (float)0.5), Quaternion.identity);
    //   HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
    //   healthBar.Setup(healthSystem);

    //   healthBar.transform.parent = enemies[i].transform;
    // }



  }

  // Update is called once per frame
  void Update()
  {

    if (Vector2.Distance(transform.position, target.position) <= naoEmpurra)
    {

      if (player.flipar)
      {

        spriteRenderer.flipX = false;
        animator.Play("Ghost-Attack");

        InimigoAtack();
      }
      else if (player.flipar == false)
      {
        spriteRenderer.flipX = true;
        animator.Play("Ghost-Attack");

        InimigoAtack();
      }

    }
    else
    {
      animator.Play("Ghost");
    }
    Vector3 pos = this.transform.position;


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
        timeNextAtack = 1.1f;
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
    player.jamesDamaged(35);
  }


  public void enemyDamaged(int damage)
  {


    healthSystem.Damage(damage);

    damaged = true;
    Debug.Log("Damaged: " + healthSystem.GetHealthPercent());

    if (healthSystem.GetHealthPercent() <= 0)
    {
      audioData.Stop();
      Destroy(gameObject);
    }

    // testing healthBar
    Debug.Log("Health: " + healthSystem.GetHealthPercent());
    // healthSystem.Damage(50);
    // Debug.Log("Damaged: " + healthSystem.GetHealthPercent());
    // healthSystem.Heal(30);
    // Debug.Log("Healed: " + healthSystem.GetHealthPercent());

  }
}
