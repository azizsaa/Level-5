using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraAiming : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public float zoomSpeed = 5f;
    public float startFOV;
    public float zoomedOutFOV;

    public float offSetStart;
    public float offSetEnd;

    private float targetFOV;
    private float targetOffset;
    private bool isZoomingOut;
    // Start is called before the first frame update
    void Start()
    {
        targetFOV = startFOV;
        targetOffset = offSetStart;
    }

    // Update is called once per frame
    void Update()
    {
        isZoomingOut = Input.GetKey(KeyCode.W);

        targetFOV = isZoomingOut ? zoomedOutFOV : startFOV;
        targetOffset = isZoomingOut ? offSetEnd : offSetStart;

        float newFOV = Mathf.Lerp(freeLookCamera.m_Orbits[1].m_Radius, targetFOV, Time.deltaTime * zoomSpeed);
        float newOffset = Mathf.Lerp(freeLookCamera.GetRig(1).GetCinemachineComponent<CinemachineComposer>().m_TrackedObjectOffset.x, 
            targetOffset, Time.deltaTime * zoomSpeed);

        CinemachineComposer composer = freeLookCamera.GetRig(1).GetCinemachineComponent<CinemachineComposer>();
        composer.m_TrackedObjectOffset.x = newOffset;
        freeLookCamera.m_Orbits[1].m_Radius = newFOV;
        
    }
}
