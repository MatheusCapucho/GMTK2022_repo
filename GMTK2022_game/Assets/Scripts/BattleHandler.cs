using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class BattleHandler : MonoBehaviour
{
    // Sorry..

    public GameObject[] enemy;

    private GameObject playerGO;
    private GameObject enemyGO;   

    private int playerDamage;
    private int enemyDamage;  

    private Transform playerSpawnPoint;
    private Transform enemySpawnPoint;

    [SerializeField]
    private Button attackButton;
    [SerializeField]
    private Button attackButton2;
    [SerializeField]
    private Button attackButton3;

    private int diceIndex = -1;
    private int enemyDiceIndex = -1;


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
    private  void HandleBattle(GameManager.BattleState state)
    {
        // change banner
       
        attackButton.interactable = state == GameManager.BattleState.PLAYERTURN;
        
        if (state == GameManager.BattleState.LOST && diceIndex <= 2)
        {
            attackButton.interactable = true;
        }


    }


    private async void SpawnCharacters()
    {
        playerGO = Instantiate(DiceInventory.Instance.StartingDices[++diceIndex], playerSpawnPoint);
        playerGO.GetComponentInChildren<SpriteRenderer>().flipX = true;
        enemyGO = Instantiate(enemy[++enemyDiceIndex], enemySpawnPoint);

        playerGO.GetComponent<Dice>().Setup();
        enemyGO.GetComponent<Dice>().Setup();

        playerDamage = playerGO.GetComponent<Dice>().Attack;
        enemyDamage = enemyGO.GetComponent<Dice>().Attack;

        await Task.Delay(1500);
        GameManager.Instance.UpdateBattleState(GameManager.BattleState.PLAYERTURN);
    }

    public async void OnAttackButtonPressed()
    {
        GameManager.Instance.UpdateBattleState(GameManager.BattleState.BATTLESITUATION);
        playerDamage = CalculateDamage(true);
        enemyDamage = CalculateDamage(false);

        playerGO.GetComponentInChildren<Animator>().SetTrigger("AttackR");
        //enemyGO.GetComponentInChildren<Animator>().SetTrigger("AttackL");

        await Task.Delay(1500);

        enemyGO.GetComponent<Dice>().TakeDamage(playerDamage, false);
        int enemyHealth = enemyGO.GetComponent<Dice>().CurrentHealth;

        if (enemyHealth <= 0)
            return;

        playerGO.GetComponent<Dice>().TakeDamage(enemyDamage, true);
        int playerHealth = playerGO.GetComponent<Dice>().CurrentHealth;

    }


    private int CalculateDamage(bool isPlayer)
    {
        int dmg;
       
        if (isPlayer)
        {
            dmg = UnityEngine.Random.Range(1, playerDamage+1);
        } else
        {
            dmg = UnityEngine.Random.Range(1, enemyDamage+1);
        }

        return dmg;
    }

    public void SpawnNewPlayer(GameObject player)
    {
        playerGO = Instantiate(player, playerSpawnPoint);
        playerGO.GetComponentInChildren<SpriteRenderer>().flipX = true;
        playerGO.GetComponent<Dice>().Setup();
        playerDamage = playerGO.GetComponent<Dice>().Attack;
        diceIndex++;
    }

    public void SetCardEffect(int dmgMultiplier, int hpMultiplier, int dmgBase, int hpBase)
    {
        playerDamage = (playerDamage * dmgMultiplier) + dmgBase;
    }
}
