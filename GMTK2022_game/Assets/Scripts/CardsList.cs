using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsList : MonoBehaviour
{
    public static CardsList Instance;


    public List<Cards> myDeck;
    private GameObject cardHand;
    private Transform[] cardSlot;

    [SerializeField] private Cards baseCard;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        DontDestroyOnLoad(Instance);
    }
    private void Start()
    {
        myDeck.Add(baseCard);
    }

}
