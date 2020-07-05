using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cancerMovementLogic : MonoBehaviour
{

    public float velocity = 3f;
    public float pauseTime = 2f;
    float oldVel;

    Coroutine cor;

    public void pauseCancer()
    {
        if (!gameObject.activeInHierarchy)
            return;


        if (cor != null)
            StopCoroutine(cor);

        cor = StartCoroutine(lateVelocitySet());
    }

    private IEnumerator lateVelocitySet()
    {
        oldVel = velocity;
        velocity = 0;

        yield return new WaitForSeconds(pauseTime);

        velocity = oldVel;
    }

    private void Update()
    {
        transform.position += Vector3.right * velocity * Time.deltaTime;
    }
}
