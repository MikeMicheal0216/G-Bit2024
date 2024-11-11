using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���Ǽ��ƶ������ԣ�
/// </summary>
public class PlayerMove : MonoBehaviour
{
    private float hori;
    //�ٶ�
    private float moveSpeed = 5f;
    //��Ծ
    private float spaceForce = 4f;

    private Rigidbody2D rig;
    private Collider2D col;

    //����ͼ����
    private LayerMask PlayerGround;

     public void Start()
    {
        rig =GetComponent<Rigidbody2D>();

        col =GetComponent<Collider2D>();

        PlayerGround = LayerMask.NameToLayer("Ground");//����ͼ����Ϊ��Ground��

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
    //�Ƿ��ڵ���
    public bool IsGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0,Vector2.down,.1f,1<<PlayerGround);
    }
}
