using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gradualMoveLeft : MonoBehaviour
{
    public const float speed = 1f;

    public static float screenHalfWidth = 666f;


    private void Start()
    {
        if(screenHalfWidth == 666)
        {
            var cam = Camera.main;
            screenHalfWidth = cam.aspect * cam.orthographicSize;

        }
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if (transform.position.x < -(screenHalfWidth+2))
        {
            Debug.Log(gameObject.name + " has been deactivated and added to the pool");
            gameObject.SetActive(false);
        }
    }


}
