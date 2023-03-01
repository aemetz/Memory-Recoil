using System.Collections;
using System.Collections.Generic;
using UnityEditor.Networking.PlayerConnection;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHp;
    public Renderer PlayerRend;

    // Change this value for the different types of enemies in the script attached to the prefab
    public int dmg;
    float dmgInterval = 3f;
    float dmgTime;
    Color playerC;

    //float shieldInterval = 2f;
    //float shieldTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHealth>();
        PlayerRend = GameObject.Find("Player").GetComponent<Renderer>();
        dmgTime = 0;
        playerC = PlayerRend.material.color;
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
                    StartCoroutine(Invincable(1.5f));
                }
                else
                {
                    playerHp.TakeDamage(dmg);
                    StartCoroutine(Invincable(1.5f));
                }
                dmgTime = Time.time + dmgInterval;
            }
        }

    }


    IEnumerator Invincable(float period)
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        playerC.a = 0.5f;
        PlayerRend.material.color = playerC;
        yield return new WaitForSeconds(period);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        playerC.a = 1f;
        PlayerRend.material.color = playerC;
    }

}
