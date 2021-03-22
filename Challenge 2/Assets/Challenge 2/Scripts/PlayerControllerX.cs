using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float cooldown;

    // Update is called once per frame
    void Update()
    {
        // A counter that counts down to or below 0
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }

        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && cooldown <= 0)
        {
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            
            // Resets the counter
            cooldown = 1.0f;
        }
    }
}
