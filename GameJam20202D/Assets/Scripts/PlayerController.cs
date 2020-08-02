using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    SpriteRenderer sr;
    Animator a;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        a = GetComponent<Animator>();
    }

    
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
       a.SetFloat("Direction", x);
        if (x == 0)
        {
           a.SetBool("Running", false);
        }
        else
        {
            if (x < 0)
            {
               sr.flipX = true;
            }
            else if (x > 0)
            {
               sr.flipX = false;
            }
           a.SetBool("Running", true);
        }
        
        transform.Translate(Vector2.right * x * 5f * Time.deltaTime);
    }
}
