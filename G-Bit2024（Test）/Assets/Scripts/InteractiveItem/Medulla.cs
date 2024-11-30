using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

//这是髓质的代码
public class Medulla : MonoBehaviour
{
    public Save_Data sdata;
    public int num;
    public SpriteRenderer spriteRenderer;
    public Collider2D Collider2D;
    public GameObject Door;
    private void Start()
    {
        sdata = SaveManager.instance.GetData()??null;
        spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D = GetComponent<Collider2D>();
        if (sdata != null)
        {
            if (sdata.Medullacollection.Contains(num))
            {
                spriteRenderer.enabled = false;
                Collider2D.enabled = false;
                if(sdata.Medullacollection.Count == 4)
                {
                    Door.transform.position = Vector2.MoveTowards(Door.transform.position, Door.transform.position - new Vector3(0, 7.5f, 0), 2f);
                    Debug.Log("1");
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            SaveManager.instance.UpdateMedullaList(num);
            gameObject.SetActive(false);
            if (sdata != null && sdata.Medullacollection.Count == 4)
            {
                Door.transform.position = Vector2.MoveTowards(Door.transform.position, Door.transform.position - new Vector3(0, 7.5f, 0), 2f);
            }
        }
    }

}
