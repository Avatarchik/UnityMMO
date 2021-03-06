﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D rb;
    private Animator animator;
    public float speed;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector2 movementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (movementVector.x != 0)
        {
            animator.SetBool("isWalking", true);

            animator.SetFloat("input_x", movementVector.x);
        }

        if (movementVector.y != 0)
        {
            animator.SetBool("isWalking", true);
            animator.SetFloat("input_y", movementVector.y);
        }

        if(movementVector == Vector2.zero)
        {
            animator.SetBool("isWalking", false);
        }
        rb.MovePosition(rb.position + (speed * movementVector.normalized * Time.deltaTime));
        //diagonal input fails at times
        //moving diagonally moves faster
	}
}
