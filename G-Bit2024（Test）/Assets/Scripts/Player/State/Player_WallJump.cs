using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/WallJump", fileName = "Player_WallJump")]
public class Player_WallJump : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Up");
        
        player.WallJump();

    }
    public override void LogicUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            stateMachine.SwithState(typeof(Player_Dash));
        }
        if (rb.velocity.y < 0)
        {
            stateMachine.SwithState(typeof(Player_Down));
        }
        
    }
    public override void PhysicaUpdate()
    {
        
    }
}
