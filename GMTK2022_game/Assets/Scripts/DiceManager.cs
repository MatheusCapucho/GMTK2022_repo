using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    [SerializeField] private DiceComponent diceComponent;

    private int maxHealth;
    public int CurrentHealth { get; private set; }
    public int Damage { get; private set; }

    private void Start()
    {
        maxHealth = diceComponent.MaxHealth;
        CurrentHealth = maxHealth;
        Damage = diceComponent.attack;
    }

    private void OnEnable()
    {
        GameManager.OnBattleStateChanged += CheckBattleSituation;
    }
    private void OnDisable()
    {
        GameManager.OnBattleStateChanged -= CheckBattleSituation;
    }

    private void CheckBattleSituation(GameManager.BattleState state)
    {
        
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth -= amount;
        if (CurrentHealth <= 0)
        {
            if (GameManager.Instance.currentState == GameManager.BattleState.PLAYERTURN)
                GameManager.Instance.UpdateBattleState(GameManager.BattleState.WIN);
            else
                GameManager.Instance.UpdateBattleState(GameManager.BattleState.LOST);
        }
    }


}
