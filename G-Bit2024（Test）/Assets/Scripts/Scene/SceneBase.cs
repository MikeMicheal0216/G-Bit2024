using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ³¡¾°»ùÀà
/// </summary>
public class SceneBase : MonoBehaviour
{
    public virtual void Show()
    {
        gameObject.SetActive(true);
    }
    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }
}
