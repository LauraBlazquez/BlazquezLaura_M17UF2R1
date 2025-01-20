using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scissors : MonoBehaviour
{
    private Vector2 direction;
    private Rigidbody2D rb;
    private Weapon weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = GameObject.Find("weaponHolder").GetComponent<PlayerAttack>().equipedWeapon;
        direction = transform.right;
    }

    private void Update()
    {
        rb.velocity = direction * weapon.speed;
    }

}
