using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float tamanho, starPos;
    public GameObject cam; //camera
    public float parallaxEffect;

    // Start is called before the first frame update
    void Start()
    {
        starPos = transform.position.x;
        tamanho = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float tempo = (cam.transform.position.x * (1 - parallaxEffect));
        float distancia = (cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(starPos + distancia, transform.position.y, transform.position.z);

        if (tempo > starPos + tamanho)
            starPos += tamanho;
        else if (tempo < starPos - tamanho)
            starPos -= tamanho;

    }
}
