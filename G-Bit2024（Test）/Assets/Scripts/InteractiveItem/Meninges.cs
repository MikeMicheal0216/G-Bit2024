using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

//这是脑膜的代码
public class Meninges : MonoBehaviour
{
    //出现时间👇
    public float appearDuration=2f;
    //消失时间👇
    public float disappearDuration=2f;

    public bool isRun=true;

    public SpriteRenderer new_renderer;
    public BoxCollider2D new_collider;
    void Start()
    {
        new_renderer = GetComponent<SpriteRenderer>();
        new_collider = GetComponent<BoxCollider2D>();
        //从开始就一直不停循环出现和消失
        StartCoroutine(RunFlicker());
    }

    IEnumerator RunFlicker()
    {
       while (isRun)
        {
            //出现的逻辑👇
            new_renderer.enabled = true;
            new_collider.enabled = true;
            yield return new WaitForSeconds(appearDuration);

            //消失的逻辑👇
            new_renderer.enabled = false;
            new_collider.enabled = false;
            yield return new WaitForSeconds(disappearDuration);
        } 
    }

}
