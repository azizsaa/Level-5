using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public Animator anim;
    public float Speed;


    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        float horizontalmovement = Input.GetAxis("Horizontal");
        float verticalWalking = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), -0.5f, Input.GetAxis("Vertical"));
        Rigidbody.velocity = movement * 5;
        Vector3 direction = new Vector3(Rigidbody.velocity.x, 5, Rigidbody.velocity.z);
        Rigidbody.MoveRotation(Quaternion.LookRotation(direction));
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(0, 100, 0, ForceMode.Impulse);
        }

        anim.SetFloat("horizontalWalking", horizontalmovement);
        anim.SetFloat("verticalWalking", verticalWalking);

        Speed = 50f;

    }

}