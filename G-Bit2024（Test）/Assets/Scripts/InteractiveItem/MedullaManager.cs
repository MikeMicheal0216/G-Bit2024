using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MedullaManager : MonoBehaviour
{
    //关卡中的“髓质”这个物品的列表（一关中有若干个髓质，这里面记录该关卡所有髓质）
    public List<Medulla> medullas;

    //用来记录已经激活的髓质个数👇
    private int activeMedulla = 0;

    private void OnEnable()
    {
        throw new NotImplementedException();
        //从Medulla里的参数
        Medulla.OnMedulla += OnMedulla;
    }

    private void OnDisable()
    {
        Medulla.OnMedulla -= OnMedulla;
    }

    private void Start()
    {
        //如果没有髓质，就直接获得通过条件，也就是不会被限制活动
        if(medullas == null||medullas.Count==0)
        {
            Debug.Log("这是一个没有髓质的关卡");
            //这是一个处理髓质全部被点亮的后逻辑的函数👇，在末尾可以看到代码内容物
            ProceedToNextScene();
        }
    }

    private void OnMedulla(Medulla medulla)
    {
        if (medullas.Contains(medulla))
        {
            //激活髓质个数加一
            activeMedulla++;
            Debug.Log($"髓质被点亮! {activeMedulla}/{medullas.Count}");
            //当全部激活的时候
            if (activeMedulla == medullas.Count)
            {
                Debug.Log("所有的髓质都被点亮了");
                //那就没有限制了，可以去往对应的关卡
                ProceedToNextScene();
            }
        }
        
    }

    private void ProceedToNextScene()
    {
        //这里是切换到下一个场景的逻辑👇
        UnityEngine.SceneManagement.SceneManager.LoadScene("未知场景名");
        //不过这么写的话就只能切换到特定的场景了，感觉这个需要修改修改💡💡💡
    }

}
