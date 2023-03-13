using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{

    public static UIController instance;

    private void Awake()
    {
        instance = this; 
    }

    public TMP_Text playerManaText,PlayerLeaderHealthText,TurnReaderText,EnemyManaText,EnemyLeaderHealthText;


    public GameObject manaWarning;
    public float manaWarningTime;
    private float ManaWarningCounter;
    public GameObject drawCardButton, endTurnButton ;
    public UIDamageIndicator playerDamage, enemyDamage;


    public GameObject BattleEndedScreen;
    public TMP_Text battleResultText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ManaWarningCounter > 0)
        {
            ManaWarningCounter -= Time.deltaTime;

            if(ManaWarningCounter <= 0)
            {
                manaWarning.SetActive(false);
            }
        }
    }

    public void SetEnemyManaText(int ManaAmount)
    {
        EnemyManaText.text = "" + ManaAmount;
    }

    public void SetPlayerManaText(int ManaAmount)
    {
        playerManaText.text = "" + ManaAmount;
    }

    public void SetPlayerLeaderHealth(int healthAmount)
    {
        PlayerLeaderHealthText.text = "" + healthAmount;

    }

    public void SetEnemyLeaderHealth(int healthAmount)
    {
        EnemyLeaderHealthText.text = "" + healthAmount;
    }

    public void ShowManaWarning()
    {
        manaWarning.SetActive(true);
        ManaWarningCounter = manaWarningTime;
    }

    public void DrawCard()
    {
        DeckController.instance.DrawCardForEndTurn();
    }

    public void EndPlayerTurn()
    {
        BattleController.instance.EndPlayerTurn();
    }

    public void MainMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void RestartLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void NewBattle(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("EXIT GAME");
    }
} 
