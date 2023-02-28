using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUseItem : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerManager;
    public bool closeToDoor;
    public Animator animatorLeft;
    public Animator animatorRight;
    //public Animator animatorRight;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Item checkItem = InventorySystem.instance.UseSelectedIem(false);

            if(checkItem != null)
            {
                Debug.Log(checkItem.name);
                if (checkItem.name == "Speed Potion")
                {
                    playerManager.GetComponent<PlayerMovement>().UpdateSpeed();
                    InventorySystem.instance.UseSelectedIem(true);
                }
                else if (checkItem.name == "Potion")
                {
                    playerManager.GetComponent<PlayerHealth>().maxHealth += 2;
                    InventorySystem.instance.UseSelectedIem(true);
                }
                else if(checkItem.name == "Key" && closeToDoor)
                {
                    animatorLeft.SetFloat("hi", 1);
                    animatorRight.SetFloat("key", 1);
                    InventorySystem.instance.UseSelectedIem(true);
                }
                
            }
        }
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Door"))
        {
            Debug.Log("Interacting with Door !!!!!");
            closeToDoor = true;
        }
    }


}
