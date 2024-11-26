using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ³¡¾°ÇÐ»»
/// </summary>
public class PlayerToCamera : MonoBehaviour
{
    public Vector3 cameraPosition;

    public Vector3 playerPosition;

    private void Start()
    {
        transform.position = playerPosition;

        cameraPosition = Camera.main.transform.position;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
        Vector3 a_point=collision.GetComponent<CamChange>().A_point;

        Vector3 b_point=collision.GetComponent <CamChange>().B_point;

        if (Vector3.Distance(a_point,transform.position) > Vector3.Distance(b_point,transform.position)&& Camera.main.transform.position == a_point)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, b_point, 10f);
        }
        else if(Vector3.Distance(a_point, transform.position) < Vector3.Distance(b_point, transform.position)&& Camera.main.transform.position == b_point)
        {
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, a_point, 10f);
        } 
    }
}
