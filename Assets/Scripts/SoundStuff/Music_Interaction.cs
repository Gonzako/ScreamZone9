using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Music_Interaction : MonoBehaviour
{
    public MusicManager music_manager;
    public Button start, tense, ease, stop;
    // Start is called before the first frame update
    void Start()
    {
        stop.interactable = false;
        ease.gameObject.SetActive(false);
        tense.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(music_manager.part1_audio.isPlaying && music_manager.part1_audio.time >= music_manager.part1_audio.clip.length - 0.1f)
        {
            tense.gameObject.SetActive(true);
        }
    }

    public void OnHitStart()
    {
        music_manager.startMusic();
        start.interactable = false;
        stop.interactable = true;
    }
    public void OnHitTense()
    {
        music_manager.moveToTense(true);
        tense.gameObject.SetActive(false);
        ease.gameObject.SetActive(true);
    }
    public void OnHitEase()
    {
        music_manager.moveToTense(false);
        tense.gameObject.SetActive(true);
        ease.gameObject.SetActive(false);
    }
    public void OnHitStop()
    {
        music_manager.StopAll();
        stop.interactable = false;
        start.interactable = true;
    }
}
