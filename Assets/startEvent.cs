using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startEvent : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent onStart;
    // Start is called before the first frame update
    void Start()
    {
        onStart.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
