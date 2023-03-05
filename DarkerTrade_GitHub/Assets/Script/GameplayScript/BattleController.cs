using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleController : MonoBehaviour
{
    public static BattleController instance;

    public float TimeBetweenTurn = 2.25f;


    private void Awake()
    {
        instance = this;
    }


    public int StartingMana = 4 ,MaxMana = 10;
    public int Standby;
    public int PlayerMana,EnemyMana;
    //public int UseManaPerTurn, EnemyUseManaPerTurn;
    public int PlayerManaUsed = 0;
    public int EnemyManaUsed = 0;
    public int playerManaUsedThisTurn;
    public int enemyManaUsedThisTurn;


    private int currentPlayerMaxMana,currentEnemyMaxMana;

    //Player Cards Starting
    public int startingCardsAmount = 5;

    public enum TurnOrder { playerActive,playerCardAttacks,enemyActive,enemyCardAttack,LeaderAttack}
    public TurnOrder currentPhase;
    public int cardsToDrawPerTurn = 0;

    public int CardPlacePerTurn = 0;
    public int EnemyCardPlace = 0;

    public Transform discardPoint;

    public int playerHealth;
    public int enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentPlayerMaxMana = StartingMana;
        currentEnemyMaxMana = StartingMana;
        FillPlayerMana();
        FillEnemyMana();
        Standby = 0;
        DeckController.instance.DrawMultipleCards(startingCardsAmount);

        UIController.instance.SetPlayerLeaderHealth(playerHealth);
        UIController.instance.SetEnemyLeaderHealth(enemyHealth);
        UIController.instance.TurnReaderText.text = "Player Turn";

    }

    // Update is called once per frame 
    void Update()
    {


    }

   /* public void PlayerUseManaPerTurn(int amountOfUse)
    {
         //เมื่อผู้เล่นวางการ์ด ค่าใช้มานาก็จะขึ้นตามจำนวนค่ามานาของการ์ด (ไว้ใช้คำนวณพลังโจมตีศัตรู)
        PlayerMana += amountOfUse;
        UseManaPerTurn += amountOfUse;

    }

    public void EUseManaPerTurn(int amountOfUse)
    {
        //เมื่อผู้ศัตรูวางการ์ด ค่าใช้มานาก็จะขึ้นตามจำนวนค่ามานาของการ์ด (ไว้ใช้คำนวณพลังโจมตีผู้เล่น)
        EnemyMana += amountOfUse;
        EnemyUseManaPerTurn += amountOfUse;

    }*/

    public void SpendPlayerMana(int amountOfSpend)
    {
        PlayerMana = PlayerMana - amountOfSpend;
        PlayerManaUsed += amountOfSpend;

        if (PlayerMana < 0)
        {
            PlayerMana = 0;
        }

        UIController.instance.SetPlayerManaText(PlayerMana);
    }

    public void SpendEnemyMana(int amountOfSpend)
    {
        EnemyMana = EnemyMana - amountOfSpend;
        EnemyManaUsed += amountOfSpend;

            if(EnemyMana < 0)
        {
            EnemyMana = 0;
            Debug.Log("EnemyMana = 0");
        }
        UIController.instance.SetEnemyManaText(EnemyMana);
    }

    public void FillEnemyMana()
    {
        EnemyMana = currentEnemyMaxMana;
        UIController.instance.SetEnemyManaText(EnemyMana);

    }

    public void FillPlayerMana()
    {
        // PlayerMana = StartingMana;

        PlayerMana = currentPlayerMaxMana;
        UIController.instance.SetPlayerManaText(PlayerMana);

    }

    public void AdvanceTurn()
    {
        currentPhase++;

        if((int)(currentPhase) >= System.Enum.GetValues(typeof(TurnOrder)).Length)
        {
            currentPhase = 0;
        }

        switch (currentPhase)
        {
            case TurnOrder.playerActive:

                UIController.instance.endTurnButton.SetActive(true);
             //   UIController.instance.drawCardButton.SetActive(true);

                if(currentPlayerMaxMana < MaxMana)
                {
                    currentPlayerMaxMana++;
                }

                FillPlayerMana();
                FillEnemyMana();
                DeckController.instance.DrawMultipleCards(cardsToDrawPerTurn + CardPlacePerTurn);
                CardPlacePerTurn = 0;
                CardPointController.instance.hasAttacked1 = false; CardPointController.instance.hasAttacked2 = false; CardPointController.instance.hasAttacked3 = false; CardPointController.instance.hasAttacked4 = false; CardPointController.instance.hasAttacked5 = false;
                CardPointController.instance.hasAttacked6 = false; CardPointController.instance.hasAttacked7 = false; CardPointController.instance.hasAttacked8 = false; CardPointController.instance.hasAttacked9 = false; CardPointController.instance.hasAttacked10 = false;
                CardPointController.instance.hasAttacked11 = false; CardPointController.instance.hasAttacked12 = false; CardPointController.instance.hasAttacked13 = false; CardPointController.instance.hasAttacked14 = false; CardPointController.instance.hasAttacked15 = false; CardPointController.instance.hasAttacked16 = false;

                UIController.instance.TurnReaderText.text = "Player Turn";


                break;

            case TurnOrder.playerCardAttacks:

                //Debug.Log("skipping Player Card Attack");
    
                CardPointController.instance.PlayerAttack();
                UIController.instance.TurnReaderText.text = "Player Attack";


                break;

            case TurnOrder.enemyActive:

                if (currentEnemyMaxMana < MaxMana)
                {
                    currentEnemyMaxMana++;
                }


                CardPointController.instance.hasAttacked1 = false; CardPointController.instance.hasAttacked2 = false; CardPointController.instance.hasAttacked3 = false; CardPointController.instance.hasAttacked4 = false; CardPointController.instance.hasAttacked5 = false;
                CardPointController.instance.hasAttacked6 = false; CardPointController.instance.hasAttacked7 = false; CardPointController.instance.hasAttacked8 = false; CardPointController.instance.hasAttacked9 = false; CardPointController.instance.hasAttacked10 = false;
                CardPointController.instance.hasAttacked11 = false; CardPointController.instance.hasAttacked12 = false; CardPointController.instance.hasAttacked13 = false; CardPointController.instance.hasAttacked14 = false; CardPointController.instance.hasAttacked15 = false; CardPointController.instance.hasAttacked16 = false;
                UIController.instance.TurnReaderText.text = "Enemy Turn";
                //AdvanceTurn();
                EnemyController.instance.StartAction();


                break;

            case TurnOrder.enemyCardAttack:

                Debug.Log("Enemy Card Attack");
                //AdvanceTurn();
                CardPointController.instance.EnemyCardAttack();
                UIController.instance.TurnReaderText.text = "Enemy Attack";

                break;

            case TurnOrder.LeaderAttack:

                /*for (int i = 0; i < CardPointController.instance.enemyCardPoints.Length ; i++)
                 {
                     CardPointController.instance.enemyCardPoints[i].activeCard = null;
                   //  CardPointController.instance.playerCardPoints[i].activeCard.anim.SetTrigger("AttackLeader");
                     Debug.Log("EnemyPointNotActivated");
                 } //Card active = null
                 for (int i = 0; i < CardPointController.instance.playerCardPoints.Length; i++)
                 {
                     CardPointController.instance.playerCardPoints[i].activeCard = null;
                     //  CardPointController.instance.playerCardPoints[i].activeCard.anim.SetTrigger("AttackLeader");
                     Debug.Log("PlayerPointNotActivated");
                 } //Card active = null*/

                Standby++;
                if(Standby == 2)
                {
                    Debug.Log("Leader Attack");
                    DamageEnemy(PlayerManaUsed);
                    DamagePlayer(EnemyManaUsed);
                    UIController.instance.TurnReaderText.text = "Leader Attack";
                    PlayerManaUsed = 0;
                    EnemyManaUsed = 0;

                    AdvanceTurn();

                    PlayerManaUsed += playerManaUsedThisTurn;
                    EnemyManaUsed += enemyManaUsedThisTurn;
                    playerManaUsedThisTurn = 0;
                    enemyManaUsedThisTurn = 0;
                    Standby = 0;
                }
                else
                {
                    Debug.Log("Standby");
                    UIController.instance.TurnReaderText.text = "Standby";
                    AdvanceTurn();
                }

                //AdvanceTurn();
                break;
        }
    }


    public void EndPlayerTurn()
    {
        UIController.instance.endTurnButton.SetActive(false);
        //  UIController.instance.drawCardButton.SetActive(false);
        new WaitForSeconds(TimeBetweenTurn);
        AdvanceTurn();
    }

    public void DamageEnemy(int costAmount)
    {
        //costAmount = PlayerManaUsed;
        playerManaUsedThisTurn += costAmount;

        if (enemyHealth > 0)
        {
      
            SpendPlayerMana(costAmount);
            enemyHealth -= costAmount;

            if(enemyHealth <= 0)
            {
                enemyHealth = 0;

                //End Battle
            }

            UIController.instance.SetEnemyLeaderHealth(enemyHealth);

            UIDamageIndicator damageClone = Instantiate(UIController.instance.enemyDamage, UIController.instance.enemyDamage.transform.parent );
            damageClone.damageText.text = costAmount.ToString();
            if(costAmount > 0)
            {
                damageClone.gameObject.SetActive(true);
            }

        }
    }


    // Attack Player Leader
    public void DamagePlayer(int enemycostAmount)
    {
        //enemycostAmount = EnemyManaUsed;
        enemyManaUsedThisTurn += enemycostAmount;

        if (playerHealth > 0)
        {

            SpendEnemyMana(enemycostAmount);
            playerHealth -= enemycostAmount;
            Debug.Log("EnemyAttackLeader");

                if(playerHealth <= 0)
            {
                playerHealth = 0;

                //End Battle
            }

            UIController.instance.SetPlayerLeaderHealth(playerHealth);
            UIDamageIndicator damageClone = Instantiate(UIController.instance.playerDamage, UIController.instance.playerDamage.transform.parent);
            damageClone.damageText.text = enemycostAmount.ToString();
            if (enemycostAmount > 0)
            {
                damageClone.gameObject.SetActive(true);
            }
        }

    }

}
