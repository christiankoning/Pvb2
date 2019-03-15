using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    // Movement
    public float moveSpeed = 1;
    public float moveSpeedMinMax = 1;
    private bool isGrounded;
    public GameObject Model;
    private Vector3 movement;
    private Vector3 forceVector;

    public Rigidbody rb;

    private Vector3 velocityClamped;

    // Power Ups & Collectibles
    public int Collected;
    public Paths paths;
    public GameObject DoubleHealth;
    public GameObject FullHealth;

    //Damage
    public GameObject DamageRange;
    public bool IsSwinging;

    // Health
    public float Health = 100;

    //SpawnPoints
    public GameObject OWSpawn;
    public GameObject Dungeon1Spawn;
    public GameObject Dungeon2Spawn;
    public GameObject BossSpawn;
    private int RespawnPos;

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

            forceVector = new Vector3(horInput, 0.0f, verInput).normalized * moveSpeed;
            velocityClamped = new Vector3(Mathf.Clamp(rb.velocity.x, -moveSpeedMinMax, moveSpeedMinMax), rb.velocity.y, Mathf.Clamp(rb.velocity.z, -moveSpeedMinMax, moveSpeedMinMax));

            rb.velocity = velocityClamped;

            movement = new Vector3(horInput, 0.0f, verInput);


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
            Dead();
        }
        else
        {
            rb.isKinematic = false;
            Model.GetComponent<Animator>().SetBool("IsDead", false);
        }
    }
    
    void Dead()
    {
        if(SceneManager.GetActiveScene().name == "Castle")
        {
            SceneManager.LoadScene("Castle");
        }
        else
        {
            if(RespawnPos == 0)
            {
                transform.position = OWSpawn.transform.position;
                Health = 100;
            }
            else if(RespawnPos == 0 && Collected == 1)
            {
                transform.position = new Vector3(-126, 0.05f, -123);
                Health = 100;
            }
            else if (RespawnPos == 1)
            {
                transform.position = Dungeon1Spawn.transform.position;
                Health = 100;
            }
            else if (RespawnPos == 2)
            {
                transform.position = Dungeon2Spawn.transform.position;
                Health = 100;
            }
            else if (RespawnPos == 3)
            {
                transform.position = BossSpawn.transform.position;
                Health = 100;
            }
        }
    }

    public void Hit()
    {
        if(Input.GetMouseButtonDown(0) && IsSwinging == false)
        {
            Model.GetComponent<Animator>().SetBool("IsAttacking", true);
        }
        else if(IsSwinging == true)
        {
            Model.GetComponent<Animator>().SetBool("IsAttacking", false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Dungeon1Trigger")
        {
            transform.position = Dungeon1Spawn.transform.position;
            RespawnPos = 1;
        }
        if (other.gameObject.name == "Dungeon2Trigger")
        {
            transform.position = Dungeon2Spawn.transform.position;
            RespawnPos = 2;
        }
        if (other.gameObject.name == "BossTrigger")
        {
            transform.position = BossSpawn.transform.position;
            RespawnPos = 3;
        }
        if (other.gameObject.name == "Collectable1")
        {
            transform.position = new Vector3(-126, 0.05f, -123);
            Collected++;
            Destroy(other.gameObject);
            RespawnPos = 0;
            paths.DungeonCompleted = 1;
        }

        if (other.gameObject.name == "Collectable2")
        {
            transform.position = new Vector3(145.65f, 0.05f, -62.79f);
            Collected++;
            Destroy(other.gameObject);
            RespawnPos = 0;
            paths.DungeonCompleted = 2;
        }

        if (other.gameObject.name == "Collectable3")
        {
            Collected++;
            Destroy(other.gameObject);
        }

        if (other.gameObject.name == "Magic")
        {
            Health = Health - 10;
        }

        if (other.gameObject.name == "DoubleHealth")
        {
            Health = Health * 2;
            StartCoroutine(ActiveEffect());
        }
        if (other.gameObject.name == "FullHealth")
        {
            Health = 100;
        }
    }

    IEnumerator ActiveEffect()
    {
        yield return new WaitForSeconds(30);
        Health = Health / 2;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Exit")
        {
            SceneManager.LoadScene("Overworld");
        }
    }
}