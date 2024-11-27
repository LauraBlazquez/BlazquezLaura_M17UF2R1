using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AEntity : MonoBehaviour, IDamageable, IDropeable
{
    private float hp;
    public float maxHp;
    public float speed;

    public void Attack() { }
    public void GetDamaged() { }
    public void Death() { }
    public void Drop() { }
}
