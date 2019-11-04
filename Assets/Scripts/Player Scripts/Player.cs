﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 8f, maxVelocity = 4f;
    
    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        PlayerMoveKeyboard();
    }

    void PlayerMoveKeyboard()
    {
        float forceX = 0f;
        float vel = Mathf.Abs(myBody.velocity.x);

        // -1: left arrow key or A; 0: nothing is pressed; 1: right arrow key or D;
        float h = Input.GetAxisRaw("Horizontal");

        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                forceX = speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = 1.3f;
            transform.localScale = temp;
            anim.SetBool("Walk", true);
        }
        else if(h < 0)
        {
            if (vel < maxVelocity)
            {
                forceX = -speed;
            }
            Vector3 temp = transform.localScale;
            temp.x = -1.3f; // player facing the opposite direction
            transform.localScale = temp;
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
        }

        myBody.AddForce(new Vector2(forceX, 0));

    }
}
