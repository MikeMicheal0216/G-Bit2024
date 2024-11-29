using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveManager;

public class New_A : MonoBehaviour
{
    public bool can_T=true;

    protected Save_Data currentData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            Save_NewAbility();

            gameObject.SetActive(false);
        }
    }

    public virtual void Save_NewAbility() { }
    
}
