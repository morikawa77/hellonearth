using UnityEngine;
using UnityEngine.SceneManagement;

public class Demian : MonoBehaviour
{

  [SerializeField] private float _speed = 1;
  [SerializeField] private float _rayCastOffset = 0.5f;
  PlayerPlatformerController player;
  public Transform verifica;
  public float distanciaMov = 1.50f;
  public float _moveDir = 1;
  Animator animator;
  public float timeNextAtack = 2f;
  Rigidbody2D rb;
  public LayerMask layerEnemy;
  public Transform verifica2;
  public float radiusAtack = 1.50f;
  HealthSystem healthSystem = new HealthSystem(100);
  //public Transform pfHealthBar;
  public float naoEmpurra;
  bool damaged = false;
  AudioSource audioData;
  SpriteRenderer spriteRenderer;
  public Transform target;//set target from inspector instead of looking in Update
  public Transform myTransform;
  // Start is called before the first frame update

  public Transform pfHealthBar;
  void Start()
  {
    animator = GetComponent<Animator>();
    audioData = GetComponent<AudioSource>();

    rb = this.GetComponent<Rigidbody2D>();
    spriteRenderer = this.GetComponent<SpriteRenderer>();
    player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
    animator = this.GetComponent<Animator>();
    myTransform = this.GetComponent<Transform>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    // health system

    GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");

    Transform healthBarTransform = Instantiate(pfHealthBar, new Vector3(0, (float)3.5), Quaternion.identity);
    HealthBar healthBar = healthBarTransform.GetComponent<HealthBar>();
    healthBar.Setup(healthSystem);

    healthBar.transform.localScale = new Vector3(0.3f, 0.07f, 0.05f);

  }

  // Update is called once per frame
  void Update()
  {

    seguir();
    if (Vector2.Distance(transform.position, target.position) <= naoEmpurra)
    {

      if (player.flipar)
      {

        spriteRenderer.flipX = true;
        animator.Play("Demian-attack");

        InimigoAtack();
      }
      else if (player.flipar == false)
      {
        spriteRenderer.flipX = false;
        animator.Play("Demian-attack");

        InimigoAtack();
      }

    }
    else
    {
      animator.Play("Demian-run");
    }
    Vector3 pos = this.transform.position;
  }
  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(verifica.position, distanciaMov);
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere(verifica2.position, radiusAtack);
  }
  void InimigoAtack()
  {
    Collider2D[] enemiesAttack = Physics2D.OverlapCircleAll(verifica2.position, radiusAtack, layerEnemy);
    for (int i = 0; i < enemiesAttack.Length; i++)
    {

      if (timeNextAtack <= 0)
      {
        Debug.Log(enemiesAttack[i].name);
        timeNextAtack = 1.5f;
        InimigoAttackHandler();
      }
      else
      {
        timeNextAtack -= Time.deltaTime;
      }
    }
  }

  public void seguir()
  {


    rb.velocity = new Vector2(-_moveDir, rb.velocity.y);
    spriteRenderer.flipX = true;
    if (player.seguir && Vector2.Distance(transform.position, target.position) <= distanciaMov)
    {

      if (player.flipar)
      {
        Debug.Log("metodoseguir ");
        transform.position = Vector2.MoveTowards(transform.position, target.position, _moveDir * Time.deltaTime);
        spriteRenderer.flipX = false;
      }
      else
      {
        Debug.Log("metodoseguir2 ");
        transform.position = Vector2.MoveTowards(transform.position, target.position, _moveDir * Time.deltaTime);
        spriteRenderer.flipX = true;
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
      //   audioData.Stop();
      Destroy(gameObject);
      // call next scene
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

  }


}
