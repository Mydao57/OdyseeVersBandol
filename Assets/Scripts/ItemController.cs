using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float movementSpeed = 0;
    public float damage = 0;
    public float cooldoownReduction = 0;
    public float heal = 0;

    private bool isInRange = false;
    public KeyCode dialogueKey = KeyCode.E;

    public AudioClip pickupSound;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(dialogueKey))
        {
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main.transform.position);
            PickItem();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger");
        if (other.CompareTag("Player"))  
        {

            isInRange = true;
        }
    }

    private void PickItem() { 
       GameObject.Find("Player").GetComponent<PlayerController>().PickItem(this);
       Destroy(gameObject);
    }
}
