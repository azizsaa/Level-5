using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    public float moveSpeed;
    public float maxFloatHeight = 10;
    public float minFloatHeight;

    public Camera freeLookCamrea;
    private float currentHeight;
    private Animator anim;
    private float xRotation;
    // Start is called before the first frame update
    void Start()
    {
        currentHeight = transform.position.y;
        anim = GetComponent<Animator>();
        
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        xRotation = freeLookCamrea.transform.rotation.eulerAngles.x;

        if(Input.GetKey(KeyCode.W))
        {
            MoveCharacter();
        }
        else
        {
            DisableMovement();
        }
        currentHeight = Mathf.Clamp(transform.position.y, currentHeight, maxFloatHeight);
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);

    }
    private void MoveCharacter()
    {
        Vector3 cameraForward = new Vector3(freeLookCamrea.transform.forward.x, 0, freeLookCamrea.transform.forward.z);
        transform.rotation = Quaternion.LookRotation(cameraForward);
        transform.Rotate(new Vector3(xRotation, 0 ,0), Space.Self);

        anim.SetBool("isfly", true);

        Vector3 forward = freeLookCamrea.transform.forward;
        Vector3 flyDirecation = forward.normalized;

        currentHeight += flyDirecation.y * moveSpeed * Time.deltaTime;
        currentHeight = Mathf.Clamp(currentHeight, minFloatHeight, maxFloatHeight);

        transform.position += flyDirecation * moveSpeed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x, currentHeight, transform.position.z);
    }

    private void DisableMovement()
    {
        anim.SetBool("isfly", false);
        transform.rotation= Quaternion.Euler(0,transform.rotation.eulerAngles.y,0);
    }

}
