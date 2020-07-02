using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gradualMoveLeft : MonoBehaviour
{
    public float speed = 1f;
    public bool getUnityEventInstead = false;

    public UnityEngine.Events.UnityEvent onLeaveFustrum = null;


    public static float screenHalfWidth = 666f;

    private SpriteRenderer rend;

    public float Speed { set { speed = value; } }

    private void Start()
    {
        if(screenHalfWidth == 666)
        {
            var cam = Camera.main;
            screenHalfWidth = cam.aspect * cam.orthographicSize;

        }
        rend = GetComponent<SpriteRenderer>();
    }



    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        float extents = 2;
        if (rend != null)
            extents = rend.bounds.extents.x;
        if (transform.position.x < -(screenHalfWidth+extents+2f))
        {
            if(!getUnityEventInstead)
                gameObject.SetActive(false);
            else
            {
                onLeaveFustrum.Invoke();
            }
        }
    }


}
