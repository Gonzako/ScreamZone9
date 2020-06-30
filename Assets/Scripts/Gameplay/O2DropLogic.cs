using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class O2DropLogic : MonoBehaviour
{
    public bool isCancer = false;
    public UnityEngine.Events.UnityEvent OnThisDropOff;
    public UnityEngine.Events.UnityEvent OnEnableEvent;
    private ParticleSystem mainBody;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform == playerSystem.instance.PlayerVisual && playerSystem.instance.PickedUpSomething)
        {
            var result = playerSystem.instance.dropEverythingOff(transform);
            
            foreach(O2PickupLogic n in result)
            {
                n.mainBody.Stop();
            }
            OnThisDropOff.Invoke();
        }
    }

    private void OnEnable()
    {
        GetComponent<BoxCollider2D>().enabled = true;
        OnEnableEvent.Invoke();
    }

    private void OnDisable()
    {
        if(!isCancer)gamePooler.instance.addO2Drop(this);
    }
}
