/*
 *  This script is used to control the player's movement
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float movementSpeed = 5;
    const float PLAYER_BOUNDS = 9.25f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x > -PLAYER_BOUNDS)
        {
            transform.position += new Vector3(-movementSpeed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && transform.position.x < PLAYER_BOUNDS)
        {
            transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        FindObjectsOfType<GameManager>()[0].GameOver();
    }
}
