using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerManager;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Item checkItem = InventorySystem.instance.UseSelectedIem(true);

            if(checkItem != null)
            {
                Debug.Log(checkItem.name);
                if (checkItem.name == "Speed Potion")
                {
                    playerManager.GetComponent<PlayerMovement>().UpdateSpeed();
                }
                if (checkItem.name == "Potion")
                {
                    playerManager.GetComponent<PlayerHealth>().maxHealth += 2;
                }
            }
        }
        
    }


}
