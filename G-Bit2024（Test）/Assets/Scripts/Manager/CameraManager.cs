using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��������ƣ���ʱ��
/// </summary>
public class CameraManager : MonoBehaviour
{
    public Transform player;
    //public Vector3 offset;
    //public float smoothSpeed = 0.125f;

    //// ���������������
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
    //        // ��ʼ����ǰ����
    //        currentArea = GetCurrentArea();
    //    }
    //    else
    //    {
    //        // ����Ƿ���Ҫ�л�����
    //        CameraArea newArea = GetCurrentArea();
    //        if (newArea != currentArea)
    //        {
    //            currentArea = newArea;
    //        }
    //    }

    //    // ����Ŀ��λ��
    //    Vector3 desiredPosition = player.position + offset;

    //    // ����Ŀ��λ���ڵ�ǰ����ı߽���
    //    desiredPosition.x = Mathf.Clamp(desiredPosition.x, currentArea.minPosition.x, currentArea.maxPosition.x);
    //    desiredPosition.y = Mathf.Clamp(desiredPosition.y, currentArea.minPosition.y, currentArea.maxPosition.y);
    //    desiredPosition.z = Mathf.Clamp(desiredPosition.z, currentArea.minPosition.z, currentArea.maxPosition.z);

    //    // ƽ���ƶ������
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
