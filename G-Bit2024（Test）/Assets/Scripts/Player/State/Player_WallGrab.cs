using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/WallGrab", fileName = "Player_WallGrab")]
public class Player_WallGrab : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_ClimbIdle");
        player.isWallClimb = true;
        rb.gravityScale = 0;
        
    }
    public override void LogicUpdate()
    {

        if (player.ver != 0)
        {
            stateMachine.SwithState(typeof(Player_WallSlide));
        }
        if (Input.GetKeyDown(KeyCode.Space)&& player.isWallClimb)
        {
            stateMachine.SwithState(typeof(Player_WallJump));
        }
        if (!(player.isLeftWall || player.isRightWall))
        {
            stateMachine.SwithState(typeof(Player_Idle));
        }
    }
    public override void PhysicaUpdate()
    {
        player.WallGrab();
    }
    public override void Exit()
    {
        rb.gravityScale = 3f;
    }
}
