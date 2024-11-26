using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// πÿø®º”‘ÿ
/// </summary>
public class SceneManager : MonoBehaviour
{
    public static SceneManager Instance;

    private Transform grid;

    public List<SceneBase> mapList;

    private void Awake()
    {
        Instance = this;

        grid = GameObject.Find("Grid").transform;
    }

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
