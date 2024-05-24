using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowTimer = 1;
    
    void Update()
    {
        DetermineShootArrow();
        DecrementArrowTimer();
    }

    void DecrementArrowTimer()
    {
        arrowTimer -= Time.deltaTime;
    }

    void DetermineShootArrow()
    {
        if (arrowTimer <= 0)
        {
            Shoot();
            arrowTimer = 1;
        }
    }
    
    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
        FindObjectOfType<AudioManager>().Play("ArrowSound");
    }
}
