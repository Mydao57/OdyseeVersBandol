using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurEffect : MonoBehaviour
{
    public Material blurMaterial;

    void Start()
    {
        if (blurMaterial == null)
        {
            Debug.LogError("Blur material not assigned!");
            return;
        }

        // Apply the blur material to the player's vision
        GetComponent<SpriteRenderer>().material = blurMaterial;
    }
}