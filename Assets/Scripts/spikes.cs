using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour
{
  PlayerPlatformerController player;
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      player.jamesDamaged(100);
    }
  }
}
