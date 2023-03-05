using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPointController : MonoBehaviour
{

    public static CardPointController instance;

    public float TimeBetweenAttack = 0.25f;

    public bool hasAttacked1 = false, hasAttacked2 = false , hasAttacked3 = false, hasAttacked4 = false, hasAttacked5 = false, hasAttacked6 = false, hasAttacked7 = false
        , hasAttacked8 = false, hasAttacked9 = false, hasAttacked10 = false, hasAttacked11 = false, hasAttacked12 = false, hasAttacked13 = false, hasAttacked14 = false
        , hasAttacked15 = false, hasAttacked16 = false;
    public bool canAttack1 = true;


    private void Awake()
    {
        instance = this;
    }

    public CardPlacePoint[] playerCardPoints, enemyCardPoints;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayerAttack()
    {
        StartCoroutine(PlayerAttackCo());
    }

    IEnumerator PlayerAttackCo()
    {
        yield return new WaitForSeconds(TimeBetweenAttack);

        for (int i = 0; i < playerCardPoints.Length; i++)
        {
            // ATTACK POINT 1
            if (playerCardPoints[0].activeCard != null)
            {


                if (enemyCardPoints[1].activeCard != null && !hasAttacked1)
                {
                    //AttackEnemyCard
                    enemyCardPoints[1].activeCard.DamageCardRight(playerCardPoints[0].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[0].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked1 = true;
                    //canAttack1 = false;
                }
                if (enemyCardPoints[3].activeCard != null && !hasAttacked1)
                {
                    enemyCardPoints[3].activeCard.DamageCardLeft(playerCardPoints[0].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[0].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked1 = true;
                    //canAttack1 = false;
                }
                if (enemyCardPoints[4].activeCard != null && !hasAttacked1)
                {
                    enemyCardPoints[4].activeCard.DamageCardTop(playerCardPoints[0].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[0].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked1 = true;
                    //canAttack1 = false;
                }
                else
                {

                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

                if (playerCardPoints[1].activeCard != null)
                {
                    if (enemyCardPoints[2].activeCard != null && !hasAttacked2)
                    {
                        //AttackEnemyCard

                        enemyCardPoints[2].activeCard.DamageCardRight(playerCardPoints[1].activeCard.attackPowerRight);
                        Debug.Log("AttackRight");
                    playerCardPoints[1].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked2 = true;
                }
                    if (enemyCardPoints[0].activeCard != null && !hasAttacked2)
                    {
                        enemyCardPoints[0].activeCard.DamageCardLeft(playerCardPoints[1].activeCard.attackPowerLeft);
                        Debug.Log("AttackLeft");
                    playerCardPoints[1].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked2 = true;
                }
                    if (enemyCardPoints[5].activeCard != null && !hasAttacked2)
                    {
                        enemyCardPoints[5].activeCard.DamageCardTop(playerCardPoints[1].activeCard.attackPowerTop);
                        Debug.Log("AttackTop");
                    playerCardPoints[1].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked2 = true;
                }
                    else
                    {
 
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
               // playerCardPoints[1].activeCard = null;
                    yield return new WaitForSeconds(TimeBetweenAttack);
                }
            if (playerCardPoints[2].activeCard != null)
            {

                if (enemyCardPoints[1].activeCard != null && !hasAttacked3)
                {
                    enemyCardPoints[1].activeCard.DamageCardLeft(playerCardPoints[2].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[2].activeCard.anim.SetTrigger("AttackLeft");
                 hasAttacked3 = true;
                }
                if (enemyCardPoints[6].activeCard != null && !hasAttacked3)
                {
                    enemyCardPoints[6].activeCard.DamageCardTop(playerCardPoints[2].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[2].activeCard.anim.SetTrigger("AttackTop");
                 hasAttacked3 = true;
                }
                else
                {

                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
               // playerCardPoints[2].activeCard = null;
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[3].activeCard != null)
            {

                if (enemyCardPoints[0].activeCard != null && !hasAttacked4)
                {
                    enemyCardPoints[0].activeCard.DamageCardRight(playerCardPoints[3].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[3].activeCard.anim.SetTrigger("AttackRight");
                 hasAttacked4 = true;
                }
                if (enemyCardPoints[7].activeCard != null && !hasAttacked4)
                {
                    enemyCardPoints[7].activeCard.DamageCardTop(playerCardPoints[3].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[3].activeCard.anim.SetTrigger("AttackTop");
                 hasAttacked4 = true;
                }
                else
                {
               
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
              //  playerCardPoints[3].activeCard = null;
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[4].activeCard != null)
            {

                if (enemyCardPoints[0].activeCard != null && !hasAttacked5)
                {
                    enemyCardPoints[0].activeCard.DamageCardDown(playerCardPoints[4].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[4].activeCard.anim.SetTrigger("AttackDown");
                 hasAttacked5 = true;
                }
                if (enemyCardPoints[8].activeCard != null && !hasAttacked5)
                {
                    enemyCardPoints[8].activeCard.DamageCardTop(playerCardPoints[4].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[4].activeCard.anim.SetTrigger("AttackTop");
                hasAttacked5 = true;
                }
                if (enemyCardPoints[7].activeCard != null && !hasAttacked5)
                {
                    enemyCardPoints[7].activeCard.DamageCardLeft(playerCardPoints[4].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[4].activeCard.anim.SetTrigger("AttackLeft");
                hasAttacked5 = true;
                }
                if (enemyCardPoints[5].activeCard != null && !hasAttacked5)
                {
                    enemyCardPoints[5].activeCard.DamageCardRight(playerCardPoints[4].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[4].activeCard.anim.SetTrigger("AttackRight");
                 hasAttacked5 = true;
                }
                else
                {
                 
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
               // playerCardPoints[4].activeCard = null;
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[5].activeCard != null)
            {

                if (enemyCardPoints[6].activeCard != null && !hasAttacked6)
                {
                    enemyCardPoints[6].activeCard.DamageCardRight(playerCardPoints[5].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[5].activeCard.anim.SetTrigger("AttackRight");
                 hasAttacked6 = true;
                }
                if (enemyCardPoints[9].activeCard != null && !hasAttacked6)
                {
                    enemyCardPoints[9].activeCard.DamageCardTop(playerCardPoints[5].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[5].activeCard.anim.SetTrigger("AttackTop");
                 hasAttacked6 = true;
                }
                if (enemyCardPoints[4].activeCard != null && !hasAttacked6)
                {
                    enemyCardPoints[4].activeCard.DamageCardLeft(playerCardPoints[5].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[5].activeCard.anim.SetTrigger("AttackLeft");
                 hasAttacked6 = true;
                }
                if (enemyCardPoints[1].activeCard != null && !hasAttacked6)
                {
                    enemyCardPoints[1].activeCard.DamageCardDown(playerCardPoints[5].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[5].activeCard.anim.SetTrigger("AttackDown");
                 hasAttacked6 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
              //  playerCardPoints[5].activeCard = null;
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[6].activeCard != null)
            {

                if (enemyCardPoints[5].activeCard != null && !hasAttacked7)
                {
                    enemyCardPoints[5].activeCard.DamageCardLeft(playerCardPoints[6].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[6].activeCard.anim.SetTrigger("AttackLeft");
                   hasAttacked7 = true;
                }
                if (enemyCardPoints[10].activeCard != null && !hasAttacked7)
                {
                    enemyCardPoints[10].activeCard.DamageCardTop(playerCardPoints[6].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[6].activeCard.anim.SetTrigger("AttackTop");
                 hasAttacked7 = true;
                }
                if (enemyCardPoints[2].activeCard != null && !hasAttacked7)
                {
                    enemyCardPoints[2].activeCard.DamageCardDown(playerCardPoints[6].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[6].activeCard.anim.SetTrigger("AttackDown");
                hasAttacked7 = true;
                }
                else 
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
              //  playerCardPoints[6].activeCard = null;
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

           if (playerCardPoints[7].activeCard != null)
            {

                if (enemyCardPoints[4].activeCard != null && !hasAttacked8)
                {
                    enemyCardPoints[4].activeCard.DamageCardRight(playerCardPoints[7].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[7].activeCard.anim.SetTrigger("AttackRight");
                hasAttacked8 = true;
                }
                if (enemyCardPoints[11].activeCard != null && !hasAttacked8)
                {
                    enemyCardPoints[11].activeCard.DamageCardTop(playerCardPoints[7].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[7].activeCard.anim.SetTrigger("AttackTop");
               hasAttacked8 = true;
                }
                if (enemyCardPoints[3].activeCard != null && !hasAttacked8)
                {
                    enemyCardPoints[3].activeCard.DamageCardDown(playerCardPoints[7].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[7].activeCard.anim.SetTrigger("AttackDown");
                 hasAttacked8 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[8].activeCard != null)
            {

                if (enemyCardPoints[9].activeCard != null && !hasAttacked9)
                {
                    enemyCardPoints[9].activeCard.DamageCardRight(playerCardPoints[8].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[8].activeCard.anim.SetTrigger("AttackRight");
                 hasAttacked9 = true;
                }
                if (enemyCardPoints[12].activeCard != null && !hasAttacked9)
                {
                    enemyCardPoints[12].activeCard.DamageCardTop(playerCardPoints[8].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[8].activeCard.anim.SetTrigger("AttackTop");
                hasAttacked9 = true;
                }
                if (enemyCardPoints[11].activeCard != null && !hasAttacked9)
                {
                    enemyCardPoints[11].activeCard.DamageCardLeft(playerCardPoints[8].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[8].activeCard.anim.SetTrigger("AttackLeft");
                 hasAttacked9 = true;
                }
                if (enemyCardPoints[4].activeCard != null && !hasAttacked9)
                {
                    enemyCardPoints[4].activeCard.DamageCardDown(playerCardPoints[8].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[8].activeCard.anim.SetTrigger("AttackDown");
                hasAttacked9 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[9].activeCard != null)
            {

                if (enemyCardPoints[10].activeCard != null && !hasAttacked10)
                {
                    enemyCardPoints[10].activeCard.DamageCardRight(playerCardPoints[9].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[9].activeCard.anim.SetTrigger("AttackRight");
                hasAttacked10 = true;
                }
                if (enemyCardPoints[13].activeCard != null && !hasAttacked10)
                {
                    enemyCardPoints[13].activeCard.DamageCardTop(playerCardPoints[9].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[9].activeCard.anim.SetTrigger("AttackTop");
                hasAttacked10 = true;
                }
                if (enemyCardPoints[8].activeCard != null && !hasAttacked10)
                {
                    enemyCardPoints[8].activeCard.DamageCardLeft(playerCardPoints[9].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                hasAttacked10 = true;
                    playerCardPoints[9].activeCard.anim.SetTrigger("AttackLeft");
                }
                if (enemyCardPoints[5].activeCard != null && !hasAttacked10)
                {
                    enemyCardPoints[5].activeCard.DamageCardDown(playerCardPoints[9].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[9].activeCard.anim.SetTrigger("AttackDown");
                hasAttacked10 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[10].activeCard != null)
            {

                if (enemyCardPoints[9].activeCard != null && !hasAttacked11)
                {
                    enemyCardPoints[9].activeCard.DamageCardLeft(playerCardPoints[10].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[10].activeCard.anim.SetTrigger("AttackLeft");
              hasAttacked11 = true;
                }
                if (enemyCardPoints[14].activeCard != null && !hasAttacked11)
                {
                    enemyCardPoints[14].activeCard.DamageCardTop(playerCardPoints[10].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[10].activeCard.anim.SetTrigger("AttackTop");
             hasAttacked11 = true;
                }
                if (enemyCardPoints[6].activeCard != null && !hasAttacked11)
                {
                    enemyCardPoints[6].activeCard.DamageCardDown(playerCardPoints[10].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[10].activeCard.anim.SetTrigger("AttackDown");
                hasAttacked11 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[11].activeCard != null)
            {

                if (enemyCardPoints[8].activeCard != null && !hasAttacked12)
                {
                    enemyCardPoints[8].activeCard.DamageCardRight(playerCardPoints[11].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[11].activeCard.anim.SetTrigger("AttackRight");
                hasAttacked12 = true;
                }
                if (enemyCardPoints[15].activeCard != null && !hasAttacked12)
                {
                    enemyCardPoints[15].activeCard.DamageCardTop(playerCardPoints[11].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    playerCardPoints[11].activeCard.anim.SetTrigger("AttackTop");
                 hasAttacked12 = true;
                }
                if (enemyCardPoints[7].activeCard != null && !hasAttacked12)
                {
                    enemyCardPoints[7].activeCard.DamageCardDown(playerCardPoints[11].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[11].activeCard.anim.SetTrigger("AttackDown");
                 hasAttacked12 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[12].activeCard != null)
            {

                if (enemyCardPoints[13].activeCard != null && !hasAttacked13)
                {
                    enemyCardPoints[13].activeCard.DamageCardRight(playerCardPoints[12].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[12].activeCard.anim.SetTrigger("AttackRight");
                 hasAttacked13 = true;
                }
                if (enemyCardPoints[15].activeCard != null && !hasAttacked13)
                {
                    enemyCardPoints[15].activeCard.DamageCardLeft(playerCardPoints[12].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[12].activeCard.anim.SetTrigger("AttackLeft");
                hasAttacked13 = true;
                }
                if (enemyCardPoints[8].activeCard != null && !hasAttacked13)
                {
                    enemyCardPoints[8].activeCard.DamageCardDown(playerCardPoints[12].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[12].activeCard.anim.SetTrigger("AttackDown");
                  hasAttacked13 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[13].activeCard != null)
            {

                if (enemyCardPoints[14].activeCard != null && !hasAttacked14)
                {
                    enemyCardPoints[14].activeCard.DamageCardRight(playerCardPoints[13].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[13].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked14 = true;
                }
                if (enemyCardPoints[9].activeCard != null && !hasAttacked14)
                {
                    enemyCardPoints[9].activeCard.DamageCardDown(playerCardPoints[13].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[13].activeCard.anim.SetTrigger("AttackDown");
                  hasAttacked14 = true;
                }
                if (enemyCardPoints[12].activeCard != null && !hasAttacked14)
                {
                    enemyCardPoints[12].activeCard.DamageCardLeft(playerCardPoints[13].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[13].activeCard.anim.SetTrigger("AttackLeft");
                   hasAttacked14 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[14].activeCard != null)
            {

                if (enemyCardPoints[13].activeCard != null && !hasAttacked15)
                {
                    enemyCardPoints[13].activeCard.DamageCardLeft(playerCardPoints[14].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    playerCardPoints[14].activeCard.anim.SetTrigger("AttackLeft");
                  hasAttacked15 = true;
                }
                if (enemyCardPoints[10].activeCard != null && !hasAttacked15)
                {
                    enemyCardPoints[10].activeCard.DamageCardDown(playerCardPoints[14].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[14].activeCard.anim.SetTrigger("AttackDown");
                 hasAttacked15 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (playerCardPoints[15].activeCard != null)
            {

                if (enemyCardPoints[11].activeCard != null && !hasAttacked16)
                {
                    enemyCardPoints[11].activeCard.DamageCardDown(playerCardPoints[15].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    playerCardPoints[15].activeCard.anim.SetTrigger("AttackDown");
                  hasAttacked16 = true;
                }
                if (enemyCardPoints[12].activeCard != null && !hasAttacked16)
                {
                    enemyCardPoints[12].activeCard.DamageCardRight(playerCardPoints[15].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    playerCardPoints[15].activeCard.anim.SetTrigger("AttackRight");
                  hasAttacked16 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            } 
        }

        CheckAssignedCards();
       BattleController.instance.AdvanceTurn();
    }


















    public void EnemyCardAttack()
    {
        StartCoroutine(EnenymyAttackCo()); 
    }

    IEnumerator EnenymyAttackCo()
    {
        yield return new WaitForSeconds(TimeBetweenAttack);

        for (int i = 0; i < enemyCardPoints.Length; i++)
        {
            // ATTACK POINT 1
            if (enemyCardPoints[0].activeCard != null)
            {
                //hasAttacked = false;
               // isEnemyPlace = true;
                if (playerCardPoints[1].activeCard != null && !hasAttacked1)
                {
                    //AttackEnemyCard
                    playerCardPoints[1].activeCard.DamageCardRight(enemyCardPoints[0].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[0].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked1 = true;
                }
                if (playerCardPoints[3].activeCard != null && !hasAttacked1)
                {
                    playerCardPoints[3].activeCard.DamageCardLeft(enemyCardPoints[0].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[0].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked1 = true;
                }
                if (playerCardPoints[4].activeCard != null && !hasAttacked1)
                {
                    playerCardPoints[4].activeCard.DamageCardTop(enemyCardPoints[0].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[0].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked1 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }
                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[1].activeCard != null)
            {
            //    isEnemyPlace = true;

                if (playerCardPoints[2].activeCard != null && !hasAttacked2)
                {
                    playerCardPoints[2].activeCard.DamageCardRight(enemyCardPoints[1].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[1].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked2 = true;
                }
                if (playerCardPoints[0].activeCard != null && !hasAttacked2)
                {
                    playerCardPoints[0].activeCard.DamageCardLeft(enemyCardPoints[1].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[1].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked2 = true;
                }
                if (playerCardPoints[5].activeCard != null && !hasAttacked2)
                {
                    playerCardPoints[5].activeCard.DamageCardTop(enemyCardPoints[1].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[1].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked2 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }
            if (enemyCardPoints[2].activeCard != null)
            {
             //   isEnemyPlace = true;

                if (playerCardPoints[1].activeCard != null && !hasAttacked3)
                {
                    playerCardPoints[1].activeCard.DamageCardLeft(enemyCardPoints[2].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[2].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked3 = true;
                }
                if (playerCardPoints[6].activeCard != null && !hasAttacked3)
                {
                    playerCardPoints[6].activeCard.DamageCardTop(enemyCardPoints[2].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[2].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked3 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[3].activeCard != null)
            {
             //   isEnemyPlace = true;

                if (playerCardPoints[0].activeCard != null && !hasAttacked4)
                {
                    playerCardPoints[0].activeCard.DamageCardRight(enemyCardPoints[3].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[3].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked4 = true;
                }
                if (playerCardPoints[7].activeCard != null && !hasAttacked4)
                {
                    playerCardPoints[7].activeCard.DamageCardTop(enemyCardPoints[3].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[3].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked4 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[4].activeCard != null)
            {

                if (playerCardPoints[0].activeCard != null && !hasAttacked5)
                {
                    playerCardPoints[0].activeCard.DamageCardDown(enemyCardPoints[4].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[4].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked5 = true;
                }
                if (playerCardPoints[8].activeCard != null && !hasAttacked5)
                {
                    playerCardPoints[8].activeCard.DamageCardTop(enemyCardPoints[4].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[4].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked5 = true;
                }
                if (playerCardPoints[7].activeCard != null && !hasAttacked5)
                {
                    playerCardPoints[7].activeCard.DamageCardLeft(enemyCardPoints[4].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[4].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked5 = true;
                }
                if (playerCardPoints[5].activeCard != null && !hasAttacked5)
                {
                    playerCardPoints[5].activeCard.DamageCardRight(enemyCardPoints[4].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[4].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked5 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[5].activeCard != null)
            {

                if (playerCardPoints[6].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[6].activeCard.DamageCardRight(enemyCardPoints[5].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[5].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked6 = true;
                }
                if (playerCardPoints[9].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[9].activeCard.DamageCardTop(enemyCardPoints[5].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[5].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked6 = true;
                }
                if (playerCardPoints[4].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[4].activeCard.DamageCardLeft(enemyCardPoints[5].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[5].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked6 = true;
                }
                if (playerCardPoints[1].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[1].activeCard.DamageCardDown(enemyCardPoints[5].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[5].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked6 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[6].activeCard != null)
            {

                if (playerCardPoints[5].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[5].activeCard.DamageCardLeft(enemyCardPoints[6].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[6].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked6 = true;
                }
                if (playerCardPoints[10].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[10].activeCard.DamageCardTop(enemyCardPoints[6].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[6].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked6 = true;
                }
                if (playerCardPoints[2].activeCard != null && !hasAttacked6)
                {
                    playerCardPoints[2].activeCard.DamageCardDown(enemyCardPoints[6].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[6].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked6 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[7].activeCard != null)
            {

                if (playerCardPoints[4].activeCard != null && !hasAttacked7)
                {
                    playerCardPoints[4].activeCard.DamageCardRight(enemyCardPoints[7].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[7].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked7 = true;
                }
                if (playerCardPoints[11].activeCard != null && !hasAttacked7)
                {
                    playerCardPoints[11].activeCard.DamageCardTop(enemyCardPoints[7].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[7].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked7 = true;
                }
                if (playerCardPoints[3].activeCard != null && !hasAttacked7)
                {
                    playerCardPoints[3].activeCard.DamageCardDown(enemyCardPoints[7].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[7].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked7 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[8].activeCard != null)
            {

                if (playerCardPoints[9].activeCard != null && !hasAttacked8)
                {
                    playerCardPoints[9].activeCard.DamageCardRight(enemyCardPoints[8].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[8].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked8 = true;
                }
                if (playerCardPoints[12].activeCard != null && !hasAttacked8)
                {
                    playerCardPoints[12].activeCard.DamageCardTop(enemyCardPoints[8].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[8].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked8 = true;
                }
                if (playerCardPoints[11].activeCard != null && !hasAttacked8)
                {
                    playerCardPoints[11].activeCard.DamageCardLeft(enemyCardPoints[8].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[8].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked8 = true;
                }
                if (playerCardPoints[4].activeCard != null && !hasAttacked8)
                {
                    playerCardPoints[4].activeCard.DamageCardDown(enemyCardPoints[8].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[8].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked8 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[9].activeCard != null)
            {

                if (playerCardPoints[10].activeCard != null && !hasAttacked9)
                {
                    playerCardPoints[10].activeCard.DamageCardRight(enemyCardPoints[9].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[9].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked9 = true;
                }
                if (playerCardPoints[13].activeCard != null && !hasAttacked9)
                {
                    playerCardPoints[13].activeCard.DamageCardTop(enemyCardPoints[9].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[9].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked9 = true;
                }
                if (playerCardPoints[8].activeCard != null && !hasAttacked9)
                {
                    playerCardPoints[8].activeCard.DamageCardLeft(enemyCardPoints[9].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    hasAttacked9 = true;
                    enemyCardPoints[9].activeCard.anim.SetTrigger("AttackLeft");
                }
                if (playerCardPoints[5].activeCard != null && !hasAttacked9)
                {
                    playerCardPoints[5].activeCard.DamageCardDown(enemyCardPoints[9].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[9].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked9 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[10].activeCard != null)
            {

                if (playerCardPoints[9].activeCard != null && !hasAttacked10)
                {
                    playerCardPoints[9].activeCard.DamageCardLeft(enemyCardPoints[10].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[10].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked10 = true;
                }
                if (playerCardPoints[14].activeCard != null && !hasAttacked10)
                {
                    playerCardPoints[14].activeCard.DamageCardTop(enemyCardPoints[10].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[10].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked10 = true;
                }
                if (playerCardPoints[6].activeCard != null && !hasAttacked10)
                {
                    playerCardPoints[6].activeCard.DamageCardDown(enemyCardPoints[10].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[10].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked10 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[11].activeCard != null)
            {

                if (playerCardPoints[8].activeCard != null && !hasAttacked11)
                {
                    playerCardPoints[8].activeCard.DamageCardRight(enemyCardPoints[11].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[11].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked11 = true;
                }
                if (playerCardPoints[15].activeCard != null && !hasAttacked11)
                {
                    playerCardPoints[15].activeCard.DamageCardTop(enemyCardPoints[11].activeCard.attackPowerTop);
                    Debug.Log("AttackTop");
                    enemyCardPoints[11].activeCard.anim.SetTrigger("AttackTop");
                    hasAttacked11 = true;
                }
                if (playerCardPoints[7].activeCard != null && !hasAttacked11)
                {
                    playerCardPoints[7].activeCard.DamageCardDown(enemyCardPoints[11].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[11].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked11 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[12].activeCard != null)
            {

                if (playerCardPoints[13].activeCard != null && !hasAttacked12)
                {
                    playerCardPoints[13].activeCard.DamageCardRight(enemyCardPoints[12].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[12].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked12 = true;
                }
                if (playerCardPoints[15].activeCard != null && !hasAttacked12)
                {
                    playerCardPoints[15].activeCard.DamageCardLeft(enemyCardPoints[12].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[12].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked12 = true;
                }
                if (playerCardPoints[8].activeCard != null && !hasAttacked12)
                {
                    playerCardPoints[8].activeCard.DamageCardDown(enemyCardPoints[12].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[12].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked12 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[13].activeCard != null)
            {

                if (playerCardPoints[14].activeCard != null && !hasAttacked13)
                {
                    playerCardPoints[14].activeCard.DamageCardRight(enemyCardPoints[13].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[13].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked13 = true;
                }
                if (playerCardPoints[9].activeCard != null && !hasAttacked13)
                {
                    playerCardPoints[9].activeCard.DamageCardDown(enemyCardPoints[13].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[13].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked13 = true;
                }
                if (playerCardPoints[12].activeCard != null && !hasAttacked13)
                {
                    playerCardPoints[12].activeCard.DamageCardLeft(enemyCardPoints[13].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[13].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked13 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[14].activeCard != null)
            {

                if (playerCardPoints[13].activeCard != null && !hasAttacked14)
                {
                    playerCardPoints[13].activeCard.DamageCardLeft(enemyCardPoints[14].activeCard.attackPowerLeft);
                    Debug.Log("AttackLeft");
                    enemyCardPoints[14].activeCard.anim.SetTrigger("AttackLeft");
                    hasAttacked14 = true;
                }
                if (playerCardPoints[10].activeCard != null && !hasAttacked14)
                {
                    playerCardPoints[10].activeCard.DamageCardDown(enemyCardPoints[14].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[14].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked14 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }

            if (enemyCardPoints[15].activeCard != null)
            {

                if (playerCardPoints[11].activeCard != null && !hasAttacked15)
                {
                    playerCardPoints[11].activeCard.DamageCardDown(enemyCardPoints[15].activeCard.attackPowerDown);
                    Debug.Log("AttackDown");
                    enemyCardPoints[15].activeCard.anim.SetTrigger("AttackDown");
                    hasAttacked15 = true;
                }
                if (playerCardPoints[12].activeCard != null && !hasAttacked15)
                {
                    playerCardPoints[12].activeCard.DamageCardRight(enemyCardPoints[15].activeCard.attackPowerRight);
                    Debug.Log("AttackRight");
                    enemyCardPoints[15].activeCard.anim.SetTrigger("AttackRight");
                    hasAttacked15 = true;
                }
                else
                {
                    //Attack Overall Leader Heath (Notthing Happen in RealGame)(CostPlayer - CostEnemy = LeaderDamage)
                }

                yield return new WaitForSeconds(TimeBetweenAttack);
            }
        }

        CheckAssignedCards();
        BattleController.instance.AdvanceTurn();

    }


    void CheckAssignedCards()
    {
        foreach (CardPlacePoint point in enemyCardPoints)
        {
            if (point.activeCard != null)
            {
                bool cardRemoved = false;

                if (point.activeCard.currentHealthDown <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
                if (!cardRemoved && point.activeCard.currentHealthTop <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
                if (!cardRemoved && point.activeCard.currentHealthLeft <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
                if (!cardRemoved && point.activeCard.currentHealthRight <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
            }
        }

        foreach (CardPlacePoint point in playerCardPoints)
        {
            if (point.activeCard != null)
            {
                bool cardRemoved = false;

                if (point.activeCard.currentHealthDown <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
                if (!cardRemoved && point.activeCard.currentHealthTop <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
                if (!cardRemoved && point.activeCard.currentHealthLeft <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
                if (!cardRemoved && point.activeCard.currentHealthRight <= 0)
                {
                    point.activeCard = null;
                    cardRemoved = true;
                }
            }
        }
    }

}
