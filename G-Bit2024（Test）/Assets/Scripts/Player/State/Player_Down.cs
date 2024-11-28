using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Down", fileName = "Player_Down")]
public class Player_Down : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Down");
    }
    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwithState(typeof(Player_Up));
        }
        if (player.isGround)
        { 
            if (player.hori != 0)
            {
                stateMachine.SwithState(typeof(Player_Move));
            }
            else
            {
                stateMachine.SwithState(typeof(Player_Idle));
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.SwithState(typeof(Player_Dash));
        }
        if (player.isWallClimb && Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.SwithState(typeof(Player_WallGrab));
        }
    }
    public override void PhysicaUpdate()
    {
        
    }
}
