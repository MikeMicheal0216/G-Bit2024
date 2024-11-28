using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/SquatWalk", fileName = "Player_SquatWalk")]
public class Player_SquatWalk : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_DownWalk");
    }
    public override void LogicUpdate()
    {
        if (player.hori == 0)
        {
            stateMachine.SwithState(typeof(Player_Squat));
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
        rb.velocity = new Vector2(player.hori*3f, 0);
    }
}
