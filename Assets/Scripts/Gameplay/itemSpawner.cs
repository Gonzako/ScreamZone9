using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Places o2 and drop points randomly on intervals
/// </summary>
public class itemSpawner : MonoBehaviour
{
    public static bool keepSpawning = true;

    public float o2DropPointTime = 2, o2PickTime = 1.5f;

    private Camera cam;
    private float yHalfSize;


    private void Start()
    {
        cam = Camera.main;
        yHalfSize = cam.orthographicSize;

        StartCoroutine(pickupSpawnRoutine());
        StartCoroutine(dropSpawnRoutine());
    }

    IEnumerator pickupSpawnRoutine()
    {
        while (keepSpawning)
        {
            yield return new WaitForSeconds(o2PickTime+Random.Range(-0.5f, 0.25f));
            var o2Pickup = gamePooler.instance.GetO2Pickup();
            o2Pickup.transform.position = getPositionOutsideOfFustrum();
            o2Pickup.gameObject.SetActive(true);
        }
    }

    IEnumerator dropSpawnRoutine()
    {
        while (keepSpawning)
        {
            yield return new WaitForSeconds(o2DropPointTime+ Random.Range(-0.25f, 0.5f));
            var dropPoint = gamePooler.instance.GetO2Drop();
            dropPoint.transform.position = getPositionOutsideOfFustrum(dropPoint.GetComponent<SpriteRenderer>());
            dropPoint.gameObject.SetActive(true);
        }
    }

    private Vector2 getPositionOutsideOfFustrum(SpriteRenderer bounds = null)
    {
        float extraX = 2f;
        if(bounds != null)
        {
            extraX = bounds.bounds.extents.x;
        }
        Vector2 result = new Vector2(extraX, 0);

        result.x += cam.aspect * yHalfSize;
        result.y = Random.Range(-yHalfSize, yHalfSize);

        return result;

    }
}
