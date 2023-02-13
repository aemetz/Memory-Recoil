using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{




    /// <summary>
    /// Our rigid body component
    /// Used to apply forces so we can move around
    /// </summary>
    private Rigidbody2D rigidBody;

    /// <summary>
    /// Vector from us to the player
    /// </summary>
    private Vector2 OffsetToPlayer;

    /// <summary>
    /// Unit vector in the direction of the player, relative to us
    /// </summary>
    private Vector2 HeadingToPlayer;

    public Transform playerChase;
    public float enemySpeed;
    public float enemyDistance;
    public float enemyStopDistance;

    public float currentTime;
    public float shootingSpeed;
    public float maxHealth;
    public float health;

    public EnemyHealth HealthBar;



    void Start()
    {
        playerChase = GameObject.FindGameObjectWithTag("Player").transform;
        enemyStopDistance = 0f;
        enemyDistance = 2f;


        currentTime = Time.time;

        HealthBar.SetHealth(health, maxHealth);

    }

    // Update is called once per frame
    void Update()
    {
        OffsetToPlayer = playerChase.position - transform.position;
        HeadingToPlayer = OffsetToPlayer.normalized;


        if (Vector2.Distance(transform.position, playerChase.position) > enemyStopDistance)
        {

            transform.position = Vector2.MoveTowards(transform.position, playerChase.position, enemySpeed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, playerChase.position) < enemyStopDistance && Vector2.Distance(transform.position, playerChase.position) > enemyDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, playerChase.position) < enemyDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerChase.position, -enemySpeed * Time.deltaTime);
        }


    }

    public void Spawn()
    {
        gameObject.SetActive(true);
    }


    public void LoseHealth(float damage)
    {
        health -= damage;
        HealthBar.SetHealth(health, maxHealth);
        if (health <= 0)
        {
            
            Destruct();
        }
    }




    void Destruct()
    {
        Destroy(gameObject);
    }

}
