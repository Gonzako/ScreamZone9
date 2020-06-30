using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class disableResposition : MonoBehaviour
{
    SpriteRenderer spr;


    public static bool reactivate = true;

    public bool thisReactivate = true;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }


    public void RepositionToStart()
    {
        var pos = transform.position;

        pos.x = gradualMoveLeft.screenHalfWidth + spr.bounds.extents.x;

        transform.position = pos;

        if (!(reactivate && thisReactivate))
            gameObject.SetActive(false);
            
    }

}
