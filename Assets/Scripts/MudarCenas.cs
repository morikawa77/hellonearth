using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    SceneManager.LoadScene("Start");
  }
  public void StartGame()
  {
    SceneManager.LoadScene("City");
  }
  public void Options()
  {
    SceneManager.LoadScene("Options");
  }
  public void Exit() 
  {
     Application.Quit();
  }
  private void OnTriggerEnter2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag("Player"))
    {
      // UnityEngine.SceneManagement.SceneManager.LoadScene("Cemetery");
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
  }



}
