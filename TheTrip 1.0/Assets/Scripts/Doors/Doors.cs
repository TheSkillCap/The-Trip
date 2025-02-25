using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    public GameObject key;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (PlayerController.instance.inputI == 1 && key.GetComponent<Key>().isPicked)
            {
                gameObject.SetActive(false);
                
            }
           
        }
    }
    
  
}
