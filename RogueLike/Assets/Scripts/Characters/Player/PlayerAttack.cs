using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Weapon equipedWeapon;
    public GameObject projectile;

    private void Update()
    {
        projectile = equipedWeapon.prefab;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(projectile, transform.position, GameObject.Find("Player").transform.rotation);
        }
    }
}
