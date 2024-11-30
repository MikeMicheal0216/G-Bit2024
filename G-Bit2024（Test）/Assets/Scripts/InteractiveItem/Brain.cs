using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

//这是脑神经的代码
public class Brain : MonoBehaviour
{
    public float disappearDalay = 1f;//消失延迟时间字段
    public float reappearDalay = 2f;//出现延迟时间字段
    //Renderer和Collider的组件的获取
    public SpriteRenderer new_renderer;
    public BoxCollider2D new_collider;

    private void Start()
    {
        new_renderer = GetComponent<SpriteRenderer>();
        new_collider = GetComponent<BoxCollider2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //如果和玩家碰撞
        if (collision.gameObject.tag.Equals("Player"))
        {
            //调用互动逻辑的函数
            StartCoroutine(StartDisappearing());
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        
        StopCoroutine(StartDisappearing());
    }

    //脑神经互动逻辑的函数👇

    IEnumerator StartDisappearing()
    {
        //延迟1s执行后面代码
       yield return new WaitForSeconds(disappearDalay);
        
        //禁用渲染和碰撞，也就是视觉上的消失
        new_renderer.enabled = false;
        new_collider.enabled = false;
        
        //玩家此时掉落，延迟2s
        yield return new WaitForSeconds(reappearDalay);
        
        //启用渲染和碰撞，也就是视觉上的出现
        new_renderer.enabled = true;
        new_collider.enabled = true;
    }

}
