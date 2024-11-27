using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AEntity, ICollectable
{
    private Weapon equipedWeapon;
    private Inventory backpack;

    public void Collect() { }
    public void Buy() { }

}
