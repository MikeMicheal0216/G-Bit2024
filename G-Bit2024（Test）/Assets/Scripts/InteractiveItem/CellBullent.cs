using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CellBullent : MonoBehaviour
{
    public Vector2 pos;

    public void Start()
    {
        StartCoroutine(ShootTime());
    }
    IEnumerator ShootTime()
    {
        while (true)
        {
            GameObject bullent = Instantiate(Resources.Load("Tilemap/Bullent"), null) as GameObject;
            bullent.transform.position = transform.position;
            bullent.GetComponent<Rigidbody2D>().velocity = pos.normalized * 2f;
            bullent.AddComponent<Bullent>();
            yield return new WaitForSeconds(5f);
        }
    }

}
