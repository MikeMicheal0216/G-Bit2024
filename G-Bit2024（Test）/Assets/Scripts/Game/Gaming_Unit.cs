using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gaming_Unit : GamingUnit
{
    public CameraControl cameramain;

    public void Start()
    {
        _Data = SaveManager.instance.GetData();
    }
    public override void Init()
    {

        GameUnitManager.Instance.UnitPlayer();      //��ʼ�����

        GameUnitManager.Instance.UnitScenePoint();      //��ʼ������ת�۵�

        GameUnitManager.Instance.UnitSavePoint();       //��ʼ���浵��

        GameUnitManager.Instance.UnitPlayer_A();        //��ʼ�����ܹ�ʵ

        GameUnitManager.Instance.UniitLight();      //��ʼ�����

        GameUnitManager.Instance.UnitBrain();       //����

        GameUnitManager.Instance.UnitScene<BackGround>("BackGround");

        GameUnitManager.Instance.UnitMeninges();        //��Ĥ

        GameUnitManager.Instance.UnitSarcoma();         //����

        GameUnitManager.Instance.UnitCellGun();

        GameUnitManager.Instance.UnitMedulla();

        cameramain = GameObject.Find("Main Camera").GetComponent<CameraControl>();

        cameramain.enabled = true;
    }
    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
