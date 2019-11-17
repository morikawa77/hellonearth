using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
  // Enemies
  public GameObject[] ghost;
  public GameObject[] flameHead;
  public GameObject[] angel;
  public GameObject demian;

  public string enemyType;

  // Health System
  public Transform pfHealthBar;
  public HealthBar hb;
  HealthSystem healthSystem = new HealthSystem(100);

  bool damaged = false;


  SpriteRenderer spriteRenderer;

  public Animator animator;
  AudioSource audioData;

  PlayerPlatformerController player;

  private Transform target;

  public float naoEmpurra;

  public Transform verifica;

  public float radiusAtack = 1.50f;

  public float timeNextAtack = 0.5f;

  public LayerMask layerEnemy;


  void Awake()
  {
    if (SceneManager.GetActiveScene().name == "City")
    {
      Instantiate(flameHead[0], new Vector3(3f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(flameHead[1], new Vector3(8f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(flameHead[2], new Vector3(19f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(flameHead[3], new Vector3(27f, -3.451712f, 0.0625f), Quaternion.identity);
    }
    if (SceneManager.GetActiveScene().name == "Cemetery")
    {
      Instantiate(ghost[0], new Vector3(-1.4f, -1.94f, 0f), Quaternion.identity);
      Instantiate(ghost[1], new Vector3(6f, -2.83f, 0f), Quaternion.identity);
      Instantiate(ghost[2], new Vector3(25f, -2.5f, 0f), Quaternion.identity);
    }
    if (SceneManager.GetActiveScene().name == "Church")
    {
      Instantiate(angel[0], new Vector3(0.02f, -2.29f, 0f), Quaternion.identity);
      Instantiate(angel[1], new Vector3(13.99f, -1.21f, 0f), Quaternion.identity);
      Instantiate(angel[2], new Vector3(27.05f, -2.25f, 0f), Quaternion.identity);
    }
    if (SceneManager.GetActiveScene().name == "Boss Final")
    {
      Instantiate(demian, new Vector3(-7.61f, -4.03f, 0f), Quaternion.identity);
    }

  }

  void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
    audioData = GetComponent<AudioSource>();

    Vector3 pos = this.transform.position;
    Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(pos.x, pos.y + (float)0.5), Quaternion.identity);
    hb = healthBarTransform.GetComponent<HealthBar>();
    hb.Setup(healthSystem);
  }
  void Update()
  {
    if (Vector2.Distance(transform.position, target.position) <= naoEmpurra)
    {

      if (player.flipar)
      {

        spriteRenderer.flipX = false;
        InimigoAtack();
      }
      else if (player.flipar == false)
      {
        spriteRenderer.flipX = true;
        InimigoAtack();
      }

    }
    else
    {
      animator.Play("Ghost");
    }
    Vector3 pos = this.transform.position;
    hb.transform.position = new Vector3(pos.x, pos.y + (float)0.5);
  }

  void InimigoAtack()
  {
    switch (enemyType)
    {
      case "typeGhost":
        animator.Play("Ghost-Attack");
        break;

      case "typeFlameHead":
        animator.Play("flameHead-Attack");
        break;

      case "typeAngel":
        animator.Play("angel-Attack");
        break;

      case "typeDemian":
        animator.Play("demian-Attack");
        break;
    }


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

    damaged = true;
    Debug.Log("Damaged: " + healthSystem.GetHealthPercent());

    if (healthSystem.GetHealthPercent() <= 0)
    {
      audioData.Stop();
      Destroy(gameObject);
    }
  }

}
