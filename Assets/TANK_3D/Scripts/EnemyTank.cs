using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2022.11.7
/// 
/// EnemyTank AI
/// </summary>
public class EnemyTank : Fsm
{
    public enum FSMState
    {
        Patrol,
        Chase,
        Attack,
        Dead
    }

    [SerializeField]
    private FSMState currentState = FSMState.Patrol;
    protected override void Initialize()
    {
        // base.Initialize();
        wonderPoints = GameObject.FindGameObjectsWithTag("wonderPoint");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected override void FMSUpdate()
    {
       // base.FMSUpdate();
       switch(currentState)
        {
            case FSMState.Patrol: StatePatrol(); break;
            case FSMState.Chase: StateChase(); break;
            case FSMState.Attack: StateAttack(); break;
            case FSMState.Dead: StateDead(); break;
        }
    }

    private void StatePatrol() { }
    private void StateChase() { }
    private void StateAttack() { }
    private void StateDead() { }

    private void FindNextDestination()
    {

    }
}
