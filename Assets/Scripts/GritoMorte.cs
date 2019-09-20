﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GritoMorte : MonoBehaviour
{

    public EnemyAngel inimigo;
    
    Animator animator;
    

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
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<EnemyAngel>().Animacao();
            Destroy(gameObject);

        }
    }
   
}
