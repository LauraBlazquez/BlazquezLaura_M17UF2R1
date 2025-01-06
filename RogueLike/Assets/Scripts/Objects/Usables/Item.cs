using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, IUsable
{
    public float price;
    public string description;
    public Sprite photo;

    public void Use() { }
}
