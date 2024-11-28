using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Idle", fileName = "Player_Idle")]
public class Player_Idle : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Idle");
    }
    public override void LogicUpdate()
    {
        if (player.hori!=0)
        {
            stateMachine.SwithState(typeof(Player_Move));
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwithState(typeof(Player_Up));
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.SwithState(typeof(Player_Dash));
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            stateMachine.SwithState(typeof(Player_Squat));
        }
    }
}
