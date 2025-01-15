using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AttackState", menuName = "StatesSO/Attack")]

public class AttackState : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.animator.SetBool("isWalking", false);
        ec.animator.SetTrigger("PlayerTouched");
        Destroy(ec.gameObject);
    }

    public override void OnStateExit(EnemyController ec)
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        throw new System.NotImplementedException();
    }
}
