using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewels : MonoBehaviour
{
    [SerializeField] private int jewelValue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.WealthIncrease(jewelValue);
            Destroy(gameObject);
        }
    }
}
