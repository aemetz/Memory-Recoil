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

    private bool canFire;

    // Change these variables in Fire() depending on which gun is equipped
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
        if (Input.GetButton("Fire1"))
        {
            Fire();
        }
    }

    
    private void Fire()
    {

        Item equipped = inv.ChooseSelectedIem();

        //Debug.Log(equipped);

        if (equipped != null)
        {
            currWeapon = equipped.name;
        }
        else
        {
            currWeapon = "None";
        }
        //Debug.Log(currWeapon);

        // TEMP: change weapon stats here
        if (currWeapon == "Pistol")
        {
            currFireRate = 0.5f;
            currDamage = 2.5f;
            canFire = true;
        }
        else if (currWeapon == "SMG")
        {
            currFireRate = 0.1f;
            currDamage = 1f;
            canFire = true;
        }
        else
        {
            canFire = false;
        }

        if (Time.time > prevBulletTime + currFireRate)
        {
            prevBulletTime = Time.time;

            if (canFire)
            {
                Debug.Log(currWeapon);
                GameObject playerBullet = Instantiate(bullet, fp.position, fp.rotation);
                playerBullet.GetComponent<Bullet>().BulletDamage = currDamage;

                Rigidbody2D bulletBody = playerBullet.GetComponent<Rigidbody2D>();
                bulletBody.AddForce(fp.up * -bulletSpeed, ForceMode2D.Impulse);
            }
        }

    }

}
