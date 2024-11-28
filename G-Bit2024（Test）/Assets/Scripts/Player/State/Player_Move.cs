using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Move", fileName = "Player_Move")]
public class Player_Move : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Move");
    }
    public override void LogicUpdate()
    {
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            stateMachine.SwithState(typeof(Player_Idle));
        }
         if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.SwithState(typeof(Player_Up));
        }
         if(rb.velocity.y < -.1f)
        {
            stateMachine.SwithState(typeof(Player_Down));
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
    public override void PhysicaUpdate()
    {
        if (player.hori!=0)
        {
            player.Movement();
        }
    }
}
