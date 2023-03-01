using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHp;

    // Change this value for the different types of enemies in the script attached to the prefab
    public int dmg;
    float dmgInterval = 3f;
    float dmgTime;

    //float shieldInterval = 2f;
    //float shieldTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHealth>();
        dmgTime = 0;
        //shieldTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dmgTime <= Time.time)
        {
            if (playerHp.currHealth < dmg && playerHp.currHealth > 0)
            {
                playerHp.currHealth = 0;
                Time.timeScale = 0;
            }
            else
            {
                // Check for shield first, otherwise remove health
                if (playerHp.currShield > 0)
                {
                    playerHp.TakeDamage(1);
                }
                else
                {
                    playerHp.TakeDamage(dmg);
                }
                dmgTime = Time.time + dmgInterval;
            }
        }

    }

}
