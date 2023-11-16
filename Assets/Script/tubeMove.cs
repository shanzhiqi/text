using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tubeMove : MonoBehaviour
{
    private float speed;
    private float airWall;
    private void Awake()
    {
        airWall = -30f;
        speed = 10f;
    }
    private void Update()
    {
        if (GameManager.Instance.isDead)
        { return; }
        Move();
        delete();
    }
    private void Move()
    { 
        transform.Translate(-Vector3.forward*speed*Time.deltaTime);
    }


    private void delete()
    {
        if (transform.position.z < airWall)
        { 
            Destroy(gameObject);
        }
    }
   
}
