using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayerLogic : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent onPlayerCatch;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform == playerSystem.instance.PlayerVisual)
        {
            onPlayerCatch.Invoke();
        }
    }

}
