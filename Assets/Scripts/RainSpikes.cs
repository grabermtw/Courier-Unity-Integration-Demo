/*
 * This script handles the raining of the dangerous spikes that the player should avoid
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpikes : MonoBehaviour
{
    public GameObject spikePrefab;
    public float rainInterval = 0.75f;

    const float SPIKE_ALTITUDE = 6;
    const float SPIKE_BOUNDS = 9.5f;

    private bool raining;

    // Start is called before the first frame update
    void Start()
    {
        StartRain();
    }

    public void StartRain()
    {
        StartCoroutine(Rain());
    }

    public void StopRain()
    {
        raining = false;
    }

    private IEnumerator Rain()
    {
        // Prevent this coroutine from being started if it's already running
        if (raining)
            yield break;

        raining = true;

        while (raining)
        {
            // Spawn new falling spikes with random x-positions at the specified rainInterval
            Instantiate(spikePrefab, new Vector3(Random.Range(-SPIKE_BOUNDS, SPIKE_BOUNDS), SPIKE_ALTITUDE, 0), Quaternion.Euler(0, 0, 90), transform);
            yield return new WaitForSeconds(rainInterval);
        }
    }
}
