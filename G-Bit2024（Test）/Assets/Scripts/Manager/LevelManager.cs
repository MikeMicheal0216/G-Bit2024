using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
/// <summary>
/// �ؿ�����
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;    

    private Transform grid; //��ͼ���ش�

    public List<SceneBase> mapList; //��������

    private void Awake()
    {
        Instance = this;  
    }
    private void Start()
    {
        grid = GameObject.Find("Grid").transform;
    }
    //��ʼ���ؿ�
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
    //�����ڼ��������ҳ���
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
