using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 摄像机控制（临时）
/// </summary>
public class CameraManager : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;
    //public float smoothSpeed = 0.125f;

    //// 定义多个摄像机区域
    //public CameraArea[] cameraAreas;

    //private CameraArea currentArea;

    private void Start()
    {
        player = GameObject.Find("Player").transform;
        Camera.main.orthographicSize = 10.5f;
    }
    private void Update()
    {

        //if (player == null)
        //{
        //     player = GameObject.Find("Player").transform;
        //}

        transform.position = new Vector3(player.position.x,player.position.y,transform.position.z);
    }
    //void LateUpdate()
    //{
    //    if (currentArea == null)
    //    {
    //        // 初始化当前区域
    //        currentArea = GetCurrentArea();
    //    }
    //    else
    //    {
    //        // 检查是否需要切换区域
    //        CameraArea newArea = GetCurrentArea();
    //        if (newArea != currentArea)
    //        {
    //            currentArea = newArea;
    //        }
    //    }

    //    // 计算目标位置
    //    Vector3 desiredPosition = player.position + offset;

    //    // 限制目标位置在当前区域的边界内
    //    desiredPosition.x = Mathf.Clamp(desiredPosition.x, currentArea.minPosition.x, currentArea.maxPosition.x);
    //    desiredPosition.y = Mathf.Clamp(desiredPosition.y, currentArea.minPosition.y, currentArea.maxPosition.y);
    //    desiredPosition.z = Mathf.Clamp(desiredPosition.z, currentArea.minPosition.z, currentArea.maxPosition.z);

    //    // 平滑移动摄像机
    //    Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
    //    transform.position = smoothedPosition;
    //}

    //public CameraArea GetCurrentArea()
    //{
    //    foreach (CameraArea area in cameraAreas)
    //    {
    //        if (player.position.x >= area.minPosition.x && player.position.x <= area.maxPosition.x &&
    //            player.position.y >= area.minPosition.y && player.position.y <= area.maxPosition.y)
    //        {
    //            return area;
    //        }
    //    }
    //    return null;
    //}
}

//[System.Serializable]
//public class CameraArea
//{
//    public Vector3 minPosition;
//    public Vector3 maxPosition;
//}
