using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIArmor : MonoBehaviour
{
    private PlayerHealth playerArmor;

    public int currArmor;
    public int maxArmor;

    // Sprites 0-3, with 0 being empty and 3 being full.
    [SerializeField] private Sprite[] armorBars;

    // Start is called before the first frame update
    void Start()
    {
        playerArmor = GameObject.Find("Player").GetComponent<PlayerHealth>();
        maxArmor = playerArmor.maxShield;
        currArmor = maxArmor;
    }

    // Update is called once per frame
    void Update()
    {
        currArmor = playerArmor.currShield;
        GetComponent<Image>().sprite = armorBars[currArmor];
    }
}
