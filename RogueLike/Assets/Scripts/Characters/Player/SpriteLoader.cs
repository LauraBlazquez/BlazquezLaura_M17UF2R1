using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    public Weapon weapon;
    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        weapon = GameObject.Find("weaponHolder").GetComponent<PlayerAttack>().equipedWeapon;
        SpriteRenderer photo = weapon.prefab.GetComponent<SpriteRenderer>();
        sr.sprite = photo.sprite;
    }
}
