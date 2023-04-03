using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnAudioEnd : MonoBehaviour
{
    void Update()
    {
        if(!GetComponentInChildren<AudioSource>().isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
