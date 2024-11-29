using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

//免疫细胞的代码
public class Cells : MonoBehaviour
{
    //获取动画组件
    public Animation anim;
    //这里假设细胞吞噬玩家的动画是2s，但是实际可能有变化💡💡💡
    public float animTime=2f;
    
    //为了防止重复触发，定义一个布尔值
    private bool isTriggered=false;

    private void Start()
    {
        anim = GetComponent<Animation>();
    }
    private void OnTriggerEnter(Collider other)
    {
        //碰撞检测🔍
        if (other.CompareTag("Player")&&!isTriggered)
        {
            isTriggered = true;
            //碰撞触发之后的函数👇
            HandleCollision();
        }
    }

    private void HandleCollision()
    {
        if (anim != null)
        {
            //如果有这个动画的话，就播放
            anim.Play();
        }

        //游戏结束的逻辑函数👇
        StartCoroutine(GameOverAfterDelay());

    }

    IEnumerator GameOverAfterDelay()
    {
        yield return new WaitForSeconds(animTime); // 等待动画播放时间
        // 切换到游戏结束场景代码放在下面👇
        //现在还没有这个💥💥💥💥💥💥
        
    }
}
