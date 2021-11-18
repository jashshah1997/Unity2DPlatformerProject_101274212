/**
 * Filename:            DisappearingPlatformController.cs
 * Student Name:        Jash Shah
 * Student ID:          101274212
 * Date last modified:  18/11/2021
 * Program Description: Controls the moving platforms
 * Revision History:
 *  - 18/11/2021 - Add initial code for disappearing platforms
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatformController : MonoBehaviour
{
    public float TimeToToggle = 2f;
    public bool isEnabled = true;
    float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        isEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > TimeToToggle)
        {
            currentTime = 0;
            TogglePlatform();
        }
    }

    void TogglePlatform()
    {
        isEnabled = !isEnabled;
        foreach (Transform child in gameObject.transform)
        {
            if (child.childCount > 0)
            {
                var c = child.GetChild(0);
                if (c.name == "PlayerHook" && c.childCount > 0)
                {
                    // Detach the player from the moving block
                    child.GetChild(0).GetChild(0).transform.parent = null;
                }
            }

            child.gameObject.SetActive(isEnabled);
        }
    }
}
