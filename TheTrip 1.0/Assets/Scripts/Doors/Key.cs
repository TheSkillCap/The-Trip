using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Sprite sprite;
    public bool isPicked = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RumbleManager.instance.RumbleActive(0.25f, 1f, 0.5f);
            isPicked = true;
            gameObject.SetActive(false);
        }
    }

}
