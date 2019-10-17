using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciador : MonoBehaviour
{
    public AudioSource sons;
    public static Gerenciador instancia = null;
    // Start is called before the first frame update
    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else if (instancia != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio(AudioClip clipAudio)
    {
        sons.clip = clipAudio;
        sons.Play();
    }
}
