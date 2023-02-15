using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private PlayerHealth playerHp;

    public int currHp;
    public int maxHp;

    // Sprites 0-9, with 0 being empty and 9 being full
    [SerializeField] private Sprite[] healthBars;

    // Start is called before the first frame update
    void Start()
    {
        playerHp = GameObject.Find("Player").GetComponent<PlayerHealth>();
        maxHp = playerHp.maxHealth;
        currHp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale != 0)
        {
            currHp = playerHp.currHealth;
            GetComponent<Image>().sprite = healthBars[currHp - 1];
        }
    }
}