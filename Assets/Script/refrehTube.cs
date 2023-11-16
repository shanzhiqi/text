
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class refrehTube : MonoBehaviour
{
    private float maxY;
    private float minY;
    private GameObject Tube;
  
    private void Awake()
    {
        Tube = Resources.Load<GameObject>("Prefabs/tube");
        maxY = 17f;
        minY = 7f;

       
    }
    private void Start()
    {
        InvokeRepeating("refreh", 1f,1f);
    }
    

    private void refreh()
    {
        if (GameManager.Instance.isDead)
        { return; }
        float randomY = Random.Range(maxY, minY);
        Vector3 v3 = new Vector3(transform.position.x, randomY, transform.position.z);
        Instantiate(Tube,v3,Quaternion.identity);
    }

    
}
