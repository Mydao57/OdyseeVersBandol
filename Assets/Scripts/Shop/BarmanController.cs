using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarmanController : MonoBehaviour
{
    public float distanceToTrigger = 2f;
    public KeyCode dialogueKey = KeyCode.E;
    public GameObject shop;

    public Canvas WeaponSellerCanvas;

    private bool isInRange = false;

    public void Start()
    {
        shop.SetActive(false);
    }
    private void Update()
    {
        if (isInRange && Input.GetKeyDown(dialogueKey))
        {
            shop.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  
        {
            WeaponSellerCanvas.gameObject.SetActive(true);
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            WeaponSellerCanvas.gameObject.SetActive(false);

            shop.SetActive(false);
            isInRange = false;
        }
    }

    
}
