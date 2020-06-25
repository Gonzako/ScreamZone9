using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Sounds/SFX Packet")]
public class SFXPacket : ScriptableObject
{

    [SerializeField]
    List<AudioClip> possibleClips = new List<AudioClip>();

    public void playRandomClip(AudioSource sc)
    {
        sc.clip = possibleClips[Random.Range(0, possibleClips.Count)];
        sc.Play();
    }


}
