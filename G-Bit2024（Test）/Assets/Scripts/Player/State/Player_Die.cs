using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Data/PlayerState/Die", fileName = "Player_Die")]
public class Player_Die : PlayerState
{

    public override void Enter()
    {
        animator.Play("Player_Die");

        //µ÷ÓÃËÀÍö´¥·¢

        player.Death();
    }
}
