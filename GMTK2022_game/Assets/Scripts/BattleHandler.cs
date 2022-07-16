using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    private int playerDamage;
    private int enemyDamage;

    private Transform playerSpawnPoint;
    private Transform enemySpawnPoint;

    [SerializeField]
    private Button attackButton;


    private void Awake()
    {
        playerSpawnPoint = transform.GetChild(0).transform;
        enemySpawnPoint = transform.GetChild(1).transform;
    }
    void Start()
    {
        GameManager.Instance.UpdateBattleState(GameManager.BattleState.START);
        SpawnCharacters();
    }

    private void OnEnable()
    {
        GameManager.OnBattleStateChanged += HandleBattle;
    }

    private void OnDisable()
    {
        GameManager.OnBattleStateChanged -= HandleBattle;
    }
    private async void HandleBattle(GameManager.BattleState state)
    {
        // change banner
       
        attackButton.interactable = state == GameManager.BattleState.PLAYERTURN;

        if (GameManager.BattleState.ENEMYTURN == GameManager.Instance.currentState)
        {
            //anim
            await Task.Delay(1500);
            player.GetComponent<DiceManager>().TakeDamage(enemyDamage);
            GameManager.Instance.UpdateBattleState(GameManager.BattleState.PLAYERTURN);
        }


    }


    private async void SpawnCharacters()
    {
        Instantiate(player, playerSpawnPoint);
        Instantiate(enemy, enemySpawnPoint);
        playerDamage = player.GetComponent<DiceManager>().BaseDamage;
        enemyDamage = enemy.GetComponent<DiceManager>().BaseDamage;

        await Task.Delay(1500);
        GameManager.Instance.UpdateBattleState(GameManager.BattleState.PLAYERTURN);
    }

    public async void OnAttackButtonPressed()
    {
        // player attack Animation
        playerDamage = CalculateDamage(true);
        await Task.Delay(1500); // time
        enemy.GetComponent<DiceManager>().TakeDamage(playerDamage);
       
        //GameManager.Instance.UpdateBattleState(GameManager.BattleState.ENEMYTURN);
    }

    private int CalculateDamage(bool isPlayer)
    {
        int dmg;
        if (isPlayer)
        {
            dmg = UnityEngine.Random.Range(1, player.GetComponent<DiceManager>().BaseDamage + 1);
        } else
        {
            dmg = UnityEngine.Random.Range(1, enemy.GetComponent<DiceManager>().BaseDamage + 1);
        }

        return dmg;
    }

    public void SetCardEffect(int dmgMultiplier, int hpMultiplier, int dmgBase, int hpBase)
    {
        playerDamage = playerDamage + (playerDamage * dmgMultiplier) + dmgBase;
    }
}
