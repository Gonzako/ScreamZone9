using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class spriteRenderColorTween : MonoBehaviour
{
    public float timeToTween = 2f;

    private Color startCol = Color.white;
    private SpriteRenderer spr;

    [SerializeField]
    private List<Color> colors = new List<Color>();

    public UnityEngine.Events.UnityEvent onAnyColorChangeFinished;

    public void tweenToColor(int i)
    {
        if(i < colors.Count)
        {
            spr.DOColor(colors[i], timeToTween).onComplete += onAnyColorChangeFinished.Invoke;
        }
    }

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        startCol = spr.color;
    }
}
