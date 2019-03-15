using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Boss : MonoBehaviour {

    public GameObject Player;
    public GameObject SwordCollider;
    public int BossHealth;
    private Rigidbody rb;
    private NavMeshAgent nma;
    private Animator anim;
    public Player player;
    private bool AttackCooldown;
    private bool FoundPlayer;
    private bool IsDead;
    public LootManager Lmanager;
    private bool SpawnedLoot;
    private int RandomNumber;
    public Collider col;
    private bool IsAttacking;
    private int Shots;
    public GameObject SpawnPoint;
    public GameObject Fireball;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        nma = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        CheckHealth();
        Movement();
        Attack();
    }

    void Movement()
    {
        float dist = Vector3.Distance(transform.position, Player.transform.position);

        if (dist < 15)
        {
            FoundPlayer = true;
        }

        if (FoundPlayer == true && IsDead == false && IsAttacking == false)
        {
            nma.isStopped = false;
            nma.ResetPath();
            nma.destination = Player.transform.position;
            transform.LookAt(Player.transform.position);

            float velocity = nma.velocity.magnitude;

            if (velocity >= 0)
            {
                anim.SetBool("IsMoving", true);
            }
            else
            {
                anim.SetBool("IsMoving", false);
            }
        }
        if (IsDead == true)
        {
            nma.isStopped = true;
            col.enabled = false;
        }

    }

    void Attack()
    {

        float dist = Vector3.Distance(transform.position, Player.transform.position);
        if (dist < 8)
        {
            if (IsAttacking == false && IsDead == false && AttackCooldown == false)
            {
                Shots++;
                anim.SetBool("CanShoot", true);
                StartCoroutine(Delay());
                IsAttacking = true;
                GameObject newFireball = Instantiate(Fireball, SpawnPoint.transform.position, Quaternion.identity);
                newFireball.GetComponent<Rigidbody>().AddForce(SpawnPoint.transform.forward * 350);
                newFireball.name = "Magic";

            }
            else
            {
                anim.SetBool("CanShoot", false);
            }
        }

        if(Shots >= 3)
        {
            StartCoroutine(Reloading());
            Shots = 0;
            AttackCooldown = true;
        }
    }
    
    IEnumerator Reloading()
    {
        yield return new WaitForSeconds(5);
        AttackCooldown = false;
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        IsAttacking = false;
    }

    void CheckHealth()
    {
        if (BossHealth <= 0)
        {
            //Show Dead Animation + Delete this gameobject
            anim.SetBool("IsDead", true);
            rb.isKinematic = true;
            nma.isStopped = true;
            IsDead = true;
            Despawn();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == SwordCollider)
        {
            BossHealth--;
        }
    }

    void Despawn()
    {
        StartCoroutine(Delete());
        if (SpawnedLoot == false)
        {
            RandomNumber = Random.Range(0, 5);
            GameObject Loot = Instantiate(Lmanager.Item[RandomNumber], transform.position + new Vector3(0, 0.5f, 0), Lmanager.Item[RandomNumber].transform.rotation);
            Loot.name = Lmanager.Item[RandomNumber].name;
            SpawnedLoot = true;
        }
    }

    IEnumerator Delete()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }

}
