using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChaseState", menuName = "StatesSO/Chase")]

public class ChaseState : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.animator.SetBool("isWalking", true);
    }

    public override void OnStateExit(EnemyController ec)
    {
        ec.animator.SetBool("isWalking", false);
        ec.GetComponent<ChaseBehaviour>().StopChasing();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        ec.GetComponent<ChaseBehaviour>().Chase(ec.target.transform, ec.transform);
    }
}
