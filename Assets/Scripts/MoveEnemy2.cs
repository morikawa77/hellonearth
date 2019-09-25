using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy2 : MonoBehaviour
{
    public LayerMask enemyMask;
    public float speed = 1;
    Rigidbody2D myBody;
    Transform myTrans;
    float myWidth;

    // Start is called before the first frame update
    void Start()
    {
        myTrans = this.transform;
        myBody = this.GetComponent<Rigidbody2D>();
        myWidth = this.GetComponent<SpriteRenderer>().bounds.extents.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 lineCastPos = myTrans.position - myTrans.right * myWidth;
        Debug.DrawLine(lineCastPos,lineCastPos + Vector2.down);
       
       
        Vector2 myVel = myBody.velocity;
        myVel.x = speed;
        myBody.velocity = myVel;
    }
}
