using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceInventory : MonoBehaviour
{
    public static DiceInventory Instance;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        DontDestroyOnLoad(Instance);

    }

    public GameObject[] StartingDices;

    public void SetStartingDices(int index, GameObject dice)
    {
        StartingDices[index] = dice;
    }

}
