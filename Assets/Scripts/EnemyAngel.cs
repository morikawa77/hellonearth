﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngel : MonoBehaviour
{
    Animator animator;
    bool grito = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            grito = true;
            animator.SetBool("grito", grito);
            StartCoroutine(Tempo());

        }
    }


    public IEnumerator Tempo()
    {
        yield return new WaitForSeconds(6f);
        Ataque();

    }
    //public EnemyAngel inimigo;
    public void Ataque()
    {

        animator.Play("Anjo-Idle");

    }


}
