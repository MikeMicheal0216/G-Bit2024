using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是肉瘤的代码
public class Sarcoma : MonoBehaviour
{
    public float launchForce=10f;
    //这是一个向前弹射的力，但是理想的是向相反方向弹射，我先写完再改
    public Vector2 launchDirection;

    private void OnTriggerEnter(Collider other)
    {
        //条件：触发者是玩家
        if (other.CompareTag("Player"))
        {
            //获取组件
            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();

            launchDirection=rb.velocity.y>.1f?Vector2.down:Vector2.up;

            if (rb != null)
            {
                //清除之前的速度，防止累计力
                rb.velocity=Vector2.zero;
                //施加力，ForceMode.Impulse是瞬时力
                rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
            }
        }
    }
}
