﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Movement
    public float moveSpeed = 1;
    public float moveSpeedMinMax = 1;
    private bool isGrounded;
    public float force = 500;
    public GameObject Model;


    public Rigidbody rb;

    private Vector3 velocityClamped;

    // Power Ups & Collectible

    // Health
    public float Health = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        CheckMovement();
        HealthManager();
        Hit();
    }

    void CheckMovement()
    {
        float horInput = Input.GetAxis("Horizontal") * moveSpeed;
        float verInput = Input.GetAxis("Vertical") * moveSpeed;

        Vector3 forceVector = new Vector3(horInput, 0.0f, verInput).normalized * moveSpeed;
        velocityClamped = new Vector3(Mathf.Clamp(rb.velocity.x, -moveSpeedMinMax, moveSpeedMinMax), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -moveSpeedMinMax, moveSpeedMinMax));

        rb.velocity = velocityClamped;

        Vector3 movement = new Vector3(horInput, 0.0f, verInput);
        

        if (movement != Vector3.zero)
        {
            Model.transform.rotation = Quaternion.LookRotation(movement).normalized;
        }

        rb.AddRelativeForce(forceVector);

        if (horInput != 0 || verInput != 0)
        {
            Model.GetComponent<Animator>().SetBool("IsMoving", true);
        }
        else
        {
            Model.GetComponent<Animator>().SetBool("IsMoving", false);
        }
    }

    void HealthManager()
    {
        if (Health <= 0)
        {
            Model.GetComponent<Animator>().SetBool("IsDead", true);
            rb.isKinematic = true;
        }
    }

    void Hit()
    {
        if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Model.GetComponent<Animator>().SetBool("IsAttacking", true);
            StartCoroutine(Punching());
        }
    }

    IEnumerator Punching()
    {
        yield return new WaitForSeconds(0.5f);
        Model.GetComponent<Animator>().SetBool("IsAttacking", false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Enemy")
        {
            Health--;
        }
    }
}