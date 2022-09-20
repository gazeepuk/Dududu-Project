using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraZoom : MonoBehaviour
{
    [SerializeField][Range(0, 10f)] private float defaulutDistance = 6f;
    [SerializeField][Range(0, 10f)] private float minimuDistance = 1f;
    [SerializeField][Range(0, 10f)] private float maximumDistance = 10f;

    [SerializeField][Range(0, 10f)] private float smoothing = 4f;
    [SerializeField][Range(0, 10f)] private float zoomSensitivity = 1f;

    private float currentTargetDistance = 0;


    private CinemachineFramingTransposer framingTransposer;
    private CinemachineInputProvider inputProvider;

    private void Awake()
    {
        framingTransposer = GetComponent<CinemachineVirtualCamera>().GetCinemachineComponent<CinemachineFramingTransposer>();
        inputProvider = GetComponent<CinemachineInputProvider>();
        currentTargetDistance = defaulutDistance;
    }
    private void Update()
    {
        Zoom();
    }

    private void Zoom()
    {
        float zoomValue = inputProvider.GetAxisValue(2) * zoomSensitivity;
        currentTargetDistance = Mathf.Clamp(currentTargetDistance + zoomValue, minimuDistance, maximumDistance);

        float currentDistance = framingTransposer.m_CameraDistance;
        if (currentTargetDistance == currentDistance)
        {
            return;
        }
        float learpedZoomValue = Mathf.Lerp(currentDistance, currentTargetDistance, smoothing * Time.deltaTime);

        framingTransposer.m_CameraDistance = learpedZoomValue;
    }
}
