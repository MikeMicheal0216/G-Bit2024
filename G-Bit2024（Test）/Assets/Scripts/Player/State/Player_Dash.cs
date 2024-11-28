using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Dash", fileName = "Player_Dash")]
public class Player_Dash : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Run");
        if (player.dash_Num < player.max_dash_num)
        {
            player.StartCoroutine(player.Dash());
        }
    }
    public override void LogicUpdate()
    {
        if (!player.isGround)
        {
            stateMachine.SwithState(typeof(Player_Down));
        }
        if (player.isGround&&!player.isWallClimb)
        {
            stateMachine.SwithState(typeof(Player_Idle));
        }
        if (player.isWallClimb && Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.SwithState(typeof(Player_WallGrab));
        }
    }

    public override void PhysicaUpdate()
    {
        
    }
    public override void Exit()
    {
        
    }
}
