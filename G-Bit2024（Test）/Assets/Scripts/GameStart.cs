using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ��Ϸ���
/// </summary>
public class GameStart : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }
}
