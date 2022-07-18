using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int time = 30;
    public int difficulty = 1;
   [SerializeField] int score;
    public bool gameOver=false;
    Player player;

    public int Score
    {
        get => score;
        set
        {
            score = value;
            UIManager.Instance.UpdateUIScore(score);
            if(score % 100 == 0)
            {
                difficulty++;
            }
        }
    }
    private void Awake()
    {
        if (Instance==null)
        {
            Instance = this;
        }    
    }
    private void Start()
    {
        StartCoroutine(CountRoutine());
    }
    IEnumerator CountRoutine()
    {
        while (time>0)
        {
            yield return new WaitForSeconds(1);
            time--;
        }
        gameOver = true;
        Destroy(player);
        UIManager.Instance.ShowGameOverScreen();
        
    }

    public void PlayAgain()
    {
        
        
        SceneManager.LoadScene("Game");
    }
    public void Quit()
    {
        Application.Quit();
    }

}
