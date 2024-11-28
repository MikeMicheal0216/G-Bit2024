using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是肉瘤的代码
public class Sarcoma : MonoBehaviour
{
    public float launchForce=10f;
    //这是一个向前弹射的力，但是理想的是向相反方向弹射，我先写完再改
    public Vector3 launchDirection=Vector3.up;

    private void OnTriggerEnter(Collider other)
    {
        //条件：触发者是玩家
        if (other.CompareTag("Player"))
        {
            //获取组件
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                //清除之前的速度，防止累计力
                rb.velocity=Vector3.zero;
                //施加力，ForceMode.Impulse是瞬时力
                rb.AddForce(launchDirection * launchForce, ForceMode.Impulse);
            }
        }
    }
}
