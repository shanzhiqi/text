using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;
    private float upSpeed;
    private bool isFly;
    private bool isFall;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        upSpeed = 10f;
    }
    private void Update()
    {
        if (GameManager.Instance.isDead)
        { 
            Destroy(rb);
            return;
        }
        fly();
    }

    private void fly()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = Vector3.up * upSpeed;
            isFly = true;
            isFall = false;
            animator.SetBool("isFly", isFly);
            animator.SetBool("isFall",isFall);

        }
        else
        { 
            isFly = false;
            isFall = true;
            animator.SetBool("isFly", isFly);
            animator.SetBool("isFall", isFall);
        }
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tube"))
        {
            GameManager.Instance.addScore();
            soundManager.Instance.playSound(true);
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("corwn"))
        {  
            GameManager.Instance.dead(transform);
            soundManager.Instance.playSound(false);
        }
        
    }


}
