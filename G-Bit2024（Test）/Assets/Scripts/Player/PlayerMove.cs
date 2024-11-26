using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������ƶ�����������Ůд�꣩
/// </summary>
public enum PlayerState
{
    Idle,          // ����
    Move,          // �����ƶ�
    Crouch,        // �¶�
    Jump,          // һ����
    Jump2,         // ������
    Fall,          // ����
    WallJump,      // ��ǽ��
    WallIdle,      // ������ǽ��
    WallClimb,     // ��ǽ
    Dash,          // һ�γ��
    Dash2          // ���γ��
}

public class PlayerMove : MonoBehaviour
{
    private float hori;
    private float ver; // ֻ������ǽ�ͳ��ʱ�Ż��õ�

    public float moveSpeed = 10f;    // �ƶ��ٶ�
    public float spaceForce = 10f;   // ��Ծ����
    //private float spaceForce2 = 3f;  // ����������
    //private float wallJump = 3f;     // ��ǽ������
    //private float climbSpeed;        // ��ǽ�ٶ�
    //private float dashSpeed = 5f;    // ����ٶ�
    //private float dashSpeed2 = 5f;   // ���γ���ٶ�
    //private float dashTime = 0.2f;   // ���ʱ��
    //private float coldTime = 0.5f;   // һ�γ����ȴʱ��

    private Rigidbody2D rig;
    private Collider2D col;
    private LayerMask PlayerGround;   // ����ͼ����
    private Vector2 rayDirection;     // ǽ�����߼��
    //private PlayerState playerState;

    public void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        PlayerGround = LayerMask.NameToLayer("Ground"); // ����ͼ����Ϊ��Ground��
        //playerState = PlayerState.Idle;
    }

    private void Update()
    {
        Move();
        //UpdatePlayerState();
    }
    //�ƶ�����Ծ
    private void Move()
    {
        //float currentSpace = 0; //��ǰ��Ծ����

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

            //// ��������ƶ�����ı����߼�ⷽ��
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

    //// ����״̬(�����л����ƶ�����Ծ���¶�)
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

    //// �����ƶ�״̬�������л����������¶ס�����ǽ�ϡ���Ծ����̣�
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

    //// �¶�״̬
    //void OnCrouch()
    //{
    //    // �¶��߼�
    //}

    //// һ����״̬�������л�������������̡�����ǽ�ϣ�
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

    //// ������״̬�������л�����̡�����ǽ�ϣ�
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

    //// ����״̬
    //void OnFall()
    //{
    //    // �����߼�
    //}

    //// ��ǽ��״̬�������л���������
    //void OnWallJump()
    //{
    //    rig.velocity = new Vector2(-rayDirection.x * wallJump, spaceForce);
    //}

    //// ������ǽ��״̬
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

    //// ��ǽ״̬
    //void OnWallClimb()
    //{
    //    rig.velocity = new Vector2(0, ver * climbSpeed);

    //    //if (Input.GetKeyDown(KeyCode.Space))
    //    //{
    //    //    playerState = PlayerState.WallJump;
    //    //}
    //}

    //// һ�γ��״̬�������л������γ�̡�����ǽ�ϡ�������
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

    //// ���γ��״̬�������л�������ǽ�ϡ�����)
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

    //// ���Э��
    //IEnumerator PlayerDash()
    //{
    //    // ����߼�
    //    yield return new WaitForSeconds(dashTime);
    //}

    // �Ƿ��ڵ���
    public bool IsGround()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, Vector2.down, .1f, 1 << PlayerGround);
    }

    // �Ƿ���ǽ
    public bool IsWall()
    {
        return Physics2D.BoxCast(col.bounds.center, col.bounds.size, 0, rayDirection, .1f, 1 << PlayerGround);
    }
}