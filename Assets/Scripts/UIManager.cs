using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public float tiempo;
    [SerializeField]Text healthText;
    [SerializeField] Text scoreText;
    [SerializeField] Text timeText;
    [SerializeField]GameObject gameOverScreen;
    [SerializeField]Text finalScore;
    public int newTime;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo = GameManager.Instance.time;
        newTime = (int)tiempo;
        timeText.text = newTime.ToString();
    }
    public void UpdateUIScore(int newScore)
    {
       
        scoreText.text = newScore.ToString();
    }
    public void UpdateUIHealtth(int newHealth)
    {
        healthText.text = newHealth.ToString();
    }
    public void UpdateUITime(int newTime)
    {
       /*tiempo= GameManager.Instance.time;
        newTime = (int)tiempo;    
        timeText.text = newTime.ToString();
    */
    }
    public void ShowGameOverScreen()
    {
        gameOverScreen.SetActive(true);
        finalScore.text = "SCORE "+GameManager.Instance.Score;
        
    }
}
