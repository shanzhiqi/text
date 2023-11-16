using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundMove : MonoBehaviour
{
    private float speed;
    private GameObject ground1;
    private GameObject ground2;
    private float airWall;
    private void Awake()
    {
        airWall = -50.5f;
        speed = 10f;
        ground1 = transform.GetChild(0).gameObject;
        ground2 = transform.GetChild(1).gameObject;
    }
    private void Update()
    {
        if (GameManager.Instance.isDead)
        { return; }
        StartCoroutine(ground1Move());
        StartCoroutine(ground2Move());
    }
    IEnumerator ground1Move()
    {
        Move(ground1);
        yield return null;
    }
    IEnumerator ground2Move()
    {
        Move(ground2);
        yield return null;
    }
    private void Move(GameObject ground)
    {
        ground.transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        if (ground.transform.position.z < airWall)
        {
            ground.transform.position += new Vector3(0,0,120);
            //if (ground == ground1)
            //{
            //    ground.transform.position = new Vector3(ground2.transform.position.x,ground2.transform.position.y, ground2.transform.position.z + 60f);

            //} 
            //else if(ground == ground2)
            //{
            //    ground.transform.position = new Vector3(ground1.transform.position.x, ground1.transform.position.y, ground1.transform.position.z + 60f);
            //}

        }
    }

    
}
