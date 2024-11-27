using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, IDropeable
{
    private Item[] usables;
    private int coins;
    private Weapon[] weapons;

    public void Drop() { }
}
