using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MudarCenas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ReturnMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
    public void StartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }
    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Start");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Cemetery");

        }
    }



}
