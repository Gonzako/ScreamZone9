using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(gradualMoveLeft))]
public class tweenGradualMove : MonoBehaviour
{


    gradualMoveLeft tweenNable;
    float normalVel;

    Tween currentTween;

    // Start is called before the first frame update
    void Awake()
    {
        tweenNable = GetComponent<gradualMoveLeft>();
        normalVel = tweenNable.speed;
    }

    public void tweenToStop()
    {
        if(currentTween != null)
        {
            currentTween.Kill();
        }
        currentTween = DOTween.To(() => tweenNable.speed, x => tweenNable.speed = x, normalVel*0.1f, 0.2f);
    }

    public void tweenToNormal()
    {

        if (currentTween != null)
        {
            currentTween.Kill();
        }
        currentTween = DOTween.To(() => tweenNable.speed, x => tweenNable.speed = x, normalVel, 0.2f);
    }

}
