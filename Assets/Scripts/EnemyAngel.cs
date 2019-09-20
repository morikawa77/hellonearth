using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAngel : MonoBehaviour
{
    public GritoMorte gritoMorte;
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

    public void AtaqueGrito()
    {
        grito = true;
        animator.Play("Anjo-Attack");
        StartCoroutine(Tempo());
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
        Destroy(gameObject);
    }


}
