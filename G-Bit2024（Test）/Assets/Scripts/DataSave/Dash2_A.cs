using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class Dash2_A : New_A
{
    private void Start()
    {
        currentData = SaveManager.instance.GetData();
        if (currentData.Dash2_A)
        {
            gameObject.SetActive(false);
        }
    }
    public override void Save_NewAbility()
    {
        SaveManager.instance.UpdateAbility("Dash2_A", true);
    }
}
