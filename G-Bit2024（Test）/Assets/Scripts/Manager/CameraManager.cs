using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 摄像机控制
/// </summary>
public class CameraManager : MonoBehaviour
{
    void Start()
    {
        Camera.main.orthographicSize = 10.5f;

        Camera.main.transform.position = SaveManager.instance.GetData().cam_newPoint;
    }
}
