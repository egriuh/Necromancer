using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngrediantScript : MonoBehaviour
{
    // Variables
    public Animator animator;

    public bool canBeGathered;

    [Header("Player")]
    public GameObject player;

    private void OnMouseDown()
    {
       // Destroy/gather ingrediants
       Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Gather") && canBeGathered)
        {
            player.GetComponent<Animator>().SetTrigger("gathering");
            //you probably want to add to the inventory here

            Destroy(gameObject, 1.5f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canBeGathered = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = null;
            canBeGathered = false;
        }
      
    }
}
