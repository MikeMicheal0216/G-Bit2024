using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class Point_Save : MonoBehaviour
{
    public Vector3 currrent_Point;

    public Save_Data s_data;


    private void Start()
    {
        s_data = SaveManager.instance.GetData();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            currrent_Point= collision.transform.position;

            SaveManager.instance.UpdateSavePoint(currrent_Point);

            SaveManager.instance.UpdateCamNewPoint(Camera.main.transform.position);
        }
    }
}
