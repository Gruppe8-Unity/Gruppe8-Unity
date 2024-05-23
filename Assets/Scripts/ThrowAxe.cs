using UnityEngine;

public class ThrowAxe : MonoBehaviour
{
    public Transform axeThrowPoint;
    public GameObject axePrefab;
    public float axeTimer = 1;
    void Update()
    {
        DetermineThrow();
    }

    void DetermineThrow()
    {
        if (axeTimer <= 0)
        {
            Throw();
            axeTimer= 1;
        }
        axeTimer-= Time.deltaTime;
    }
    public void Throw()
    { 
        Instantiate(axePrefab, axeThrowPoint.position, axeThrowPoint.rotation);
        FindObjectOfType<AudioManager>().Play("AxeSound");
    }
}
