using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 后景控制
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
        //将后景与相机同步一次
        transform.position = new Vector3(currentCamera.transform.position.x, currentCamera.transform.position.y, transform.position.z);
        //后景与相机父子关系（避免抖动）
        transform.SetParent(currentCamera.transform);
    }
    //后景大小与相机对齐
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
