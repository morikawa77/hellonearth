using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyInstance : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject flameHead;
    public GameObject angel;
    public GameObject james;
    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "City")
        {
            Instantiate(james, new Vector3(-9.16f, -3.73f, 0f), Quaternion.identity);
            Instantiate(flameHead, new Vector3(3f, -3.451712f, 0.0625f), Quaternion.identity);
            Instantiate(flameHead, new Vector3(19f, -3.451712f, 0.0625f), Quaternion.identity);
            Instantiate(flameHead, new Vector3(27f, -3.451712f, 0.0625f), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "Cemetery")
        {
            Instantiate(james, new Vector3(-10.47f, -4.43f, 0f), Quaternion.identity);
            Instantiate(myPrefab, new Vector3(-1.4f, -1.94f, 0f), Quaternion.identity);
            Instantiate(myPrefab, new Vector3(6f, -2.83f, 0f), Quaternion.identity);
            Instantiate(myPrefab, new Vector3(25f, -2.5f, 0f), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "Church")
        {
            Instantiate(james, new Vector3(-7.08f, -3.66f, 0f), Quaternion.identity);
            Instantiate(angel, new Vector3(0.02f, -2.29f, 0f), Quaternion.identity);
            Instantiate(angel, new Vector3(13.99f, -1.21f, 0f), Quaternion.identity);
            Instantiate(angel, new Vector3(27.05f, -2.25f, 0f), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
