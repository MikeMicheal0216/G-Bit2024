using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Up", fileName = "Player_Up")]
public class Player_Up : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Up");
        if (player.jump_Num < player.max_jump_num-1 && Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump(Vector2.up);
        }
        
    }
    public override void LogicUpdate()
    {
        if (rb.velocity.y<0)
        {
            stateMachine.SwithState(typeof(Player_Down));
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
        if (player.hori != 0&&!(player.isLeftWall||player.isRightWall))
        {
            rb.velocity=new Vector2(player.hori*5f,rb.velocity.y);
        }
    }
}
