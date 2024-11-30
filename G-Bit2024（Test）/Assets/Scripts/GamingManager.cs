using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GamingType
{
    None,
    Init,
    Complete,
    Lose
}
public class GamingManager : MonoBehaviour
{
    public static GamingManager Instance;

    public GamingUnit gamingUnit;

    private Transform grid;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (GameObject.Find("Grid/FirstScene").gameObject == null)
        {
            GameObject tileMap = Instantiate(Resources.Load("Tilemap/FirstScene"), grid) as GameObject;
        }
        //初始化场景(放通用实例化不晓得为啥有问题，就单独放这儿了)
        ChangeType(GamingType.Init);
    }
    public void ChangeType(GamingType type)
    {
        switch (type)
        {
            case GamingType.None:
                gamingUnit = null;
                break;
            case GamingType.Init:
                gamingUnit = new Gaming_Unit();
                break;
            case GamingType.Complete:
                gamingUnit = new Gaming_Win();
                break;
            case GamingType.Lose:
                gamingUnit = new Gaming_Lose();
                break;
        }
        gamingUnit?.Init(); // 初始化
    }
    private void Update()
    {
        if (gamingUnit != null)
        {
            gamingUnit.OnUpdate();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            UIManager.Instance.ShowUI<LevelUI>("LevelUI");
        }
    }
}
