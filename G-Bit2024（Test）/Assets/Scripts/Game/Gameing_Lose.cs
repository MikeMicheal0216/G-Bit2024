using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gaming_Lose : GamingUnit
{
     
    public override void Init()
    {
        _Data = SaveManager.instance.GetData();
        GameUnitManager.Instance.UnitPlayer();  
    }
}
