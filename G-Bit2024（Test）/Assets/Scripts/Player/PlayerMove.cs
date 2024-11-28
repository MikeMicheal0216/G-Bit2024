using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 人物基础移动
/// </summary>
//public enum PlayerState
//{
//    Idle,          // 待机
//    Move,          // 正常移动
//    Crouch,        // 下蹲
//    Jump,          // 一段跳
//    Jump2,         // 二段跳
//    Fall,          // 下落
//    WallJump,      // 蹬墙跳
//    WallIdle,      // 附着在墙上
//    WallClimb,     // 爬墙
//    Dash,          // 一段冲刺
//    Dash2          // 二段冲刺
//}

public class PlayerMove : MonoBehaviour
{
    public float hori;
    public float ver; // 只有在爬墙和冲刺时才会用到

    private float moveSpeed = 8f;    // 移动速度
    private float spaceForce = 10f;   // 跳跃力度

    private bool canMove = true;
    private bool wallJumped = true;

    public bool onGround;
    public bool onWall;
    public bool onWall2;

    private Rigidbody2D rig;
    private Collider2D col;
    private LayerMask PlayerGround;   // 地面图层名
    private Vector2 rayDirection;     // 墙体射线检测

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        PlayerGround = LayerMask.NameToLayer("Ground"); // 地面图层名为“Ground”
    }

    private void Update()
    {
        hori = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        Vector2 dir=new Vector2(hori,ver);

        Move(dir);      //普通移动
    }
    //移动
    private void Move(Vector2 dir)
    {

        rig.velocity=Vector2.Lerp(rig.velocity,(new Vector2(dir.x*moveSpeed,rig.velocity.y)),5f*Time.deltaTime);
        
    }
    ////跳跃
    //public void Jump()
    //{
    //    rig.velocity = new Vector2(rig.velocity.x, 0);

    //    rig.velocity += Vector2.up * spaceForce;
    //}
    //// 是否在地面
    //public void IsGround()
    //{
    //    onGround = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, 1<<PlayerGround);
    //} 
}