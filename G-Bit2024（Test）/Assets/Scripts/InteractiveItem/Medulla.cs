using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是髓质的代码
public class Medulla : MonoBehaviour
{
    //事件通知管理器👇
    public static event Action<Medulla> OnMedulla;
    //初始值是❌
    private bool isActive=false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&!isActive)
        {
            isActive = true;
            //通知当前关卡管理器MedullaMananger
            OnMedulla?.Invoke(this);
        }
    }
    
}
