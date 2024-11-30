using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaming_Win : GamingUnit
{
    public override void Init()
    {
        UIManager.Instance.ShowUI<WinUI>("WinUI");
    }
}
