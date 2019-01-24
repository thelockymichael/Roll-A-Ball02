using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 0.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;

    private Camera cam;

    private float distance = 10.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    //public PauseMenu pm;

    private void Start()
    {
        currentY = 20f;
        camTransform = transform;
        cam = Camera.main;
    }

    private void Update()
    {
        // (!pm.GameIsPaused)
    //    {
            var InputDevice = InputManager.ActiveDevice;

            // transform.Rotate(Vector3.down, 500.0f * Time.deltaTime * InputDevice.RightStickX, Space.World);
            // transform.Rotate(Vector3.right, 500.0f * Time.deltaTime * InputDevice.RightStickY, Space.World);

            currentX += InputDevice.RightStickX * sensitivityX;
            currentY += InputDevice.RightStickY * sensitivityY;

            currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    

    private void LateUpdate()
    {
        //if (!pm.GameIsPaused)
        //{
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            camTransform.position = lookAt.position + rotation * dir;
            camTransform.LookAt(lookAt.position);
        }
    }


