using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class EnemyAngel : MonoBehaviour
{
  Animator animator;
  bool grito = false;

  AudioSource audioData;

  PlayerPlatformerController player;
  void Start()
  {
    animator = GetComponent<Animator>();
    audioData = GetComponent<AudioSource>();
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
      audioData.Play(0);
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
    audioData.Stop();
    animator.Play("Anjo-Idle");
    player.jamesDamaged(20);
    // Destroy(GameObject.FindGameObjectWithTag("Player"));
  }


}
