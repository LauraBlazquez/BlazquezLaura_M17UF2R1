using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = "Weapon", menuName = "Objects/Weapon")]
public class Weapon : ScriptableObject
{
    public float damage;
    public float speed;
    public float cooldown;
    public GameObject prefab;
    public float price;
}
