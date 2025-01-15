using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviour : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Chase(Transform target, Transform self)
    {
        rb.velocity = (target.position - self.position).normalized * speed;
    }

    public void StopChasing()
    {
        rb.velocity = Vector2.zero;
    }
}
