using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayerLogic : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent onPlayerCatch;


    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == playerSystem.instance.PlayerVisual)
        {
            onPlayerCatch.Invoke();
        }
    }

}
