/*
 * This script despawns the object it is attached to when
   the object's position is below the specified altitude.
   This should be attached to the Spike prefab.
 */

using UnityEngine;

public class Despawner : MonoBehaviour
{
    const float despawnAltitude = -10;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < despawnAltitude)
        {
            FindObjectsOfType<GameManager>()[0].IncrementScore();
            Destroy(gameObject);
        }
    }
}
