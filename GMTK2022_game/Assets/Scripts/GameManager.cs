using System;
using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public BattleState currentState;
    public static event Action<BattleState> OnBattleStateChanged;

    private int diceIndex = 0;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;

        DontDestroyOnLoad(Instance);

    }

    public enum BattleState
    {
        START,
        PLAYERTURN,
        ENEMYTURN,
        BATTLESITUATION,
        WIN,
        LOST,
        PAUSE
    }

    public void UpdateBattleState(BattleState newState)
    {
        currentState = newState;

        switch(newState)
        {
            case BattleState.START:
                HandleStart();
                break;
            case BattleState.PLAYERTURN:
                HandlePlayerTurn();
                break;
            case BattleState.ENEMYTURN:
                HandleEnemyTurn();
                break;
            case BattleState.BATTLESITUATION:
                HandleBattleSituation();
                break;
            case BattleState.WIN:
                HandleWin();
                break;
            case BattleState.LOST:
                HandleLost();
                break;
            case BattleState.PAUSE:
                break;
        }

        OnBattleStateChanged?.Invoke(newState);

    }

    private void HandleBattleSituation()
    {
    }
    private void HandleLost()
    {
        if (diceIndex < 2)
        {
            DiceInventory.Instance.StartingDices[diceIndex].SetActive(false);
            var battleHandler = FindObjectOfType<BattleHandler>();
            battleHandler.SpawnNewPlayer(DiceInventory.Instance.StartingDices[++diceIndex]);
        } else
        {
            // end game;
            Debug.Log("LostLostLost");
        }
    }

    private void HandleWin()
    {       
    }

    private void HandleEnemyTurn()
    {
    }

    private void HandlePlayerTurn()
    {      
    }

    private void HandleStart()
    {
        diceIndex = 0;
    }
}
