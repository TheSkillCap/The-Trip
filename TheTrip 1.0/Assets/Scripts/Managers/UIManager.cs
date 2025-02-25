using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Player Stats")]
    public TextMeshProUGUI wealthText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        wealthText.text = GlobalVariables.playerHealth.ToString();
    }
}
