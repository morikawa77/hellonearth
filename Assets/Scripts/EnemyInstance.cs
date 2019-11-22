using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class EnemyInstance : MonoBehaviour
{
    public GameObject james;


    public GameObject beer;
    public GameObject beer1;
    public GameObject beer2;
    public GameObject beer3;
    public GameObject beer4;
    public GameObject beer5;
    public GameObject flamehead1;
    public GameObject flamehead2;
    public GameObject flamehead3;
    public GameObject flamehead4;
    public GameObject flamehead5;
    public GameObject ghost1;
    public GameObject ghost2;
    public GameObject ghost3;
    public GameObject ghost4;
    // public GameObject flameHead;
    public GameObject angel1;
    public GameObject angel2;
    public GameObject angel3;
    public GameObject angel4;

    public GameObject demian;
    // public GameObject james;



    void Awake()
    {
        if (SceneManager.GetActiveScene().name == "City")
        {
            Instantiate(james, new Vector3(-9.16f, -3.73f, 0f), Quaternion.identity);
            Instantiate(beer, new Vector3(14.21f, -1.84f, 0.0625f), Quaternion.identity);
            Instantiate(flamehead1, new Vector3(3f, -3.451712f, 0.0625f), Quaternion.identity);
            Instantiate(flamehead2, new Vector3(8f, -3.451712f, 0.0625f), Quaternion.identity);
            Instantiate(beer2, new Vector3(23.51f, -3.14f, 0.0625f), Quaternion.identity);
            Instantiate(flamehead3, new Vector3(19f, -3.451712f, 0.0625f), Quaternion.identity);
            Instantiate(flamehead4, new Vector3(27f, -3.451712f, 0.0625f), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "Cemetery")
        {
            Instantiate(james, new Vector3(-10.47f, -4.43f, 0f), Quaternion.identity);
            Instantiate(ghost1, new Vector3(-1.4f, -1.94f, 0f), Quaternion.identity);
            Instantiate(beer3, new Vector3(3.69f, -4.19f, 0.0625f), Quaternion.identity);
            Instantiate(ghost2, new Vector3(6f, -2.83f, 0f), Quaternion.identity);
            Instantiate(ghost3, new Vector3(25f, -2.5f, 0f), Quaternion.identity);
        }
        if (SceneManager.GetActiveScene().name == "Church")
        {
            Instantiate(james, new Vector3(-7.08f, -3.66f, 0f), Quaternion.identity);
            Instantiate(angel1, new Vector3(0.02f, -2.29f, 0f), Quaternion.identity);
            Instantiate(angel4, new Vector3(11.16f, 0.65f, 0f), Quaternion.identity);
            Instantiate(beer4, new Vector3(6.96f, -3.64f, 0.0625f), Quaternion.identity);
            Instantiate(angel2, new Vector3(13.99f, -1.21f, 0f), Quaternion.identity);
            Instantiate(angel3, new Vector3(27.05f, -2.25f, 0f), Quaternion.identity);
            Instantiate(flamehead4, new Vector3(4.5f, -3.75f, 0.0625f), Quaternion.identity);
            Instantiate(beer5, new Vector3(27.96f, -0.17f, 0.0625f), Quaternion.identity);
            Instantiate(ghost4, new Vector3(33.35f, -0.91f, 0f), Quaternion.identity);

        }
        if (SceneManager.GetActiveScene().name == "Boss Final")
        {
            Instantiate(james, new Vector3(-5.61f, -4.03f, 0f), Quaternion.identity);
            Instantiate(demian, new Vector3(3.99f, -4.23f, 0f), Quaternion.identity);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
