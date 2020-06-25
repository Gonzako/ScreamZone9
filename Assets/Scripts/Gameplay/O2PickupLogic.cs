using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class O2PickupLogic : MonoBehaviour
{

    public UnityEngine.Events.UnityEvent onPlayerPickedUp;
    public UnityEngine.Events.UnityEvent onPlayerDropOff;
    public UnityEngine.Events.UnityEvent onWallOfDeath;

    public float pickupTime = 0.2f;

    [HideInInspector]
    public bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(gameObject.name + " collided with " + other.gameObject.name);

        if (!pickedUp)
        {
            if(other.transform != playerSystem.instance.PlayerVisual)
            {
                Debug.LogWarning(gameObject.name + " hit something other than the player. This is WIP behaviour");
            }
            else
            {
                pickedUp = true;
                playerSystem.instance.addPickup(this);
                getPickedUp(other.transform);
            }
        }
    }

    public void getPickedUp(Transform newParent)
    {
        transform.SetParent(newParent,true);

        transform.DOLocalMove(Vector3.zero, pickupTime).SetEase(Ease.OutQuart);


    }
}
