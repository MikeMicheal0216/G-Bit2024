using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// �󾰿���
/// </summary>
public class BackGround : SceneBase
{
    public SpriteRenderer backSpriteRenderer;

    public Camera currentCamera;

    private void Awake()
    {
        backSpriteRenderer = GetComponent<SpriteRenderer>();

        currentCamera = Camera.main;
    }
    private void Start()
    {
        BackSize(backSpriteRenderer);
        //���������ͬ��һ��
        transform.position = new Vector3(currentCamera.transform.position.x, currentCamera.transform.position.y, transform.position.z);
        //����������ӹ�ϵ�����ⶶ����
        transform.SetParent(currentCamera.transform);
    }
    //�󾰴�С���������
    public void BackSize(SpriteRenderer sprite)
    {
        float cameraHeight = currentCamera.orthographicSize * 2;

        float cameraWidth = cameraHeight * currentCamera.aspect;

        float backSpriteWidth = backSpriteRenderer.bounds.size.x;

        float backSpriteHeight= backSpriteRenderer.bounds.size.y;

        float scaleX = cameraWidth / backSpriteWidth;

        float scaleY = cameraHeight / backSpriteHeight;

        transform.localScale = new Vector3(scaleX,scaleY,1f);
    }
}
