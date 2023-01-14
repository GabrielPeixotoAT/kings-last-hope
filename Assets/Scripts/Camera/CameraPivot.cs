using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    [Header("Camera Zoom")]
    public float MaxZoom;
    public float MinZoom;
    public float ZoomSemsibility;

    public float actualZoom;

    private Transform playerTransform;
    private Camera mainCamera;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        mainCamera = Camera.main;
    }

    void Update()
    {
        transform.position = playerTransform.position;
    }

    void FixedUpdate()
    {
        SetCameraZoom();
    }

    void SetCameraZoom()
    {
        if (Input.mouseScrollDelta == Vector2.up)
        {
            if (MaxZoom >= actualZoom)
            {
                actualZoom += ZoomSemsibility;
                mainCamera.transform.Translate(new Vector3(0, 0, 1));
            }
        }
        if (Input.mouseScrollDelta == Vector2.down)
        {
            if (MinZoom <= actualZoom)
            {
                actualZoom -= ZoomSemsibility;
                mainCamera.transform.Translate(new Vector3(0, 0, -1));
            }
        }
    }
}
