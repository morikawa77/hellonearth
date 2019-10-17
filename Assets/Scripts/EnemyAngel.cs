using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAngel : MonoBehaviour
{
    Animator animator;
    public LayerMask layerEnemy;
    public Transform verifica;
    public float radiusAtack = 1.50f;
    private Transform target;
    public float distancia;
    AudioSource audioData;
    public float timeNextAtack = 0.5f;
    public float naoEmpurra;


    PlayerPlatformerController player;
    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
        audioData = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Vector2.Distance(transform.position, target.position) <= naoEmpurra)
        {

            animator.Play("Anjo-Attack");

            InimigoAtack();
            audioData.Play(0);

        }
        else
        {
            animator.Play("Anjo-Idle");
            audioData.Stop();
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {


    //        InimigoAtack();

    //        audioData.Play(0);

    //    }
    //}
    void InimigoAtack()
    {
        Collider2D[] enimiesAttack = Physics2D.OverlapCircleAll(verifica.position, radiusAtack, layerEnemy);
        for (int i = 0; i < enimiesAttack.Length; i++)
        {

            if (timeNextAtack <= 0)
            {

                Debug.Log(enimiesAttack[i].name);
                timeNextAtack = 3f;
                InimigoAttackHandler();
            }
            else
            {
                timeNextAtack -= Time.deltaTime;
            }
        }
    }

    //public IEnumerator Tempo()
    //{
    //    yield return new WaitForSeconds(2f);
    //    audioData.Stop();
    //    animator.Play("Anjo-Idle");

    //    //Ataque();


    //}
    ////public EnemyAngel inimigo;

    //public void Ataque()
    //{

    //  // Destroy(GameObject.FindGameObjectWithTag("Player"));
    //}

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verifica.position, radiusAtack);
    }
    public void InimigoAttackHandler()
    {
        Debug.Log("James recebeu ataque");
        player.jamesDamaged(25);
    }
}
