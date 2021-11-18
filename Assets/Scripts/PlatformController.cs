/**
 * Filename:            PlatformController.cs
 * Student Name:        Jash Shah
 * Student ID:          101274212
 * Date last modified:  14/11/2021
 * Program Description: Controls the moving platforms
 * Revision History:
 *  - 14/11/2021 - Add initial code for moving platforms
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed;
    public Transform startPos;

    Vector3 nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, pos1.position) < 0.2)
        {
            nextPos = pos2.position;
        }
        else if (Vector3.Distance(transform.position, pos2.position) < 0.2)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
