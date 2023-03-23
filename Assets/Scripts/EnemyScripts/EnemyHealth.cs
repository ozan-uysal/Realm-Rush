
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public static int maxHitPoints = 5;
    public int currentHitPoints = 0;
   
    [SerializeField] int difficultyRamp = 1;

    [SerializeField] TextMeshProUGUI displayRamHp;

    Enemy enemy;
    void OnEnable()
    {
        currentHitPoints = maxHitPoints;
        Debug.Log(maxHitPoints);
    }
    void Start()
    {
        enemy = GetComponent<Enemy>();
        displayRamHp = GameObject.Find("RamHp").GetComponent<TextMeshProUGUI>();
        displayRamHp.text ="Ram Max Hp : " + maxHitPoints.ToString();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints<=0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyRamp;
            displayRamHp.text = "Ram Max Hp : " + maxHitPoints.ToString();
            enemy.RewardGold();
        }
    }
}
