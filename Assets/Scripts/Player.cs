using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Player : UIScript
{
    public float movementSpeed = 10.0f;
    public Transform playerTransform;
    public Animator playerAnimator;
    public Transform firepoint;
    public float currentPlayerHealth;
    public float maxPlayerHealth = 100;
    private float damageInterval = 1.0f;
    private float lastDamageTime;

    private void Start()
    {
        // Get transform of associated gameobject
        playerTransform = GetComponent<Transform>();
        currentPlayerHealth = maxPlayerHealth;
    }

    void Update()
    {
        float verticalMovement = 0.0f;
        float horizontalMovement = 0.0f;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            verticalMovement = 1.0f;

        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            verticalMovement = -1.0f;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            horizontalMovement = 1.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            horizontalMovement = -1.0f;
        }

        // Scaled movement in x and y directions
        float movementX = movementSpeed * horizontalMovement * Time.deltaTime;
        float movementY = movementSpeed * verticalMovement * Time.deltaTime;

        // Set animator params
        playerAnimator.SetFloat("DirectionY", verticalMovement);
        playerAnimator.SetFloat("DirectionX", horizontalMovement);

        // Stores the size (speed) of the vector
        float vectorMagnitude = Mathf.Sqrt(Mathf.Pow(horizontalMovement, 2) + Mathf.Pow(verticalMovement, 2));
        playerAnimator.SetFloat("MovementSpeed", vectorMagnitude);

        Vector2 movementDirection = new Vector2(movementX, movementY);
        playerTransform.Translate(movementDirection);
        
        if (horizontalMovement != 0.0f || verticalMovement != 0.0f)
        {
            float angle = Mathf.Atan2(verticalMovement, horizontalMovement) * Mathf.Rad2Deg;
            firepoint.rotation = Quaternion.Euler(0, 0, angle);
        }

        horizontalMovement = 0.0f;
        verticalMovement = 0.0f;
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            if (Time.time > lastDamageTime + damageInterval)
            {
                TakeDamage(1);
                lastDamageTime = Time.time;
            }
        }
        if (collision.gameObject.tag == "SmallExp")
        {
            UpdateExperience(2.0f);
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("ExpSound");
            
        }
    }
    public void TakeDamage(int damage)
    {
        if(currentPlayerHealth <= 0f)
        {
            FindObjectOfType<AudioManager>().Play("PlayerDeathSound");
            StartCoroutine(PlayerDeathWithDelay(0.6f)); 
            
        }
        currentPlayerHealth -= damage;
        FindObjectOfType<AudioManager>().Play("PlayerHitSound");
    }
    
    
    IEnumerator PlayerDeathWithDelay(float delayInSeconds)
    {
        yield return StartCoroutine(ShortDelay(delayInSeconds));
        SceneManager.LoadScene("DeathScene");
    }
    
    IEnumerator ShortDelay(float delayInSeconds)
    {
        float timer = 0f;
        float targetTime = delayInSeconds;

        while (timer < targetTime)
        {
            timer += Time.unscaledDeltaTime; 
            yield return null;
        }
    }
}
