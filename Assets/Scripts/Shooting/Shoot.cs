using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class Shoot : MonoBehaviour
{

    [SerializeField] private Transform fp;

    [SerializeField] GameObject bullet;

    public float bulletSpeed = 20f;

    [SerializeField] private InventorySystem inv;

    private void Start()
    {
        inv = FindObjectOfType<InventorySystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    
    private void Fire()
    {

        //Item equipped = inv.ChooseSelectedIem();

        //if (equipped.name == "Pistol")
        //{
        //    Debug.Log("Pistol detected");
        //}

        GameObject playerBullet = Instantiate(bullet, fp.position, fp.rotation);
        Rigidbody2D bulletBody = playerBullet.GetComponent<Rigidbody2D>();
        bulletBody.AddForce(fp.up * -bulletSpeed, ForceMode2D.Impulse);

    }

}
