using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUnitManager : MonoBehaviour
{
    public static GameUnitManager Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void UnitScene<T>(string scenename)where T:SceneBase
    {
        SceneManager.Instance.InitTilemap<T>(scenename);

        SceneManager.Instance.InitTilemap<BackGround>("BackGround"); 
    }
    public void UnitPlayer()
    {
        //临时实例化玩家
        GameObject pla = Instantiate(Resources.Load("Player/Player"), null) as GameObject;

        pla.transform.position = new Vector3(0, 0, 0);

        pla.name = "Player";

        pla.tag = "Player";
    }
    public void UnitScenePoint()
    {
        GameObject point=Instantiate(Resources.Load("Tilemap/ChangeCamera"),null) as GameObject;

        point.name = "ChangeCamera";
    }
}
