using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public PlayerHealth playerHp;

    // Change this value for the different types of enemies in the script attached to the prefab
    public int dmg;
    float dmgInterval = 3f;
    float dmgTime;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHealth>();
        dmgTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player") && dmgTime <= Time.time)
        {
            playerHp.TakeDamage(dmg);
            dmgTime = Time.time + dmgInterval;
        }
    }

}
