using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamePooler : MonoBehaviour
{
    private Queue<O2DropLogic> o2DropPoints = new Queue<O2DropLogic>();
    private Queue<O2PickupLogic> o2Pickups = new Queue<O2PickupLogic>();

    public static gamePooler instance;

    public O2DropLogic dropPrefab;
    public O2PickupLogic pickupPrefab;

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }


    public O2DropLogic GetO2Drop()
    {
        O2DropLogic result;
        if (o2DropPoints.Count > 0)
           result = o2DropPoints.Dequeue();
        else
           result = GameObject.Instantiate(dropPrefab);
        result.transform.parent = null;
        return result;
    }

    public void addO2Drop(O2DropLogic target)
    {
        o2DropPoints.Enqueue(target);
    }

    public O2PickupLogic GetO2Pickup()
    {
        O2PickupLogic result;
        if (o2Pickups.Count > 0)
            result = o2Pickups.Dequeue();
        else
            result = Instantiate(pickupPrefab);
        result.transform.parent = null;
        return result;
    }

    public void addO2Pickup(O2PickupLogic target)
    {
        o2Pickups.Enqueue(target);
    }
}
