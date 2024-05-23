using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject arrowPrefab;
    public float arrowTimer = 1;
    
    void Update()
    {
        if (arrowTimer <= 0)
        {
            ShootArrow();
            arrowTimer = 1;
        }
        arrowTimer -= Time.deltaTime;
    }
    
    void ShootArrow()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);
    }
}
