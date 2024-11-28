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
    
    //一直在运行
    private bool isRunning=true;

    void Start()
    {
        //从开始就一直不停循环出现和消失
        RunFlicker();
    }

    private async void RunFlicker()
    {
        while (isRunning)
        {
            //出现的逻辑👇
            gameObject.SetActive(true);
            await Task.Delay((int)appearDuration*1000);
            
            //消失的逻辑👇
            gameObject.SetActive(false);
            await Task.Delay((int)appearDuration*1000);
            
        }
    }

}
