using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    //Se almacena cuales llaves se han recogido
    [HideInInspector] public bool redKey;
    [HideInInspector] public bool blueKey;
    [HideInInspector] public bool yellowKey;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        redKey = false;
        blueKey = false;
        yellowKey = false;
        GlobalVariables.playerHealth = 0;
    }

    public void WealthIncrease(int amount)
    {
        GlobalVariables.playerHealth += amount;
    }

}
