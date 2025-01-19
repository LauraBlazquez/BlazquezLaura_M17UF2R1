using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Store : MonoBehaviour
{
    private bool playerInRange = false;
    private PlayerController playerController;

    private void Update()
    {

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //if (playerController.coinCollector >= )
            //{

            //}
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInRange = false;
        }
    }
}
