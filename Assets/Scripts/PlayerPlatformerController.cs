using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject
{

  public float maxSpeed = 3;
  public float jumpTakeOffSpeed = 7;

  private SpriteRenderer spriteRenderer;
  public Animator animator;
  public bool flipar = false;
  public bool seguir = false;

  // Health System
  public Transform pfHealthBar;

  PlayerPlatformerController player;

  void Awake()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    animator = GetComponent<Animator>();
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
      animator.Play("James-Punch");
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

  private void OnTriggerEnter2D(Collider2D collision)
  {

    if (collision.gameObject.CompareTag("virar"))
    {
      seguir = true;
    }
  }

  HealthSystem healthSystem = new HealthSystem(100);
  private void Start()
  {
    player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    Vector3 pos = player.transform.position;
    Debug.Log(pos);

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

  public void jamesDamaged(int damage)
  {
    healthSystem.Damage(damage);
    Debug.Log("Damaged: " + healthSystem.GetHealthPercent());
  }
}