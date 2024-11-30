using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FirstScene : SceneBase
{
    public List<string> soliloquy;

    public Transform player;

    public SoliloquyUI soliloquyUI;
    private void Start()
    {
        UIManager.Instance.ShowUI<SoliloquyUI>("SoliloquyUI");

        player = GameObject.Find("Player").transform??null;

        player.GetComponent<PlayerControl>().enabled = false;  //����ʱ�ر��ƶ��ű�

        player.GetComponent<Rigidbody2D>().velocity = Vector3.zero;     //�ٶ�Ϊ��

        soliloquyUI=GameObject.Find("SoliloquyUI").GetComponent<SoliloquyUI>();

        soliloquy =new List<string>{"1","2","3","4" };

        soliloquyUI.GetSoliloquy(soliloquy);
    }
}
