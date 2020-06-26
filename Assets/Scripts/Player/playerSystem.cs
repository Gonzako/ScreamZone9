using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerSystem : MonoBehaviour
{

    public static playerSystem instance;
    
    


    [SerializeField]
    private Transform playerVisual;
    [SerializeField]
    private Transform playerLogic;


    public Transform PlayerVisual { get { return playerVisual; } private set { playerVisual = value; } }
    public Transform PlayerLogic { get { return playerLogic; } private set { playerLogic = value; } }

    public bool PickedUpSomething { get { return pickedUpSomething; } }

    private bool pickedUpSomething = false;
    private List<O2PickupLogic> o2Pickups = new List<O2PickupLogic>();

    public void addPickup(O2PickupLogic t)
    {
        pickedUpSomething = true;
        o2Pickups.Add(t);
    }

    public void dropEverythingOff(Transform t)
    {
        if (!pickedUpSomething)
        {
            return;
        }
        pickedUpSomething = false;
        for (int i = 0; i < o2Pickups.Count; i++)
        {

            var current = o2Pickups[i];
            current.getPickedUp(t);
            current.pickedUp = false;
            current.onPlayerDropOff.Invoke();
        }

    }

    private void Awake()
    {
        if(instance == null)
            instance = this;
        else
        {
            Destroy(this);
        }

    }
}
