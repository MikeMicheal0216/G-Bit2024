using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class CameraControl : MonoBehaviour
{
    public Save_Data _Data;

    public Transform pla;
    private void Start()
    {
        _Data = SaveManager.instance.GetData() ?? null;
        pla = GameObject.Find("Player").transform??null;
        if (_Data != null)
        {
            transform.position = _Data.savePoint;
        }
        else
        {
            transform.position=new Vector3(0,0,0);
        }
    }
    private void Update()
    {
        if(pla==null)pla = GameObject.Find("Player").transform ;
        
        transform.position = Vector3.Lerp(transform.position,new Vector3(pla.position.x,pla.position.y,-10f),2f);
    }
}
