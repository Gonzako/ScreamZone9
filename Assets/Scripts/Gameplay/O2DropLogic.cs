using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class O2DropLogic : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent OnThisDropOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform == playerSystem.instance.PlayerVisual && playerSystem.instance.PickedUpSomething)
        {
            playerSystem.instance.dropEverythingOff(transform);
            OnThisDropOff.Invoke();
        }
    }


}
