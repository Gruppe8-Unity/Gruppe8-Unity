using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using System.Collections.Generic;
using System.Linq;

public class UIScript : MonoBehaviour
{
    public Player player;
    private float scoreCount = 0f;
    private float experienceCount = 0f;
    private float requiredExperience= 10f;
    private int levelCount = 1;

    public Grid[] grids;
    public int currentGrid = 0;
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerExperience;
    public TextMeshProUGUI playerCurrentLevel;
    public Image experienceBar;
    public Image healthBar;


    
    private void Start()
    {
        SwitchBackground();
        UpdateExperience(0);
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    private void Update()
    {
        UpdateHealthBar();
        UpdateScore();
    }
    
    private void UpdateHealthBar()
    {
        healthBar.fillAmount = Mathf.Clamp(player.currentPlayerHealth / player.maxPlayerHealth, 0, 1);
    }
   public void UpdateScore()
   {
       scoreCount += 1.0f * 0.01f; 
        playerScore.text = $"Score: {Mathf.Round(scoreCount)}"; 
    }
    
    public void UpdateExperience(float amount)
    {  
        experienceCount += amount;
        if (experienceCount >= requiredExperience)
        {
            experienceCount = 0;
            levelCount++;
            requiredExperience *= 1.2f;
            SwitchBackground();
            FindObjectOfType<AudioManager>().Play("LevelUp");
        }
        
        experienceBar.fillAmount = Mathf.Clamp( experienceCount / requiredExperience , 0, requiredExperience);

        playerExperience.text = $"{Mathf.Round(experienceCount)} / {Mathf.Round(requiredExperience)}";
        playerCurrentLevel.text = $"Level: {Mathf.Round(levelCount)}";
        if(levelCount == 15)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void SwitchBackground()
    {
        grids = FindObjectsOfType<Grid>();
        foreach (Grid grid in grids)
        {
            foreach(TilemapRenderer renderer in grid.GetComponentsInChildren<TilemapRenderer>())
            {
                renderer.enabled = false;
            }
        }

        int randomIndex = Random.Range(0, grids.Length);
        if (currentGrid == grids.Length - 1)
        {
            currentGrid = 0;
        }
        else
        {
            currentGrid++;
        }
        //while(randomIndex == currentGrid)
        //{
        //    randomIndex = Random.Range(0, grids.Length);
        //}
        //currentGrid = randomIndex;
        foreach (TilemapRenderer renderer in grids[currentGrid].GetComponentsInChildren<TilemapRenderer>())
        {
            renderer.enabled = true;
        }
    }
}
