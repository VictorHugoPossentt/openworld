using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour
{
    public GameObject[] weaponsPrefabs;
    public GameObject[] projectilesPrefab;
    int indexWeapon = 0;
    public GameObject target;
    public GameObject laserpoint;

    void Start()
    {
        DesactivateWeapons(0); 
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            indexWeapon = 0;
            DesactivateWeapons(0);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            indexWeapon = 1;
            DesactivateWeapons(1);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            indexWeapon = 2;
            DesactivateWeapons(2);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            indexWeapon = 3;
            DesactivateWeapons(3);
        }
        if(Input.GetKey(KeyCode.Alpha5))
        {
            indexWeapon = 4;
            DesactivateWeapons(4);
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            indexWeapon = 5;
            DesactivateWeapons(5);
        }
        if (Input.GetKey(KeyCode.Alpha7))
        {
            indexWeapon = 6;
            DesactivateWeapons(6);
        }
        if (Input.GetKey(KeyCode.Alpha8))
        {
            indexWeapon = 7;
            DesactivateWeapons(7);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit))
        {
            laserpoint.transform.position = hit.point;
        }
        else
        {
            laserpoint.transform.position = transform.position + transform.forward * 100;
        }

    }

    void Shoot()
    {
        //instancia o objeto e guarda a referencia        
        //GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], target.transform.position + transform.forward, transform.rotation);        
        //GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], target.transform.position, target.transform.rotation);
        GameObject myprojectile = Instantiate(projectilesPrefab[indexWeapon], new Vector3(transform.position.x, transform.position.y + 0.6f, transform.position.z) + transform.forward, transform.rotation);        

        myprojectile.GetComponent<Rigidbody>().AddForce(transform.forward * 1000);
        // Destroy
    }

    void DesactivateWeapons(int whichActivate)
    {
        foreach(GameObject aux in weaponsPrefabs)
        {
            aux.SetActive(false);
        }
        weaponsPrefabs[whichActivate].SetActive(true);
    }
}

