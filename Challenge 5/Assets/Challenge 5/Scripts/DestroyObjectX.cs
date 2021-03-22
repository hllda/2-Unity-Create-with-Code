using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectX : MonoBehaviour
{
    void Start()
    {
        // destroy particle after 3 seconds
        Destroy(gameObject, 3);
    }
}