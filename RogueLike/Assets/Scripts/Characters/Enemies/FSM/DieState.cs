using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DieState", menuName = "StatesSO/Die")]

public class DieState : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.animator.SetBool("isDead",true);
        Destroy(ec.gameObject);
    }

    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
}
