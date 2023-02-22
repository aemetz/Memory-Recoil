using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;

    public int currHealth;

    private float regenRate;
    private float lastRegen;
    private int regenAmt;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
        regenRate = 2f;
        lastRegen = 0f;
        regenAmt = 1;
    }

    public void TakeDamage(int damage)
    {
        currHealth -= damage;

        if (currHealth <= 0)
        {
            // Player dies. For now, the game stops
            Time.timeScale = 0;
            //Destroy(gameObject);
        }
    }

    public void GainHealth(int amount)
    {
        if (currHealth < maxHealth)
        {
            currHealth += amount;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Regen"))
        {
            if (Time.time > lastRegen + regenRate)
            {
                lastRegen = Time.time;
                GainHealth(regenAmt);
            }
        }
    }

}
