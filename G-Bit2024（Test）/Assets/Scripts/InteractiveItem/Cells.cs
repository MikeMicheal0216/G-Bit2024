using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using static SaveManager;

//免疫细胞的代码
public class Cells : MonoBehaviour
{
    public Transform pla;
    public bool isDie;
    public Save_Data sdata;
    private void Start()
    {
        isDie = false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            pla = collision.transform;
            //碰撞触发之后的函数👇
            StartCoroutine(GameOverAfterDelay());
        }
    }
    IEnumerator GameOverAfterDelay()
    {
        pla.GetComponent<Animator>().Play("Player_Die");
        yield return new WaitForSeconds(1f); // 等待动画播放时间
        Time.timeScale = 0f;
        if (pla != null)
        {
            Destroy(pla.gameObject);
        }
        //复活
        sdata = SaveManager.instance.GetData();
        GameObject player = Instantiate(Resources.Load("Player/Player"), null) as GameObject;

        Vector3 spawnPosition = sdata.savePoint;

        player.transform.position = spawnPosition;

        player.name = "Player";

        player.tag = "Player";
        Time.timeScale = 1f;
        yield return null;
        StopCoroutine(GameOverAfterDelay());
    }
}
