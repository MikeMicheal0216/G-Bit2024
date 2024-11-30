using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Up", fileName = "Player_Up")]
public class Player_Up : PlayerState
{
    public override void Enter()
    {
        animator.Play("Player_Up");
        //if (player.jump_Num < player.max_jump_num-1 && Input.GetKeyDown(KeyCode.Space))
        //{
        //    player.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        //}
        
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
        if ((player.isWallClimb|| (stateMachine.gameObject.GetComponent<PlayerControl>().isLeftWall || stateMachine.gameObject.GetComponent<PlayerControl>().isRightWall)) && Input.GetKey(KeyCode.LeftControl))
        {
            stateMachine.SwithState(typeof(Player_WallGrab));
        }
        
    }
    public override void PhysicaUpdate()
    {
        player.GetComponent<TarodevController.PlayerControl2>().ApplyMovement();
    }
}
