using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class Bullent : MonoBehaviour
{
    public Transform pla;

    public Save_Data sdata;

    private Coroutine gameOverCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player") && gameOverCoroutine == null)
        {
            pla = collision.transform;
            pla.gameObject.GetComponent<Collider2D>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            StartCoroutine(GameOverAfterDelay());
            if (pla != null)
            {
                Destroy(pla.gameObject);
            }
            return;
        }
        if (collision.gameObject.tag.Equals("Ground"))
        {
            Hide();
            return;
        }
    }
    public void Hide()
    {
        Destroy(gameObject);
    }
    IEnumerator GameOverAfterDelay()
    {
        pla.GetComponent<Animator>().Play("Player_Die");
        yield return new WaitForSeconds(1f); // 等待动画播放时间
        
        //复活
        sdata = SaveManager.instance.GetData();
        GameObject player = Instantiate(Resources.Load("Player/Player"), null) as GameObject;
        Debug.Log("1");
        Vector3 spawnPosition = sdata.savePoint;

        player.transform.position = spawnPosition;

        player.name = "Player";

        player.tag = "Player";
        
        StopCoroutine(GameOverAfterDelay());
        gameOverCoroutine = null;
        yield break;
    }
}
