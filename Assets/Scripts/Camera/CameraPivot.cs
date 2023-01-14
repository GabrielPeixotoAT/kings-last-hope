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
    private Camera camera;

    void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
        camera = Camera.main;
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
                camera.transform.Translate(new Vector3(0, 0, 1));
            }
        }
        if (Input.mouseScrollDelta == Vector2.down)
        {
            if (MinZoom <= actualZoom)
            {
                actualZoom -= ZoomSemsibility;
                camera.transform.Translate(new Vector3(0, 0, -1));
            }
        }
    }
}
