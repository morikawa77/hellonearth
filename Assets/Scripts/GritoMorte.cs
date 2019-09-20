using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GritoMorte : MonoBehaviour
{
    EnemyAngel anjo;
    Animator animator;
    bool grito = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {



            collision.GetComponent<EnemyAngel>().AtaqueGrito();



        }
    }
    

}
