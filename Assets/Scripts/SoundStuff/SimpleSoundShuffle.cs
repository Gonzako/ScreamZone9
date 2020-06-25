using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(AudioSource))]
public class SimpleSoundShuffle : MonoBehaviour
{
    private AudioSource source = null;
    [SerializeField]
    SFXPacket data = null;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    public void playSFX()
    {
        data.playRandomClip(source);
    }
}
