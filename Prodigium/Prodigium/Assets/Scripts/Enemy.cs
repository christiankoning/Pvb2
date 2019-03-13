using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    public GameObject Player;
    public GameObject SwordCollider;
    public int Health;
    private Rigidbody rb;
    private NavMeshAgent nma;
    private Animator anim;
    public Player player;
    private bool AttackCooldown;

    private float TargetRaycastDistance = 0.1f;
    private float VisibleDistance = 0.5f;

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

        Vector3 ToPlayer = (Player.transform.position - transform.position) * VisibleDistance;
        Vector3 EnemyPos = new Vector3(transform.position.x, 3.5f, transform.position.z);
        RaycastHit hit1;
        Debug.DrawRay(EnemyPos, ToPlayer, Color.green);

        if (Physics.Raycast(EnemyPos, ToPlayer, out hit1, VisibleDistance))
        {
            nma.destination = Player.transform.position;

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
        
    }

    void Attack()
    {
        Vector3 ToPlayer = (Player.transform.position - transform.position) * TargetRaycastDistance;
        Vector3 EnemyPos = new Vector3(transform.position.x, 3.5f, transform.position.z);
        RaycastHit hit;
        Debug.DrawRay(EnemyPos, ToPlayer, Color.yellow);


        if (Physics.Raycast(EnemyPos, ToPlayer, out hit, TargetRaycastDistance))
        {
            if(AttackCooldown == false && hit.distance <= 1)
            {
                anim.SetBool("IsAttacking", true);
                player.Health = player.Health - 10;
                AttackCooldown = true;
                StartCoroutine(Cooldown());
            }
            else
            {
                anim.SetBool("IsAttacking", false);
            }
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(2);
        AttackCooldown = false;
    }

    void CheckHealth()
    {
        if(Health <= 0)
        {
            //Show Dead Animation + Delete this gameobject
            anim.SetBool("IsDead", true);
            rb.isKinematic = true;
            nma.isStopped = true;
            GetComponent<Enemy>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == SwordCollider)
        {
            Health--;
        }
    }
}
