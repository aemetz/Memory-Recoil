using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Transform = UnityEngine.Transform;

public class Shoot : MonoBehaviour
{

    [SerializeField] private Transform fp;

    [SerializeField] GameObject bullet;

    public float bulletSpeed = 20f;

    [SerializeField] private InventorySystem inv;

    //public string activeWeapon;

    private float prevBulletTime = 0;

    // Change these variables in switch case depending on which gun is equipped
    private float currFireRate;
    private float currDamage;
    private string currWeapon;

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

        //Item equipped = inv.ChooseSelectedIem();
        //if (equipped.name == "Pistol")
        //{
        //    activeWeapon = "Pistol";
        //}

    }

    
    private void Fire()
    {

        Item equipped = inv.ChooseSelectedIem();

        Debug.Log(equipped);

        if (equipped != null)
        {
            currWeapon = equipped.name;
        }
        else
        {
            currWeapon = "None";
        }
        Debug.Log(currWeapon);
        // Set gun stats here
        switch (currWeapon)
        {
            case "Pistol":
                currFireRate = 0.5f;
                currDamage = 20f;
                break;

            case "SMG":
                currFireRate = 0.1f;
                currDamage = 0.7f;
                break;

            case "None":
                break;
        }


        if (Time.time > prevBulletTime + currFireRate)
        {
            prevBulletTime = Time.time;

            if (equipped != null)
            {
                GameObject playerBullet = Instantiate(bullet, fp.position, fp.rotation);
                playerBullet.GetComponent<Bullet>().BulletDamage = currDamage;

                Rigidbody2D bulletBody = playerBullet.GetComponent<Rigidbody2D>();
                bulletBody.AddForce(fp.up * -bulletSpeed, ForceMode2D.Impulse);
            }

        }

        

        

    }

}
