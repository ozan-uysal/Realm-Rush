using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Timers;

public class Bank : MonoBehaviour
{
    Timer t = new Timer();
    [SerializeField] int startingBalance = 150;
    [SerializeField] int currentBalance;

    Scene currentScene;
    


    private void Update()
    {
        t.Elapsed += new ElapsedEventHandler(onTimer);
        t.Interval = 500;
        
    }

    public int CurrentBalance { get { return currentBalance;} }

    void Awake()
    {
        currentBalance = startingBalance;
    }

    public void Deposit(int amount)
    {
        currentBalance +=Mathf.Abs(amount);
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
       
        //if (currentBalance < 0)
        //{
            
        //}
    }
    void ReloadScene()
    {
            currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        t.Start();
    }
   
    void onTimer(object source, ElapsedEventArgs e)
    {
        if (currentBalance < 0)
        {
            ReloadScene();
        }
       
        
    }
}
