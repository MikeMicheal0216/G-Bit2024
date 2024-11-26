using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 人物基础移动（能力等青女写完）
/// </summary>
public enum PlayerState
{
    Idle,          // 待机
    Move,          // 正常移动
    Crouch,        // 下蹲
    Jump,          // 一段跳
    Jump2,         // 二段跳
    Fall,          // 下落
    WallJump,      // 蹬墙跳
    WallIdle,      // 附着在墙上
    WallClimb,     // 爬墙
    Dash,          // 一段冲刺
    Dash2          // 二段冲刺
}

public class PlayerMove : MonoBehaviour
{
    private float hori;
    private float ver; // 只有在爬墙和冲刺时才会用到

    public float moveSpeed = 10f;    // 移动速度
    public float spaceForce = 10f;   // 跳跃力度
    //private float spaceForce2 = 3f;  // 二段跳力度
    //private float wallJump = 3f;     // 蹬墙跳力度
    //private float climbSpeed;        // 爬墙速度
    //private float dashSpeed = 5f;    // 冲刺速度
    //private float dashSpeed2 = 5f;   // 二段冲刺速度
    //private float dashTime = 0.2f;   // 冲刺时间
    //private float coldTime = 0.5f;   // 一段冲刺冷却时间

    private Rigidbody2D rig;
    private Collider2D col;
    private LayerMask PlayerGround;   // 地面图层名
    private Vector2 rayDirection;     // 墙体射线检测
    //private PlayerState playerState;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        PlayerGround = LayerMask.NameToLayer("Ground"); // 地面图层名为“Ground”
        //playerState = PlayerState.Idle;
    }

    private void Update()
    {
        Move();
        //UpdatePlayerState();
    }
    //移动、跳跃
    private void Move()
    {
        //float currentSpace = 0; //当前跳跃次数

        hori = Input.GetAxisRaw("Horizontal");

        ver = Input.GetAxisRaw("Vertical");

        rig.velocity = new Vector2(hori*moveSpeed,rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGround())
        {
            rig.velocity = new Vector2(rig.velocity.x,spaceForce);
        }

        //if (Input.GetKeyDown(KeyCode.Space)&&(IsGround()||currentSpace==1f))
        //{

            //    switch (currentSpace)
            //    {
            //        case 0:

            //            playerState = PlayerState.Jump;

            //            rig.velocity = new Vector2(rig.velocity.x, spaceForce);

            //            break;
            //        case 1:

            //            playerState = PlayerState.Jump2;

            //            rig.velocity = new Vector2(rig.velocity.x, spaceForce2);

            //            if (IsGround())
            //            {
            //                currentSpace = 0;
            //            }
            //            break;

            //        case 2:

            //            currentSpace = 0;

            //            break;
            //        default:
            //            break;
            //    }            
            //    currentSpace++;

            //}

            //// 根据玩家移动方向改变射线检测方向
            //rayDirection = hori > 0 ? Vector2.right : (hori < 0 ? Vector2.left : Vector2.zero);
    }
    //public void UpdatePlayerState()
    //{ 
    //    Debug.Log(playerState);
        
    //    switch (playerState)
    //    {
    //        case PlayerState.Idle:
    //            OnIdle();
    //            break;
    //        case PlayerState.Move:
    //            OnMove();
    //            break;
    //        case PlayerState.Crouch:
    //            OnCrouch();
    //            break;
    //        case PlayerState.Jump:
    //            OnJump();
    //            break;
    //        case PlayerState.Jump2:
    //            OnJump2();
    //            break;
    //        case PlayerState.Fall:
    //            OnFall();
    //            break;
    //        case PlayerState.WallJump:
    //            OnWallJump();
    //            break;
    //        case PlayerState.WallIdle:
    //            OnWallIdle();
    //            break;
    //        case PlayerState.WallClimb:
    //            OnWallClimb();
    //            break;
    //        case PlayerState.Dash:
    //            OnDash();
    //            break;
    //        case PlayerState.Dash2:
    //            OnDash2();
    //            break;
    //        default:
    //            break;
    //    }
    //}

    //// 待机状态(可以切换到移动、跳跃、下蹲)
    //void OnIdle()
    //{
        

    //    //if (hori != 0)
    //    //{
    //    //    playerState = PlayerState.Move;
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.Space) && IsGround())
    //    //{
    //    //    playerState = PlayerState.Jump;

    //    //    rig.velocity = new Vector2(rig.velocity.x, spaceForce);
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.S))
    //    //{
    //    //    playerState = PlayerState.Crouch;
    //    //}
    //}

    //// 正常移动状态（可以切换到待机、下蹲、附在墙上、跳跃、冲刺）
    //void OnMove()
    //{
    //    rig.velocity = new Vector2(hori * moveSpeed, rig.velocity.y);

    //    //if (Input.GetKeyDown(KeyCode.S))
    //    //{
    //    //    playerState = PlayerState.Crouch;
    //    //}
    //    //else if (IsWall() && !IsGround())
    //    //{
    //    //    playerState = PlayerState.WallIdle;
    //    //}
    //    //else if (hori == 0)
    //    //{
    //    //    playerState = PlayerState.Idle;
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.Space) && IsGround())
    //    //{
    //    //    playerState = PlayerState.Jump;
            
    //    //    rig.velocity = new Vector2(rig.velocity.x, spaceForce);
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.LeftShift))
    //    //{
    //    //    playerState = PlayerState.Dash;
    //    //}
    //}

    //// 下蹲状态
    //void OnCrouch()
    //{
    //    // 下蹲逻辑
    //}

    //// 一段跳状态（可以切换到二段跳、冲刺、附在墙上）
    //void OnJump()
    //{

    //    //if (Input.GetKeyDown(KeyCode.Space))
    //    //{
    //    //    playerState = PlayerState.Jump2;

    //    //    rig.velocity = new Vector2(rig.velocity.x, spaceForce2);
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.LeftShift))
    //    //{
    //    //    playerState = PlayerState.Dash;
    //    //}
    //    //else if (IsWall() && !IsGround())
    //    //{
    //    //    playerState = PlayerState.WallIdle;
    //    //}
    //    //else if (IsGround())
    //    //{
    //    //    playerState = PlayerState.Idle;
    //    //}
    //}

    //// 二段跳状态（可以切换到冲刺、附在墙上）
    //void OnJump2()
    //{
    //    //if (Input.GetKeyDown(KeyCode.LeftShift))
    //    //{
    //    //    playerState = PlayerState.Dash;
    //    //}
    //    //else if (IsWall() && !IsGround())
    //    //{
    //    //    playerState = PlayerState.WallIdle;
    //    //}
    //    //else if (IsGround())
    //    //{
    //    //    playerState = PlayerState.Idle;
    //    //}
    //}

    //// 下落状态
    //void OnFall()
    //{
    //    // 下落逻辑
    //}

    //// 蹬墙跳状态（可以切换到待机）
    //void OnWallJump()
    //{
    //    rig.velocity = new Vector2(-rayDirection.x * wallJump, spaceForce);
    //}

    //// 附着在墙上状态
    //void OnWallIdle()
    //{
    //    //if (Input.GetKeyDown(KeyCode.LeftControl))
    //    //{
    //    //    playerState = PlayerState.WallClimb;
    //    //}
    //    //else if (Input.GetKeyDown(KeyCode.Space))
    //    //{
    //    //    playerState = PlayerState.WallJump;
    //    //}
    //}

    //// 爬墙状态
    //void OnWallClimb()
    //{
    //    rig.velocity = new Vector2(0, ver * climbSpeed);

    //    //if (Input.GetKeyDown(KeyCode.Space))
    //    //{
    //    //    playerState = PlayerState.WallJump;
    //    //}
    //}

    //// 一段冲刺状态（可以切换到二段冲刺、附在墙上、待机）
    //void OnDash()
    //{
    //    if (Input.GetKeyDown(KeyCode.LeftShift))
    //    {
    //        StartCoroutine(PlayerDash());
    //    }

    //    //if (Input.GetKeyDown(KeyCode.LeftControl))
    //    //{
    //    //    playerState = PlayerState.Dash2;
    //    //}
    //    //else if (IsWall())
    //    //{
    //    //    playerState = PlayerState.WallIdle;
    //    //}
    //    //else if (hori == 0)
    //    //{
    //    //    playerState = PlayerState.Idle;
    //    //}
    //}

    //// 二段冲刺状态（可以切换到附在墙上、待机)
    //void OnDash2()
    //{
    //    //if (IsWall()&&!IsGround())
    //    //{
    //    //    playerState = PlayerState.WallIdle;
    //    //}
    //    //else if (hori == 0)
    //    //{
    //    //    playerState = PlayerState.Idle;
    //    //}
    //}

    //// 冲刺协程
    //IEnumerator PlayerDash()
    //{
    //    // 冲刺逻辑
    //    yield return new WaitForSeconds(dashTime);
    //}

    // 是否在地面
    public bool IsGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, .1f, 1 << PlayerGround);
    }

    // 是否贴墙
    public bool IsWall()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, rayDirection, .1f, 1 << PlayerGround);
    }
}