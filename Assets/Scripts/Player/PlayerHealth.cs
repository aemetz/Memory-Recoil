using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth;

    public int currHealth;



    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;
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
}
