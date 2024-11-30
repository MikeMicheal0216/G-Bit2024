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

        GameUnitManager.Instance.UnitPlayer();      //初始化玩家

        GameUnitManager.Instance.UnitScenePoint();      //初始化场景转折点

        GameUnitManager.Instance.UnitSavePoint();       //初始化存档点

        GameUnitManager.Instance.UnitPlayer_A();        //初始化技能果实

        GameUnitManager.Instance.UniitLight();      //初始化灵光

        GameUnitManager.Instance.UnitBrain();       //脑神经

        GameUnitManager.Instance.UnitScene<BackGround>("BackGround");

        GameUnitManager.Instance.UnitMeninges();        //脑膜

        GameUnitManager.Instance.UnitSarcoma();         //肉瘤

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
