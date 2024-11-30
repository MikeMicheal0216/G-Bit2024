using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
/// <summary>
/// �����ƶ�������
/// </summary>
public class PlayerControl : MonoBehaviour
{
    [Header("Colloder2D")]
    public Vector3 wallOffset;
    public Vector3 groundOffse;
    public Vector3 findPosition;

    public bool isLeftWall,isRightWall;     //��������Ч������Ӱ��
    
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
        //��ת
        FlipSprite();
        
        //ǽ����
        WallCheck();
        //ǽ��
        if (Input.GetKey(KeyCode.LeftControl) && (isLeftWall || isRightWall))
        {
            isWallClimb = true;
        }   
    }
    //ǽ����
    public void WallCheck()
    {
        isLeftWall = Physics2D.OverlapCircle(transform.position + findPosition - wallOffset, 0.1f, wallLayer);

        isRightWall = Physics2D.OverlapCircle(transform.position + findPosition + wallOffset, 0.1f, wallLayer);
    }
    //�����ӻ�
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position + findPosition - wallOffset, 0.1f);
        Gizmos.DrawWireSphere(transform.position + findPosition + wallOffset, 0.1f);
    }
    //ץȡǽ��
    public void WallGrab()
    {
        rig.velocity=Vector2.zero;
    }
    //����
    public void WallClimb()
    {
        rig.velocity=Vector2.zero;

        rig.velocity = new Vector2(rig.velocity.x, climbSpeed);
    }
    //����
    public void WallSlide()
    {
        rig.velocity = Vector2.zero;

        rig.velocity = new Vector2(rig.velocity.x, -climbSpeed-2f); 

    }
    //��ͨ��(������)
    //public void Jump(Vector2 direction)
    //{
    //    rig.velocity = new Vector2(rig.velocity.x, 0);

    //    rig.AddForce(direction * 10f, ForceMode2D.Impulse);

    //    jump_Num++;
    //}
    //ǽ��
    public void WallJump()
    {
        StartCoroutine(DisMove());

        Vector2 dir = isLeftWall ? Vector2.right : Vector2.left;

        //Jump(Vector2.up+dir);


    }
    //��תSprite(ÿ֡)
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
    //(ÿ֡)
    //public void Movement()
    //{
    //    float playerInput = Input.GetAxis("Horizontal");

    //    rig.velocity = new Vector2(playerInput * 5f, rig.velocity.y);
    //}
    // �����ҽӴ������棬������Ծ�ͳ�̴���
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
    //0.3s�ڲ��ܿ������(���ǽ����)
    public IEnumerator DisMove()
    {
        canMove = false;

        yield return new WaitForSeconds(0.3f);

        canMove = true;
    }
    //���
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
    //�����߼�
    public void Death()
    {

    }
}