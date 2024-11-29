using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class LightSave : MonoBehaviour
{
    public Save_Data sdata;
    private void Start()
    {
        sdata = SaveManager.instance.GetData()??null;

        if (sdata!=null)
        {
            return;
        }
        else if (sdata.collectedLightPoints.Contains(int.Parse(gameObject.name)))
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            SaveManager.instance.UpdateLightList(int.Parse(gameObject.name));
            gameObject.SetActive(false);
        }
    }
}
