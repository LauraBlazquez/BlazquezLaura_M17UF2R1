using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : AEntity
{
    public GameObject target;
    public float attackSpeed;
    public Item[] drops;
}
