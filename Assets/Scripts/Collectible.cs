using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectible : MonoBehaviour
{
    public static event Action OnCollected;
    public static int total;
    public AudioSource collectionSound;

    void Awake() => total++;

    void Update()
    {
        //use below code to rotate coin
        //transform.localRotation = Quaternion.Euler(90f, Time.time * 100f, 0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectionSound.Play();

            OnCollected?.Invoke();
            Destroy(gameObject);

        }
    }
}