using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;
/// <summary>
/// ��Ϸ��ʼ��
/// </summary>
public class GameUnitManager : MonoBehaviour
{
    public static GameUnitManager Instance;

    protected Save_Data sdata;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        sdata = SaveManager.instance.GetData() ?? null;
    }
    public void UnitScene<T>(string scenename)where T:SceneBase
    {
        LevelManager.Instance.InitTilemap<T>(scenename);

        //LevelManager.Instance.InitTilemap<BackGround>("BackGround");
    }
    //ʵ�������(��Ҫ������)
    public void UnitPlayer()
    {
        
        GameObject pla = Instantiate(Resources.Load("Player/Player"), null) as GameObject;

        Vector3 spawnPosition = sdata.savePoint;

        pla.transform.position = spawnPosition;

        pla.name = "Player";

        pla.tag = "Player";

        StartCoroutine(UpdatePosition());
    }
    //ʵ����������ת��
    public void UnitScenePoint()
    {
        GameObject point=Instantiate(Resources.Load("Tilemap/ChangeCamera"),null) as GameObject;

        point.name = "ChangeCamera";
    }
    //ʵ�����浵��
    public void UnitSavePoint()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/Point_Save"), null) as GameObject;

        point.name = "Point_Save";
    }
    //ʵ�������ܹ�ʵ����Ҫ�����ݣ�
    public void UnitPlayer_A()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/Player_A"), null) as GameObject;

        point.name = "Player_A";
    }
    public void UniitLight()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/Light_Y"), null) as GameObject;

        point.name = "Light_Y";

    }
    public void UnitBrain()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/BrainParent"), null) as GameObject;

        point.name = "BrainParent";

    }
    public void UnitMeninges()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/MeningesParent"), null) as GameObject;

        point.name = "MeningesParent";
    }
    public void UnitSarcoma()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/SarcomaParent"), null) as GameObject;

        point.name = "SarcomaParent";
    }
    //��ϸ��
    public void UnitCellGun()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/CellGun"), null) as GameObject;

        point.name = "CellGun";
    }
    public void UnitMedulla()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/MedullaParent"), null) as GameObject;

        point.name = "Medulla";
    }
    //���λ���Ƿ����
    IEnumerator UpdatePosition()
    {
        Transform player = GameObject.Find("Player").transform;
        player.position = sdata.savePoint;
        yield return new WaitForSeconds(0.01f);
        StopCoroutine(UpdatePosition());
    }
}
