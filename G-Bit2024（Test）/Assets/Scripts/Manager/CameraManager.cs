using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 摄像机控制
/// </summary>
public class CameraManager : MonoBehaviour
{
    public Transform player;     // 主角的Transform

    void Start()
    {
        player = GameObject.Find("Player").transform;

        Camera.main.orthographicSize = 10.5f;

        Camera.main.transform.position = new Vector3(-0.5f, 5.5f, -10f);
    }
}
