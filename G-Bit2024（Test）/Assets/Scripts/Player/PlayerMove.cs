using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������ƶ�
/// </summary>
//public enum PlayerState
//{
//    Idle,          // ����
//    Move,          // �����ƶ�
//    Crouch,        // �¶�
//    Jump,          // һ����
//    Jump2,         // ������
//    Fall,          // ����
//    WallJump,      // ��ǽ��
//    WallIdle,      // ������ǽ��
//    WallClimb,     // ��ǽ
//    Dash,          // һ�γ��
//    Dash2          // ���γ��
//}

public class PlayerMove : MonoBehaviour
{
    public float hori;
    public float ver; // ֻ������ǽ�ͳ��ʱ�Ż��õ�

    private float moveSpeed = 8f;    // �ƶ��ٶ�
    private float spaceForce = 10f;   // ��Ծ����

    private bool canMove = true;
    private bool wallJumped = true;

    public bool onGround;
    public bool onWall;
    public bool onWall2;

    private Rigidbody2D rig;
    private Collider2D col;
    private LayerMask PlayerGround;   // ����ͼ����
    private Vector2 rayDirection;     // ǽ�����߼��

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        PlayerGround = LayerMask.NameToLayer("Ground"); // ����ͼ����Ϊ��Ground��
    }

    private void Update()
    {
        hori = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        Vector2 dir=new Vector2(hori,ver);

        Move(dir);      //��ͨ�ƶ�
    }
    //�ƶ�
    private void Move(Vector2 dir)
    {

        rig.velocity=Vector2.Lerp(rig.velocity,(new Vector2(dir.x*moveSpeed,rig.velocity.y)),5f*Time.deltaTime);
        
    }
    ////��Ծ
    //public void Jump()
    //{
    //    rig.velocity = new Vector2(rig.velocity.x, 0);

    //    rig.velocity += Vector2.up * spaceForce;
    //}
    //// �Ƿ��ڵ���
    //public void IsGround()
    //{
    //    onGround = Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0f, Vector2.down, .1f, 1<<PlayerGround);
    //} 
}