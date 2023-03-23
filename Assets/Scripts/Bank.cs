using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;
using TMPro;

public class Bank : MonoBehaviour
{

    [SerializeField] int startingBalance = 150;
    private int currentBalance;

    [SerializeField] TextMeshProUGUI displayBalance;

    Scene currentScene;
    public int CurrentBalance { get { return currentBalance;} }

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplay();
    }
    public void Deposit(int amount)
    {
        currentBalance +=Mathf.Abs(amount);
        UpdateDisplay();
    }
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }
    void UpdateDisplay()
    {
        displayBalance.text = "Gold : " + currentBalance;  
    }
    public void ReloadScene()
    {
            currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
    }
   
}
