using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="PreSpawnState", menuName ="StatesSO/PreSpawn")]

public class PreSpawnState : StatesSO
{
    public override void OnStateEnter(EnemyController ec)
    {
        ec.animator.SetTrigger("Spawned");
    }

    public override void OnStateExit(EnemyController ec)
    {
    }

    public override void OnStateUpdate(EnemyController ec)
    {
    }
}
