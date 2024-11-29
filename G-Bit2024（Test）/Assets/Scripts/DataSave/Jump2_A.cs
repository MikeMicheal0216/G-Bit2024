using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class Jump2_A : New_A
{
    private void Start()
    {
        currentData = SaveManager.instance.GetData();
        if (currentData.Jump2_A)
        {
            gameObject.SetActive(false);
        }
    }
    public override void Save_NewAbility()
    {
        SaveManager.instance.UpdateAbility("Jump2_A", true);
    }
}
