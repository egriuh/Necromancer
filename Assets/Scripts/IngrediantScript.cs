using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngrediantScript : MonoBehaviour
{
    // Variables
    private GameManager gameManager;
    [Header("Player")]
    public GameObject player;

    public bool canBeGathered;

    private void OnMouseDown()
    {
       // Destroy/gather ingrediants
       Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Gather") && canBeGathered)
        {
            player.GetComponent<Animator>().SetTrigger("gathering");
            //you probably want to add to the inventory here

            Destroy(gameObject, 1.5f);
            gameManager.UpdateScore(5);
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
