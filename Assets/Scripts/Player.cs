using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
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
    private float horizontalMovement;
    private float verticalMovement;

    private void Start()
    {
        // Get transform of associated gameobject
        playerTransform = GetComponent<Transform>();
        currentPlayerHealth = maxPlayerHealth;
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        ResetXY();
        CheckUserInputDirecton();

        // Scaled movement in x and y directions
        float movementX = ScaleCoordinate(horizontalMovement);
        float movementY = ScaleCoordinate(verticalMovement);

        SetAnimationParamters();
        
        Vector2 movementDirection = new Vector2(movementX, movementY);
        MovePlayer(movementDirection);
        
        DetermineProjectileDirection();
        ResetXY();
    }

    void MovePlayer(Vector2 direction)
    {
        playerTransform.Translate(direction);
    }

    void SetAnimationParamters()
    {
        // Set animator params
        playerAnimator.SetFloat("DirectionY", verticalMovement);
        playerAnimator.SetFloat("DirectionX", horizontalMovement);

        // Stores the size (speed) of the vector
        float vectorMagnitude = Calculate2DVectorMagnitude(horizontalMovement, verticalMovement);
        playerAnimator.SetFloat("MovementSpeed", vectorMagnitude);
    }

    float ScaleCoordinate(float coordinate)
    {
        return movementSpeed * coordinate * Time.deltaTime;
    }

    void CheckUserInputDirecton()
    {
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
    }

    void ResetXY()
    {
        horizontalMovement = 0.0f;
        verticalMovement = 0.0f;
    }
    void DetermineProjectileDirection()
    {
        if (horizontalMovement != 0.0f || verticalMovement != 0.0f)
        {
            float angle = Mathf.Atan2(verticalMovement, horizontalMovement) * Mathf.Rad2Deg;
            firepoint.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    float Calculate2DVectorMagnitude(float x, float y)
    {
        return Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(y, 2));
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
