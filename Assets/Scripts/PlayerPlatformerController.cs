using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject
{

  public float maxSpeed = 3;
  public float jumpTakeOffSpeed = 7;
  public Transform verifica;
  public Transform verifica1;
  public LayerMask layerPlayer;
  public float radiusAtack = 1.50f;
  public float timeNextAtack = 0.5f;
  private SpriteRenderer spriteRenderer;
  public Animator animator;
  public bool flipar = false;
  public bool flipSoco = false;
  public bool seguir = false;
  HealthSystem healthSystem = new HealthSystem(100);
  bool damaged = false;
  //public AudioClip jump;
  //public AudioClip punchs;
  //public AudioClip walk;
  // Health System
  public Transform pfHealthBar;


  PlayerPlatformerController player;

  // public GameObject james;

  Collider2D[] playerAttack;


  private void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    Vector3 pos = player.transform.position;
    //Debug.Log(pos);



    Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(pos.x, pos.y + (float)0.5), Quaternion.identity);
    HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
    healthBar.Setup(healthSystem);

    healthBar.transform.parent = player.transform;

    // testing healthBar
    // Debug.Log("Health: " + healthSystem.GetHealthPercent());
    // healthSystem.Damage(50);
    // Debug.Log("Damaged: " + healthSystem.GetHealthPercent());
    // healthSystem.Heal(30);
    // Debug.Log("Healed: " + healthSystem.GetHealthPercent());

  }

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();

    // if (SceneManager.GetActiveScene().name == "City")
    // {
    //   Instantiate(james, new Vector3(-9.16f, -3.73f, 0f), Quaternion.identity);
    // }
    // if (SceneManager.GetActiveScene().name == "Cemetery")
    // {
    //   Instantiate(james, new Vector3(-10.47f, -4.43f, 0f), Quaternion.identity);
    // }
    // if (SceneManager.GetActiveScene().name == "Church")
    // {
    //   Instantiate(james, new Vector3(-7.08f, -3.66f, 0f), Quaternion.identity);
    // }
    // if (SceneManager.GetActiveScene().name == "Boss Final")
    // {
    //   Instantiate(james, new Vector3(-5.61f, -4.03f, 0f), Quaternion.identity);

    // }
  }

  protected override void ComputeVelocity()
  {
    Vector2 move = Vector2.zero;

    move.x = Input.GetAxis("Horizontal");

    bool punch = Input.GetButtonDown("Fire1");

    if (Input.GetButtonDown("Jump") && grounded)
    {
      velocity.y = jumpTakeOffSpeed;
    }
    else if (Input.GetButtonUp("Jump"))
    {
      if (velocity.y > 0)
      {
        velocity.y = velocity.y * 0.5f;
      }
    }

    if (punch && grounded)
    {
      //Gerenciador.instancia.PlayAudio(punchs);
      animator.Play("James-Punch");
      if (flipar)
      {
        VerificandoAt();
      }
      else
      {
        VerificandoAt1();
      }
    }
    else if (punch && !grounded)
    {
      animator.Play("James-FlyingKick");
      if (flipar)
      {
        VerificandoAt();
      }
      else
      {
        VerificandoAt1();
      }
    }



    bool flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < 0.01f));

    if (spriteRenderer.flipX)
    {
      flipar = true;
    }
    else
    {
      flipar = false;
    }


    if (move.x < 0)
    {
      spriteRenderer.flipX = true;
    }
    else if (move.x > 0)
    {
      spriteRenderer.flipX = false;
    }

    animator.SetBool("grounded", grounded);
    animator.SetFloat("Speed", Mathf.Abs(velocity.x) / maxSpeed);
    animator.SetBool("punch", punch);

    targetVelocity = move * maxSpeed;
  }




  public void VerificandoAt()
  {
    Collider2D[] playerAttack = Physics2D.OverlapCircleAll(verifica.position, radiusAtack, layerPlayer);
    for (int i = 0; i < playerAttack.Length; i++)
    {
      if (timeNextAtack <= 0)
      {
        // Debug.Log(playerAttack[i].name);
        timeNextAtack = 0f;

        if (playerAttack[i].name == "Enemy(Clone)")
        {
          FlameHead enemy = GameObject.Find(playerAttack[i].name).GetComponent<FlameHead>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(25);
        }
        else if (playerAttack[i].name == "EnemyGhost(Clone)")
        {
          EnemyAttack enemy = GameObject.Find(playerAttack[i].name).GetComponent<EnemyAttack>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(25);
        }
        else if (playerAttack[i].name == "Anjo(Clone)")
        {
          EnemyAngel enemy = GameObject.Find(playerAttack[i].name).GetComponent<EnemyAngel>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(25);
        }

      }
      else
      {
        timeNextAtack -= Time.deltaTime;
      }

    }
  }
  public void VerificandoAt1()
  {
    Collider2D[] playerAttack = Physics2D.OverlapCircleAll(verifica1.position, radiusAtack, layerPlayer);
    for (int i = 0; i < playerAttack.Length; i++)
    {
      if (timeNextAtack <= 0)
      {
        // Debug.Log(playerAttack[i].name);
        timeNextAtack = 0f;

        if (playerAttack[i].name == "Enemy(Clone)")
        {
          FlameHead enemy = GameObject.Find(playerAttack[i].name).GetComponent<FlameHead>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(25);
        }
        else if (playerAttack[i].name == "EnemyGhost(Clone)")
        {
          EnemyAttack enemy = GameObject.Find(playerAttack[i].name).GetComponent<EnemyAttack>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(25);
        }
        else if (playerAttack[i].name == "Anjo(Clone)")
        {
          EnemyAngel enemy = GameObject.Find(playerAttack[i].name).GetComponent<EnemyAngel>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(25);
        }
        else if (playerAttack[i].name == "Demian(Clone)")
        {
          Demian enemy = GameObject.Find(playerAttack[i].name).GetComponent<Demian>();
          Debug.Log(playerAttack[i].name + "Inimigo recebeu ataque");
          enemy.enemyDamaged(5);
        }

      }
      else
      {
        timeNextAtack -= Time.deltaTime;
      }

    }
  }

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if (collision.gameObject.CompareTag("virar"))
    {
      seguir = true;
    }
  }



  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(verifica.position, radiusAtack);
    Gizmos.DrawWireSphere(verifica1.position, radiusAtack);
  }
  public void jamesHeal(int heal)
  {

    healthSystem.Heal(heal);
    Debug.Log("heal " + healthSystem.GetHealthPercent());
  }
  public void jamesDamaged(int damage)
  {


    healthSystem.Damage(damage);

    damaged = true;
    Debug.Log("Damaged: " + healthSystem.GetHealthPercent());
    if (healthSystem.GetHealthPercent() == 0)
    {
      Destroy(GameObject.FindGameObjectWithTag("Player"));
      SceneManager.LoadScene("GameOver");
    }

    if (damaged == true)
    {
      animator.Play("James-Hurt");
      damaged = false;
    }
    else
    {
      animator.Play("James-Idle");
    }


  }
}