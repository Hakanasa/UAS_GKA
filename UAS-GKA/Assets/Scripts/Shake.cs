using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    private AudioSource source { get { return GetComponent<AudioSource>(); } }
    public AudioClip Ring;
    void Start()
    {
        source.clip = Ring;
        source.playOnAwake = false;
        source.volume = .2f;

        source.PlayOneShot(Ring);
        iTween.ShakeRotation(this.gameObject, new Vector3(0, 0, 10), 1.9f);
    }
}
