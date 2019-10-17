using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInstance : MonoBehaviour
{
  public GameObject myPrefab;
  // public GameObject flameHead;
  // public GameObject angel;
  void Start()
  {
    if (SceneManager.GetActiveScene().name == "City")
    {
      Instantiate(myPrefab, new Vector3(3f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(myPrefab, new Vector3(19f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(myPrefab, new Vector3(27f, -3.451712f, 0.0625f), Quaternion.identity);
    }
    if (SceneManager.GetActiveScene().name == "Cemetery")
    {
      Instantiate(myPrefab, new Vector3(3f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(myPrefab, new Vector3(19f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(myPrefab, new Vector3(27f, -3.451712f, 0.0625f), Quaternion.identity);
    }
    if (SceneManager.GetActiveScene().name == "Church")
    {
      Instantiate(myPrefab, new Vector3(3f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(myPrefab, new Vector3(19f, -3.451712f, 0.0625f), Quaternion.identity);
      Instantiate(myPrefab, new Vector3(27f, -3.451712f, 0.0625f), Quaternion.identity);
    }

  }

  // Update is called once per frame
  void Update()
  {

  }
}
