using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngel : MonoBehaviour
{
    public GritoMorte gritoMorte;
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
    public void Animacao()
    {
        animator.Play("Anjo-Attack");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {


            Animacao();
            StartCoroutine(Tempo());
            


        }
    }
    public IEnumerator Tempo()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);

    }
    
}
