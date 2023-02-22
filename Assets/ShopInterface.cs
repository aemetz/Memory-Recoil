using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInterface : MonoBehaviour
{

    bool InteractableShop;
    public GameObject ShopManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InteractableShop && Input.GetKeyDown(KeyCode.E))
        {
            OpenShop();
        }
    }


    public void OpenShop()
    {
        ShopManager.SetActive(true);
    }

    public void CloseShop()
    {
        ShopManager.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractableShop = true;
        }
    }




    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InteractableShop = false;
        }
    }
}
