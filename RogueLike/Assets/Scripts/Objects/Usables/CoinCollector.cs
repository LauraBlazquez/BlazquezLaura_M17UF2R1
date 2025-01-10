using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : Item
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            PlayerController.coinCollector++;
            Destroy(gameObject);
        }
    }
}
