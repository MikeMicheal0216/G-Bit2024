using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;
/// <summary>
/// 游戏初始化
/// </summary>
public class GameUnitManager : MonoBehaviour
{
    public static GameUnitManager Instance;

    protected Save_Data sdata;

    private void Awake()
    {
        Instance = this;
        sdata = SaveManager.instance.GetData();
    }
    public void UnitScene<T>(string scenename)where T:SceneBase
    {
        SceneManager.Instance.InitTilemap<T>(scenename);

        SceneManager.Instance.InitTilemap<BackGround>("BackGround");
    }
    //实例化玩家(需要存数据)
    public void UnitPlayer()
    {
        
        GameObject pla = Instantiate(Resources.Load("Player/Player"), null) as GameObject;

        Vector3 spawnPosition = sdata.savePoint;

        pla.transform.position = spawnPosition;

        pla.name = "Player";

        pla.tag = "Player";

        StartCoroutine(UpdatePosition());
    }
    //实例化场景跳转点
    public void UnitScenePoint()
    {
        GameObject point=Instantiate(Resources.Load("Tilemap/ChangeCamera"),null) as GameObject;

        point.name = "ChangeCamera";
    }
    //实例化存档点
    public void UnitSavePoint()
    {
        GameObject point = Instantiate(Resources.Load("Tilemap/Point_Save"), null) as GameObject;

        point.name = "Point_Save";
    }
    //实例化技能果实（需要存数据）
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
    //检测位置是否合理
    IEnumerator UpdatePosition()
    {
        Transform player = GameObject.Find("Player").transform;
        player.position = sdata.savePoint;
        Debug.Log(player.position);
        yield return new WaitForSeconds(0.01f);
        StopCoroutine(UpdatePosition());
    }
}
