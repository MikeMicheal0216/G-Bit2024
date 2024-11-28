using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/WallSlide", fileName = "Player_WallSlide")]
public class Player_WallSlide : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Climb");
        player.isWallClimb = true;
        rb.gravityScale = 3f;

    }
    public override void LogicUpdate()
    {
        if (player.ver == 0)
        {
            stateMachine.SwithState(typeof(Player_WallGrab));
        }
        if (Input.GetKeyDown(KeyCode.Space)&&player.isWallClimb)
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
        if (player.ver < 0)
        {
            player.WallSlide();
        }
        if (player.ver > 0)
        {
            player.WallClimb();
        }
    }
}
