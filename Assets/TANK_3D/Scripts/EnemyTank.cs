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

    [SerializeField]
    private float moveSpeed = 6.1f;

    [SerializeField]
    private float distanceToInititateAnAttack = 10.1f;
    protected override void Initialize()
    {
        // base.Initialize();
        wonderPoints = GameObject.FindGameObjectsWithTag("wonderPoint");
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        FindNextDestination();
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

    private void StatePatrol() 
    {
        if (Vector3.Distance(transform.position, destinationPos) <= 5f)
        {
            FindNextDestination();
        }
        else if(Vector3.Distance(transform.position,playerTransform.position) <= 20f)
        {
            currentState = FSMState.Chase;
        }
        MoveAndRotateTowardsDestination();
    }
    private void StateChase() 
    {
        destinationPos = playerTransform.position;

        float distanceToAttack = Vector3.Distance(transform.position, playerTransform.position);
        if(distanceToAttack <= distanceToInititateAnAttack)
        {
            currentState = FSMState.Attack;
        }
        else if(distanceToAttack >= distanceToInititateAnAttack +10f)
        {
            currentState = FSMState.Patrol;
        }
        MoveAndRotateTowardsDestination();
    }
    private void StateAttack() { }
    private void StateDead() { }

    private void FindNextDestination()
    {
        int randomIndex = Random.Range(0, wonderPoints.Length);
        destinationPos = wonderPoints[randomIndex].transform.position;
    }

    private void MoveAndRotateTowardsDestination()
    {
        Quaternion targetRotation = Quaternion.LookRotation(destinationPos - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
    }
}
