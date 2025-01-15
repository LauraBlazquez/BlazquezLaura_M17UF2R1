using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IdleState", menuName = "StatesSO/Idle")]

public class IdleState : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateExit(EnemyController ec)
    {
        throw new System.NotImplementedException();
    }

    public override void OnStateUpdate(EnemyController ec)
    {
        //ec.GetComponent<ChaseBehaviour>().StopChasing();
    }
}
