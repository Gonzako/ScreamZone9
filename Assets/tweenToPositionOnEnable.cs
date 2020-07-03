using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class tweenToPositionOnEnable : MonoBehaviour
{

    public Vector3 positionToTweenTowards;
    public float timeToGetThere = 5f;


    private void OnEnable()
    {
        transform.DOMove(positionToTweenTowards, timeToGetThere).SetEase(Ease.InOutQuad);
    }


}
