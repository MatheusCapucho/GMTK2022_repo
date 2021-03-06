using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsList : MonoBehaviour
{
    public static CardsList Instance;

    [SerializeField] private List<Cards> myDeck;
    private GameObject[] cardHand;
    private Transform[] cardSlot;
    private bool[] usedCard;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        DontDestroyOnLoad(Instance);
    }

}
