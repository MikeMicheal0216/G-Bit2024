using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class Dash_A : New_A
{
    private void Start()
    {
        currentData = SaveManager.instance.GetData();
        if (currentData.Dash_A)
        {
            gameObject.SetActive(false);
        }
    }
    public override void Save_NewAbility()
    {
        SaveManager.instance.UpdateAbility("Dash_A", true);
    }
}
