using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Idle,
    Waiting,
    Follow,
    Die,
    Attack
}

public enum EnemyType
{
    Melee,
    Ranged
}

public class EnemyController : MonoBehaviour
{
    GameObject player;
    //GameObject enemy;
    public EnemyState currentState = EnemyState.Waiting;
    public float range;
    public float attackRange;
    public float speed;
    public bool notInRoom = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        switch(currentState)
        {
            case EnemyState.Idle:
                Idle();
            break;
            case EnemyState.Waiting:
                Waiting();
            break;
            case EnemyState.Follow:
                Follow();
            break;
            case EnemyState.Die:
                Die();
            break;
        }

        if (!notInRoom)
        {
            if(IsPlayerInRange(range) && currentState != EnemyState.Die)
            {
                currentState = EnemyState.Follow;
            }
            else if(!IsPlayerInRange(range) && currentState != EnemyState.Die)
            {
                currentState = EnemyState.Idle;
            }
            if(Vector3.Distance(transform.position, player.transform.position) <= attackRange)
            {
                currentState = EnemyState.Attack;
            }
        }
        else
        {
            //setActive del enemigo = false
        }

    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    void Idle()
    {

    }

    void Waiting()
    {
        transform.position += -transform.right * speed * Time.deltaTime;
        if (IsPlayerInRange(range))
        {
            //Animator hace animacion de Spawn        
            currentState = EnemyState.Follow;
        }
    }

    void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void Die()
    {
        //Animator hace animación de Muerte
        Destroy(gameObject);
    }
}
