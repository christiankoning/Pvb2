using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Despawn : MonoBehaviour {

    public SoundManager SManager;

    void Start()
    {
        SManager = FindObjectOfType<SoundManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject)
        {
            SManager.AudioCollecting.Play();
            Destroy(gameObject);
        }
    }
}
