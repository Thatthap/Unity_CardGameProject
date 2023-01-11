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
    public int currentHealthLeft , currentHealthRight , currentHealthTop , currentHealthDown;
    
    public int attackPowerLeft , attackPowerRight , attackPowerTop , attackPowerDown;

    public int manaCost;
    // Get a Text from card
    public TMP_Text AttackLeft, AttackRight, AttackTop, AttackDown, HealthLeft, HealthRight, HealthTop, HealthDown , NameText , ActionDescriptionText , LoreText ;

    public Image CardArt;

    private Vector3 targetPoint;

    public float moveSpeed = 5f , rotateSpeed = 540f;

    private Quaternion targetRot;

    public bool inHand;
    public int handPosition;

    public bool onRead;

    private HandController theHC;

    private bool isSelected;
    private Collider theCol;

    public LayerMask whatIsDesktop , whatIsPlacment;
    private bool justPressed;

    public CardPlacePoint assignedPlace;

     
    // Start is called before the first frame update
    void Start()
    {
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

        CardArt.sprite = cardSO.CardSprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotateSpeed * Time.deltaTime);

        //SELECTED A CARD
        if (isSelected)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, whatIsDesktop))
            {
                MovetoPoint(hit.point , Quaternion.identity);
            }


            if (Input.GetMouseButtonDown(1))
            {
                ReturnToHand();
            }


            if (Input.GetMouseButtonDown(0) && justPressed == false)
            {
                if (Physics.Raycast(ray, out hit, 100f, whatIsPlacment))
                {

                    CardPlacePoint selectedPoint = hit.collider.GetComponent<CardPlacePoint>();

                    if(selectedPoint.activeCard == null && selectedPoint.isPlayerPoint)
                    {
                        selectedPoint.activeCard = this;
                        assignedPlace = selectedPoint;

                        MovetoPoint(selectedPoint.transform.position, Quaternion.identity);
                        inHand = false;

                        isSelected = false;

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

   /* private void OnMouseOver()
    {
        if (inHand)
        {
            MovetoPoint(theHC.cardPosition[handPosition] + new Vector3(3f, 5f, .5f), Quaternion.identity);
        }
   }*/

/*    private void OnMouseExit()
    {
        if (inHand)
        {
            MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);
        }
    }*/

    // READ A CARD

    private void OnMouseOver()
    {
        if (inHand)
        {
            onRead = true;
            //On Read Delay Before return to the Point
            if (onRead)
            {
                MovetoPoint(theHC.cardPosition[handPosition] + new Vector3(0f, 1.2f, 1f), Quaternion.identity);
                Invoke("OnreadFalse", 1);
            }
            else
            {
              //  MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);
            }
  
        }
    }

    private void OnreadFalse()
    {
            onRead = false;
        MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);
    }

    private void OnMouseDown()
    {
        if (inHand)
        {
            isSelected = true;
            theCol.enabled = false;

            justPressed = true;
        }
    }

    public void ReturnToHand()
    {
        isSelected = false;
        theCol.enabled = true;

        MovetoPoint(theHC.cardPosition[handPosition], theHC.minPos.rotation);
    }

}

