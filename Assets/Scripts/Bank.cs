using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;
using TMPro;

public class Bank : MonoBehaviour
{
    Timer t = new Timer();
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    [SerializeField] TextMeshProUGUI displayBalance;

    Scene currentScene;

    //private void Update()
    //{
    //    t.Elapsed += new ElapsedEventHandler(onTimer);
    //    t.Interval = 500;
        
    //}

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
    //void onTimer(object source, ElapsedEventArgs e)
    //{
    //    if (currentBalance < 0)
    //    {
    //        ReloadScene();
    //    }
    //}
}
