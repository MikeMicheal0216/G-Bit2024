using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这是肉瘤的代码
public class Sarcoma : MonoBehaviour
{
    public float launchForce=10f;
    //这是一个向前弹射的力，但是理想的是向相反方向弹射，我先写完再改
    public Vector2 launchDirection;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public PlayerControl pla;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //获取组件
            rb = collision.gameObject.GetComponent<Rigidbody2D>();

            launchDirection = rb.velocity.y > .1f ? Vector2.down : Vector2.up;

            sr=collision.gameObject.GetComponent<SpriteRenderer>();

            sr.enabled = false;

            pla= collision.gameObject.GetComponent<PlayerControl>();

            pla.enabled = false;

            StartCoroutine(PlayerLaunching());
            Debug.Log(launchDirection);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        sr.enabled = true;
        pla.enabled = true;
    }
    IEnumerator PlayerLaunching()
    {
        if (rb != null)
        {
            //清除之前的速度，防止累计力
            yield return new WaitForSeconds(1.0f);
        }
        rb.velocity = Vector2.zero;
        
        if (rb != null)
        {
            //施加力，ForceMode.Impulse是瞬时力
            rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }
        StopCoroutine(PlayerLaunching());
    }
}
