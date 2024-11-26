using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ÓÎÏ·Æðµã
/// </summary>
public class GameStart : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.ShowUI<LoginUI>("LoginUI");
    }
}
