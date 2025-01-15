using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public StatesSO CurrentState;
    public int HP;
    public GameObject target;
    public Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            target = collision.gameObject;
        }
        GoToState<ChaseState>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        GoToState<IdleState>();
        target = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GoToState<AttackState>();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        GoToState<ChaseState>();
    }

    public void CheckIfAlive()
    {
        if(HP <= 0)
        {
            GoToState<DieState>();
        }
    }

    private void Update()
    {
        CheckIfAlive();
        CurrentState.OnStateUpdate(this);
    }
    public void GoToState<T>() where T : StatesSO
    {
        if (CurrentState.statesToGo.Find(StatesSO => StatesSO is T))
        {
            CurrentState.OnStateExit(this);
            CurrentState = CurrentState.statesToGo.Find(obj => obj is T);
            CurrentState.OnStateEnter(this);
        }
    }
}
