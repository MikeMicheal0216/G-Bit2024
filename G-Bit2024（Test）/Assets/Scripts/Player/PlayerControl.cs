using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// 人物移动及能力
/// </summary>
public class PlayerControl : MonoBehaviour
{
    [Header("Colloder2D")]
    public Vector3 wallOffset;
    public Vector3 groundOffse;
    public Vector3 findPosition;

    public bool isLeftWall,isRightWall;     //作用粒子效果（残影）
    
    public bool isSquating;
    public bool canMove=true;

    [Header("Jump")]
    public bool canJump = false;

    public bool isGround = false;

    [Header("Die")]
    public bool isDie;

    [Header("Dash")]
    public bool canDash = true;
    public bool isDashing;
    public float dashingPower = 20f;
    public float dashingTime=0.1f;
    public float noDash = 1f;
    public Vector2 dirDash;

    public float ver;
    public float hori;
    [Header("WallAction")]
    public bool isWallClimb;
    public float climbSpeed=6f;

    public float playerInput;

    [Header("number")]
    public int jump_Num=0;
    public int max_jump_num = 2;
    public int dash_Num=0;
    public int max_dash_num = 2;

    public LayerMask wallLayer;

    [Header("Component")]
    private SpriteRenderer playersprite;
    private Rigidbody2D rig;
    private Collider2D col;

    
    private void Start()
    {
        rig= GetComponent<Rigidbody2D>();

        col = GetComponent<Collider2D>();

        wallLayer = LayerMask.GetMask("Ground");

        playersprite=GetComponent<SpriteRenderer>();

    }

    private void Update()
    {

        ver = Input.GetAxisRaw("Vertical");
        hori = Input.GetAxisRaw("Horizontal");
        dirDash = new Vector2(hori, ver);

        if (isDashing) return;
        //翻转
        FlipSprite();
        
        //墙体检测
        WallCheck();
        //墙爬
        if (Input.GetKey(KeyCode.LeftControl) && (isLeftWall || isRightWall))
        {
            isWallClimb = true;
        }   
    }
    //墙体检测
    public void WallCheck()
    {
        isLeftWall = Physics2D.OverlapCircle(transform.position + findPosition - wallOffset, 0.1f, wallLayer);

        isRightWall = Physics2D.OverlapCircle(transform.position + findPosition + wallOffset, 0.1f, wallLayer);
    }
    //检测可视化
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + findPosition - wallOffset, 0.1f);
        Gizmos.DrawWireSphere(transform.position + findPosition + wallOffset, 0.1f);
    }
    //抓取墙壁
    public void WallGrab()
    {
        rig.velocity=Vector2.zero;
    }
    //攀爬
    public void WallClimb()
    {
        rig.velocity=Vector2.zero;

        rig.velocity = new Vector2(rig.velocity.x, climbSpeed);
    }
    //滑行
    public void WallSlide()
    {
        rig.velocity = Vector2.zero;

        rig.velocity = new Vector2(rig.velocity.x, -climbSpeed-2f); 

    }
    //普通跳(二段跳)
    //public void Jump(Vector2 direction)
    //{
    //    rig.velocity = new Vector2(rig.velocity.x, 0);

    //    rig.AddForce(direction * 10f, ForceMode2D.Impulse);

    //    jump_Num++;
    //}
    //墙跳
    public void WallJump()
    {
        StartCoroutine(DisMove());

        Vector2 dir = isLeftWall ? Vector2.right : Vector2.left;

        //Jump(Vector2.up+dir);


    }
    //翻转Sprite(每帧)
    void FlipSprite()
    {
        if (rig.velocity.x > .1f)
        {
            playersprite.flipX = false;
        }
        else if(rig.velocity.x < -.1f)
        {
            playersprite.flipX=true;
        }
    }
    //(每帧)
    //public void Movement()
    //{
    //    float playerInput = Input.GetAxis("Horizontal");

    //    rig.velocity = new Vector2(playerInput * 5f, rig.velocity.y);
    //}
    // 如果玩家接触到地面，重置跳跃和冲刺次数
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & wallLayer) != 0)
        {
            isGround = true;
            jump_Num = 0;
            dash_Num = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (((1 << collision.gameObject.layer) & wallLayer) != 0)
        {
            isGround = false;
        }
    }
    //0.3s内不能控制玩家(检测墙跳后)
    public IEnumerator DisMove()
    {
        canMove = false;

        yield return new WaitForSeconds(0.3f);

        canMove = true;
    }
    //冲刺
    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float dashingGravity = rig.gravityScale;
        rig.gravityScale = 0f;

        rig.velocity = dirDash*dashingPower;


        yield return new WaitForSeconds(dashingTime);

        rig.gravityScale = dashingGravity;
        isDashing = false;
        canDash = true;
        dash_Num++;
        StopCoroutine(Dash());
    }
    //死亡逻辑
    public void Death()
    {

    }
}