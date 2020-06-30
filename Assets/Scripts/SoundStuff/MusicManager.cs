using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

/// <summary>
/// Music manager by Bharat. Gonz: Overhauled all the updatechecks to a more function oriented approach
/// 
/// Interact with the music manager via the booleans: 'begin', 'stop', and 'part2_tense_play'
/// 
/// Start the music by setting 'begin' to true (treat it like a button). Then Part 1 of the track will start playing.
/// During part 2, when the virus comes close, set 'part2_tense_play' to true. This will have the music smoothly transition to the tense track
/// Set 'part2_tense_play' to false once the player is away from the virus
/// If you want to stop the music, simply set 'stop' to true (Like 'begin', treat it like a button)
/// </summary>
public class MusicManager : MonoBehaviour
{


    public AudioSource part1_audio, part2_audio, part2_tense_audio;



    public bool begin, part2_tense_play, stop;

    public static MusicManager instance;

    [SerializeField]
    private float transitionTime = 1 / 6f;

    private bool part1_playing, part2_playing; //music state bools Gonz: These you have lost their usefulness
    private bool keepLooping = true;
    // Update is called once per frame

    public void changeLooping(bool value)
    {
        keepLooping = value;
    } 


    public void StopAll()
    {
        part1_audio.Stop();
        part2_audio.Stop();
        part2_tense_audio.Stop();

        part2_tense_play = false;
        part1_playing = false;
        part2_playing = false;

    }


    public void startMusic()
    {
        part1_audio.Play();
        StartCoroutine(startPart2Delayed());
    }

    public void moveToTense(bool toTense)
    {
        if (toTense)
        {
            volumeTransition(part2_audio, part2_tense_audio, transitionTime);

        }
        else
        {

            volumeTransition(part2_tense_audio, part2_audio, transitionTime);

        }
    }


    private void Start()
    {
        if(instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }
    }

    void Update()
    {
        //All the bool checking has been changed to functions
        //if (stop)
        //{
        //    stop = false;
        //    StopAll();
        //}
        //if (begin)//starting the music. If begin is hit
        //{
        //    begin = false;
        //    StopAll();
        //    part1_audio.Play();
        //    part1_playing = true;
        //}
        //
        //if(part1_playing && part1_audio.time >= part1_audio.clip.length - 0.1f) //Once part one finishes, switch to part 2
        //{
        //    part2_audio.Play();
        //    part2_tense_audio.Play();
        //    part2_tense_audio.volume = 0.0f;
        //    part1_playing = false;
        //    part2_playing = true;
        //
        //}
        //if (part2_playing)//Part 2 section
        //{
        //    ////Below if statements are for smooth loops. Have the track repeat right before cutoff to remain seamless
        //    //if(part2_audio.isPlaying && part2_audio.time >= part2_audio.clip.length - 0.1f)
        //    //{
        //    //    part2_audio.Stop();
        //    //    part2_audio.Play();
        //    //}
        //    //if (part2_tense_audio.isPlaying && part2_tense_audio.time >= part2_tense_audio.clip.length - 0.1f)
        //    //{
        //    //    part2_tense_audio.Stop();
        //    //    part2_tense_audio.Play();
        //    //}
        //
        //    ////below if statements are for smoothly changing from/to tense mode
        //    //if(part2_tense_play && part2_audio.volume > 0)
        //    //{
        //    //    part2_audio.volume -= 0.1f;
        //    //    part2_tense_audio.volume += 0.1f;
        //    //}
        //    //else if(!part2_tense_play && part2_tense_audio.volume > 0)
        //    //{
        //    //    part2_tense_audio.volume -= 0.1f;
        //    //    part2_audio.volume += 0.1f;
        //    //}
        //}
        
    }
    private IEnumerator startPart2Delayed()
    {
        yield return new WaitForSeconds(part1_audio.clip.length - 0.1f);
        volumeTransition(part1_audio, part2_audio, 0.1f);
        part2_audio.Play();
        part2_tense_audio.Play();
        part2_tense_audio.volume = 0;

        StartCoroutine(customCuttoff(part2_audio, 0.1f));
        StartCoroutine(customCuttoff(part2_tense_audio, 0.1f));
    }

    private IEnumerator customCuttoff(AudioSource target, float time)
    {
        while (keepLooping)
        {
            var timeToWait = target.clip.length - target.time - time;
            yield return new WaitForSeconds(timeToWait);
            target.Stop();
            target.Play();
        }
    }

    private void volumeTransition(AudioSource toZeroVolume, AudioSource toMaxVolume, float time)
    {
        DOTween.To(() => toMaxVolume.volume, x => toMaxVolume.volume = x, 1, time);
        DOTween.To(() => toZeroVolume.volume, x => toZeroVolume.volume = x, 0, time);
    }

}
