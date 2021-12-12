/**
 * Filename:            BulletController.cs
 * Student Name:        Jash Shah
 * Student ID:          101274212
 * Date last modified:  12/12/2021
 * Program Description: Controls the player fired bullets
 * Revision History:
 *  - 12/12/2021 - Add Initial bullet behaviour functionality
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 10;
    public float maxDuration = 1;
    public float direction = 1f;

    private float duration = 0;
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((direction * transform.right * speed * Time.deltaTime));

        duration += Time.deltaTime;
        if (duration > maxDuration)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !hit)
        {
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);

            gameObject.SetActive(false);
            Destroy(gameObject);

            GameObject.Find("Player").GetComponent<PlayerBehaviour>().score += 20;
            hit = true;
        }
    }
}
     