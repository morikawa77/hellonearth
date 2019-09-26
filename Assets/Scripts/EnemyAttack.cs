using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerPlatformerController player;
    public LayerMask layerEnemy;
    public Transform verifica;
    public float radiusAtack;
    private Transform target;
    public float distancia;
    public bool Atacando = false;
    public float contagem;
    float timeNextAtack;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        InimigoAtack();
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
            }
            else
            {
                timeNextAtack -= Time.deltaTime;
            }
        }
    }
}
