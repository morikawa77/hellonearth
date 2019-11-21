using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : MonoBehaviour
{
    PlayerPlatformerController player;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerPlatformerController>();
    }
    public void hitBeer()
    {
        Debug.Log("James recebeu ataque");
        player.jamesHeal(50);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
