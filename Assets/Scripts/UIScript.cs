using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
    public Player player;
    private float scoreCount = 0f;
    private float experienceCount = 0f;
    private float requiredExperience= 10f;
    private int levelCount = 1;
    
    public TextMeshProUGUI playerScore;
    public TextMeshProUGUI playerExperience;
    public TextMeshProUGUI playerCurrentLevel;
    public Image experienceBar;
    public Image healthBar;
    
    private void Start()
    {
        UpdateExperience(0);
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
        }
        
        experienceBar.fillAmount = Mathf.Clamp( experienceCount / requiredExperience , 0, requiredExperience);

        playerExperience.text = $"{Mathf.Round(experienceCount)} / {Mathf.Round(requiredExperience)}";
        playerCurrentLevel.text = $"Level: {Mathf.Round(levelCount)}";
        if(levelCount == 30)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }
}
