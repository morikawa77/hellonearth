using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demian : MonoBehaviour
{

    [SerializeField] private float _speed = 1;
    [SerializeField] private float _rayCastOffset = 0.5f;
    // [SerializeField] private float _rayCastDistance = 1f;
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
    void Start()
    {
        animator = GetComponent<Animator>();
        audioData = GetComponent<AudioSource>();

        rb = FindClosestEnemy().GetComponent<Rigidbody2D>();
        spriteRenderer = FindClosestEnemy().GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlatformerController>();
        animator = FindClosestEnemy().GetComponent<Animator>();
        myTransform = FindClosestEnemy().GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        
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
        Collider2D[] enimiesAttack = Physics2D.OverlapCircleAll(verifica2.position, radiusAtack, layerEnemy);
        for (int i = 0; i < enimiesAttack.Length; i++)
        {

            if (timeNextAtack <= 0)
            {
                Debug.Log(enimiesAttack[i].name);
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
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
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
