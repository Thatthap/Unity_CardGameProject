using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour 
{
    //Get a Card data from CardScriptableObject
    public CardScriptableObject cardSO;
    // Set information varible for card

    private float doubleClickTimeLimit = 0.25f; // time limit in seconds for double click
    private float lastClickTime = 0f; // time of last click

    public bool IsPlayer;

    public int currentHealthLeft , currentHealthRight , currentHealthTop , currentHealthDown;
    
    public int attackPowerLeft , attackPowerRight , attackPowerTop , attackPowerDown;
    public int OverallStats;
    public int PlayerAttackPower;
    public int EnemyAttackPower;

    public int manaCost;
    // Get a Text from card
    public TMP_Text AttackLeft, AttackRight, AttackTop, AttackDown, HealthLeft, HealthRight, HealthTop, HealthDown, NameText, ActionDescriptionText, LoreText, ATKLeft, ATKRight, ATKTop, ATKDown,ManaCost;

    public Image CardArt;

    private Vector3 targetPoint;

    public float moveSpeed = 5f , rotateSpeed = 540f;

    private Quaternion targetRot;

    public bool inHand;
    public int handPosition;

    public bool onRead;
    public bool CardDeath;

    private HandController theHC;

    private bool isSelected;
    private Collider theCol;

    public LayerMask whatIsDesktop , whatIsPlacment;
    private bool justPressed;

    public CardPlacePoint assignedPlace;

    public Animator anim;
    public float TimeBeforeDead = 0.60f;



    // Start is called before the first frame update
    void Start()
    {

        if (targetPoint == Vector3.zero)
        {
            targetPoint = transform.position;
            targetRot = transform.rotation;
        }

     //   AttackLeft.enabled = false;
      //  AttackRight.enabled = false;
      //  AttackTop.enabled = false;
      //  AttackDown.enabled = false;

        SetupCard();
        theHC = FindObjectOfType<HandController>();
        theCol = GetComponent<Collider>();
        
    }


    public void SetupCard()
    {
        currentHealthLeft = cardSO.currentHeathLeft;
        currentHealthRight = cardSO.currentHeathRight;
        currentHealthTop = cardSO.currentHeathTop;
        currentHealthDown = cardSO.currentHeathDown;

        attackPowerLeft = cardSO.attackPowerLeft;
        attackPowerRight = cardSO.attackPowerRight;
        attackPowerTop = cardSO.attackPowerTop;
        attackPowerDown = cardSO.attackPowerDown;

        NameText.text = cardSO.CardName;
        ActionDescriptionText.text = cardSO.ActionDescription;
        LoreText.text = cardSO.CardLore;

        manaCost = cardSO.manaCost;

        HealthLeft.text = currentHealthLeft.ToString(); HealthRight.text = currentHealthRight.ToString(); HealthTop.text = currentHealthTop.ToString(); HealthDown.text = currentHealthDown.ToString();
        AttackLeft.text = attackPowerLeft.ToString(); AttackRight.text = attackPowerRight.ToString(); AttackTop.text = attackPowerTop.ToString(); AttackDown.text = attackPowerDown.ToString();
        ATKLeft.text = attackPowerLeft.ToString(); ATKRight.text = attackPowerRight.ToString(); ATKTop.text = attackPowerTop.ToString(); ATKDown.text = attackPowerDown.ToString(); ManaCost.text = manaCost.ToString();
        CardArt.sprite = cardSO.CardSprite;
        PlayerAttackPower = manaCost;

        OverallStats = attackPowerLeft + attackPowerRight + attackPowerTop + attackPowerDown;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);

        //SELECTED A CARD
        if (isSelected )
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, whatIsDesktop))
            {
                MovetoPoint(hit.point + new Vector3(-0.2f, 0f, -0.2f), Quaternion.identity);

            }


            if (Input.GetMouseButtonDown(1))
            {
                ReturnToHand();
            }


            if (Input.GetMouseButtonDown(0) && justPressed == false )
            {

                if (Physics.Raycast(ray, out hit, 100f, whatIsPlacment) && BattleController.instance.currentPhase == BattleController.TurnOrder.playerActive)
                {

                    CardPlacePoint selectedPoint = hit.collider.GetComponent<CardPlacePoint>();

                    if (selectedPoint.activeCard == null && selectedPoint.isPlayerPoint)
                    {
                            if (BattleController.instance.PlayerMana >= manaCost)
                            {



                            if (CardPlacePoint.instance.IsEnemyPlace == true)
                           {
                               ReturnToHand();
                               Debug.Log("Enemy Place");
                            }
                           else
                            {
                                CardPlacePoint cardPoint = CardPointController.instance.playerCardPoints[0];
                                cardPoint.IsPlayerPlace = true;
                                Debug.Log("IsPlayerPlaceTrue");
                                //AttackLeft.enabled = true;
                                //AttackRight.enabled = true;
                                //AttackTop.enabled = true;
                                //AttackDown.enabled = true;


                                // CardPlacePoint.instance.isPlayerPoint = false;
                                selectedPoint.activeCard = this;
                                assignedPlace = selectedPoint;

                                //if enemy place a card It will be true and player will not place the card.
                                // selectedPoint.isEnemyPlace = true;
                                MovetoPoint(selectedPoint.transform.position, Quaternion.identity);
                                inHand = false;

                                isSelected = false;

                                theHC.RemoveCardFromHand(this);

                                BattleController.instance.SpendPlayerMana(manaCost);
                                //Counting a card that you place on Board.
                                BattleController.instance.CardPlacePerTurn++;
                                //BattleController.instance.DamageEnemy(PlayerAttackPower);
 
                            }

                            }


                            else
                            {
                                ReturnToHand();

                                UIController.instance.ShowManaWarning();
                            }
                        
                    }

                    else
                    {
                        ReturnToHand();
                    }

                }
                else
                {
                    ReturnToHand();
                }
            }
        } 

        justPressed = false;

    }

    public void MovetoPoint(Vector3 pointToMoveTo, Quaternion rotToMatch)
    {
        targetPoint = pointToMoveTo;
        targetRot = rotToMatch;
    }

  /* private void OnMouseDown()
    {
        if (inHand && IsPlayer)
        {
            // check if time since last click is within the time limit for double click
            if (Time.time - lastClickTime < doubleClickTimeLimit)
            {
                MovetoPoint(theHC.cardPosition[handPosition] + new Vector3(5f, 0f, 0f), Quaternion.identity);
                // double click detected
                transform.localScale = new Vector3(1.7f, 1.7f, 1.2f);
            }

            // update last click time
            lastClickTime = Time.time;
      
        }
   }*/

    private void OnMouseExit()
    {
        if (inHand && IsPlayer)
        {
            onRead = false;
            OnreadFalse();
           // Invoke("OnreadFalse", 1);
          //  MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);
        }
    }

    // READ A CARD

    private void OnMouseOver()
    {
        if (inHand && IsPlayer)
        {
            onRead = true;
            //On Read Delay Before return to the Point
            if (onRead)
            {

                MovetoPoint(theHC.cardPosition[handPosition] + new Vector3(0.2f, 0f, 0f), Quaternion.identity);
             //   Invoke("OnreadFalse", 2);
            }
            else
            {

            }
  
        }
    }
    private IEnumerator DelayCardDeath()
    {
        yield return new WaitForSeconds(TimeBeforeDead);

        isSelected = false;

        //When Player Card Death Use Mana per Turn will be - Card Cost //ต้องเป็นการ์ดผู้เล่นเท่านั้น
        if(IsPlayer)
        {
            BattleController.instance.PlayerManaUsed -= manaCost;
        }
        else
        {
            BattleController.instance.EnemyManaUsed -= manaCost;
        }
        IsPlayer = false;

        MovetoPoint(BattleController.instance.discardPoint.position, BattleController.instance.discardPoint.rotation);
    }

    private void cardDeath()
    {
        StartCoroutine(DelayCardDeath());
    }


    private void OnreadFalse()
    {
        if(onRead == false)
        {
            MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);
        }


    }

    private void OnMouseDown()
    {
        if (inHand && BattleController.instance.currentPhase == BattleController.TurnOrder.playerActive && IsPlayer)
        {
            // check if time since last click is within the time limit for double click
            if (Time.time - lastClickTime < doubleClickTimeLimit)
            {
                MovetoPoint(theHC.cardPosition[handPosition] + new Vector3(10f, 0f, 0f), Quaternion.identity);
                // double click detected
                transform.localScale = new Vector3(1.7f, 1.7f, 1.2f);

                Debug.Log("Card Big");
                isSelected = false;
                theCol.enabled = true;
                justPressed = false;
            }
            else
            {
              isSelected = true;
              theCol.enabled = false;
              justPressed = true;
            }

            // update last click time
            lastClickTime = Time.time;
        }
    }

    public void ReturnToHand()
    {
        isSelected = false;
        theCol.enabled = true;

        MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);

    }

    public void DamageCardLeft(int damageAmountLeft)
    {
        if (currentHealthLeft >= damageAmountLeft)
        {

        }
        else
        {
            currentHealthLeft -= damageAmountLeft;
            if (currentHealthLeft <= 0)
            {
                currentHealthLeft = 0;

                assignedPlace.activeCard = null;
                CardDeath = true;

                if (CardDeath)
                {
                    anim.SetTrigger("Jump");
                    cardDeath();
     
                }

            }
        }
        anim.SetTrigger("Hurt");


    }

    public void DamageCardRight(int damageAmountRight)
    {
        if( currentHealthRight >= damageAmountRight)
        {

        }
        else
        {
            currentHealthRight -= damageAmountRight;
            if (currentHealthRight <= 0)
            {
                currentHealthRight = 0;

                assignedPlace.activeCard = null;
                CardDeath = true;

                if (CardDeath)
                {
                    anim.SetTrigger("Jump");
                    cardDeath();

                }
            }
        }
        anim.SetTrigger("Hurt");
    }

    public void DamageCardTop(int damageAmountTop)
    {
        if (currentHealthTop >= damageAmountTop)
        {

        }
        else
        {
            currentHealthTop -= damageAmountTop;
            if (currentHealthTop <= 0)
            {
                currentHealthTop = 0;

                assignedPlace.activeCard = null;
                CardDeath = true;

                if (CardDeath)
                {
                    anim.SetTrigger("Jump");
                    cardDeath();

                }
            }
        }
        anim.SetTrigger("Hurt");
    }

    public void DamageCardDown(int damageAmountDown)
    {
        if (currentHealthDown >= damageAmountDown)
        {

        }
        else
        {
            currentHealthDown -= damageAmountDown;
            if (currentHealthDown <= 0)
            {
                currentHealthDown = 0;

                assignedPlace.activeCard = null;
                CardDeath = true;

                if (CardDeath)
                {
                    anim.SetTrigger("Jump");
                    cardDeath();

                }
            }
        }
        anim.SetTrigger("Hurt");

    }

}

