using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Squat", fileName = "Player_Squat")]
public class Player_Squat : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_DownWalkIdle");
    }
    public override void LogicUpdate()
    {

        if (player.hori != 0)
        {
            stateMachine.SwithState(typeof(Player_SquatWalk));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stateMachine.SwithState(typeof(Player_Idle));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwithState(typeof(Player_Up));
        }
    }
    public override void PhysicaUpdate()
    {

    }
}
