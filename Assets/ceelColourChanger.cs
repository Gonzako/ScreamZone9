using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ceelColourChanger : MonoBehaviour
{

    SpriteRenderer spr;

    [SerializeField]
    private Color colorAsDark, colorAsBright;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
    }

    public void Darken()
    {
        spr.DOColor(colorAsDark, 2f);
    }

    public void Brighten()
    {
        spr.DOColor(colorAsBright, 1.5f);
    }
}
