using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// 关卡加载
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;    

    private Transform grid; //地图挂载处

    public List<SceneBase> mapList; //场景储存

    private void Awake()
    {
        Instance = this;  
    }
    private void Start()
    {
        grid = GameObject.Find("Grid").transform;
    }
    //初始化关卡
    public SceneBase InitTilemap<T>(string sceneName) where T : SceneBase
    {
        SceneBase scene =FindScene(sceneName);

        if (scene == null)
        {
            GameObject tileMap = Instantiate(Resources.Load("Tilemap/" + sceneName), grid) as GameObject;

            tileMap.name = sceneName;

            scene=tileMap.AddComponent<T>();

            mapList.Add(scene);
        }
        else
        {
            scene.Show();
        }
        return scene;
    }
    //尝试在集合里面找场景
    public SceneBase FindScene(string sceneMap)
    {
        for(int i = 0; i < mapList.Count; ++i)
        {
            if (mapList[i].name==sceneMap)
            {
                return mapList[i];
            }
            
        }return null;
    }
}
