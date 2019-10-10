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
  public float timeNextAtack = 0.5f;
  public float naoEmpurra;
  SpriteRenderer spriteRenderer;
  public Animator animator;

  bool enemyDamage = false;

  HealthSystem healthSystem = new HealthSystem(100);

  // Health System
  public Transform pfHealthBar;

  void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();

    // health system
    enemy = GameObject.FindWithTag("Enemy").GetComponent<EnemyAttack>();
    Vector3 pos = enemy.transform.position;
    // Debug.Log(pos);

    Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(pos.x, pos.y + (float)0.5), Quaternion.identity);
    HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
    healthBar.Setup(healthSystem);

    healthBar.transform.parent = enemy.transform;

    // testing healthBar
    // Debug.Log("Health: " + healthSystem.GetHealthPercent());
    // healthSystem.Damage(50);
    // Debug.Log("Damaged: " + healthSystem.GetHealthPercent());
    // healthSystem.Heal(30);
    // Debug.Log("Healed: " + healthSystem.GetHealthPercent());
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
        timeNextAtack = 2f;
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


  public void enemyDamaged(int damage)
  {
    healthSystem.Damage(damage);

    enemyDamage = true;
    Debug.Log("Enemy Damaged: " + healthSystem.GetHealthPercent());
    if (healthSystem.GetHealthPercent() == 0)
    {
      Destroy(GameObject.FindGameObjectWithTag("Enemy"));
      //SceneManager.LoadScene("GameOver");
    }

    // if (damaged == true)
    // {
    //   animator.Play("James-Hurt");
    //   damaged = false;
    // }
    // animator.Play("James-Idle");
  }
}
