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
        EscapeToMainMenu();
        UpdateHealthBar();
        UpdateScore();
    }

    void EscapeToMainMenu()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("StartMenu");
        }
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
        IncreaseExperience(amount);
        CheckIfLevelSwap();
        FillExperienceBar();
        UpdateExperienceText();
        UpdatePlayerLevel();
        CheckWinCondition();
    }

    void IncreaseExperience(float amount)
    {
        experienceCount += amount;
    }

    void CheckIfLevelSwap()
    {
        if (experienceCount >= requiredExperience)
        {
            experienceCount = 0;
            levelCount++;
            requiredExperience *= 1.2f;
            SwitchBackground();
            FindObjectOfType<AudioManager>().Play("LevelUp");
        }
    }

    void UpdatePlayerLevel()
    {
        playerCurrentLevel.text = $"Level: {Mathf.Round(levelCount)}";
    }

    void UpdateExperienceText()
    {
        playerExperience.text = $"{Mathf.Round(experienceCount)} / {Mathf.Round(requiredExperience)}";
    }

    void FillExperienceBar()
    {
        experienceBar.fillAmount = Mathf.Clamp( experienceCount / requiredExperience , 0, requiredExperience);
    }
    void CheckWinCondition()
    {
        //Unity will not compare variable to levelCount, have to use constant. 
        if(levelCount == 15)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
    public void SwitchBackground()
    {
        grids = FindObjectsOfType<Grid>();
        DisableTileMaps();
        EnableTileMap();
    }

    void EnableTileMap()
    {
        int randomIndex = Random.Range(0, grids.Length);
        if (currentGrid == grids.Length - 1)
        {
            currentGrid = 0;
        }
        else
        {
            currentGrid++;
        }
        
        foreach (TilemapRenderer renderer in grids[currentGrid].GetComponentsInChildren<TilemapRenderer>())
        {
            renderer.enabled = true;
        }
    }

    void DisableTileMaps()
    {
        foreach (Grid grid in grids)
        {
            foreach(TilemapRenderer renderer in grid.GetComponentsInChildren<TilemapRenderer>())
            {
                renderer.enabled = false;
            }
        }
    }
}
