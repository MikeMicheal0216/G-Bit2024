//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
///// <summary>
///// ���ﶯ��
///// </summary>

//public enum PlaState
//{
//    Idle,       //����
//    Move,       //�ƶ�
//    Squat,      //���´���
//    SquatWalk,       //��������
//    Jump,       //��Ծ
//    WallJump,   //��ǽ��
//    Dush,       //���
//    WallGrab,   //ץǽ
//    WallSlide,  //ǽ����
//    WallClimb,  //��ǽ
//    Die,        //����
//    none

//}

//public class PlayerAnimation : MonoBehaviour
//{
//    private Animator anim;

//    public PlaState ps;

//    private void Start()
//    {

//        anim = GetComponent<Animator>();
//    }
//    private void Update()
//    {
//        SwithWallAnim();
//    }
//    void SwithWallAnim()
//    {
//        switch (ps)
//        {
//            case PlaState.Idle:
//                anim.SetInteger("PlayerState", 1);
//                break;
//            case PlaState.Move:
//                anim.SetInteger("PlayerState", 2);
//                break;
//            case PlaState.Squat:
//                anim.SetInteger("PlayerState", 3);
//                break;
//            case PlaState.SquatWalk:
//                anim.SetInteger("PlayerState", 4);
//                break;
//            case PlaState.Jump:
//                anim.SetInteger("PlayerState", 5);
//                break;
//            case PlaState.WallJump:
//                anim.SetInteger("PlayerState", 5);       //��Ҫ�������
//                break;
//            case PlaState.Dush:
//                anim.SetInteger("PlayerState", 6);
//                break;
//            case PlaState.WallGrab:
//                anim.SetInteger("PlayerState", 7);
//                break;
//            case PlaState.WallSlide:
//                anim.SetInteger("PlayerState", 7);
//                break;
//            case PlaState.WallClimb:
//                anim.SetInteger("PlayerState", 8);
//                break;
//            case PlaState.Die:
//                anim.SetInteger("PlayerState", 9);
//                break;
//            case PlaState.none:
//                break;
//            default:
//                break;
//        }

//    }
//}
