using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SoliloquyUI : UIBase
{
    public List<string> soliloquy_Lists;

    public int list_index=0;

    public TextMeshProUGUI soliloquyUI;

    public Button next_word;

    public Transform player;

    private void Awake()
    {
        next_word = GetComponentInChildren<Button>();

        soliloquyUI = GameObject.Find("BG/soliloquy").GetComponent<TextMeshProUGUI>();
    }
    private void Start()
    {
        Register("NextBt").onclick = OnNextBtClick;

        soliloquyUI.text = soliloquy_Lists[0];

        player= GameObject.Find("Player").transform;

        
    }
    //�����ֲ�
    private void OnNextBtClick(GameObject @object, PointerEventData data)
    {
        ++list_index;

        for(int i = 0; i <= soliloquy_Lists.Count ; ++i)
        {
            if (list_index == soliloquy_Lists.Count)
            {
                player.GetComponent<PlayerMove>().enabled = true;       //������ɼ����ƶ��ű�

                Hide();

                break;
            }
            else if (i==list_index)
            {              
                soliloquyUI.text=soliloquy_Lists[list_index];
            }
        }
    }
    //�ӳ������ö��׼�
    public void GetSoliloquy(List<string> soliloquy)
    {
        soliloquy_Lists = soliloquy;
    }
}
