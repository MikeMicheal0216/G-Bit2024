using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 主角简单移动（测试）
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private float hori;
    //速度
    private float moveSpeed = 5f;
    //跳跃
    private float spaceForce = 4f;

    private Rigidbody2D rig;
    private Collider2D col;

    //地面图层名
    private LayerMask PlayerGround;

     public void Start()
    {
        rig =GetComponent<Rigidbody2D>();

        col =GetComponent<Collider2D>();

        PlayerGround = LayerMask.NameToLayer("Ground");//地面图层名为“Ground”

    }
    private void Update()
    {
        GetMove();
    }
    public void GetMove()
    {
        hori = Input.GetAxisRaw("Horizontal");

        rig.velocity = new Vector2(hori*moveSpeed, rig.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)&&IsGround())
        {
            rig.velocity = new Vector2(rig.velocity.x, spaceForce);
        }
    }
    //是否在地面
    public bool IsGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0,Vector2.down,.1f,1<<PlayerGround);
    }
}
