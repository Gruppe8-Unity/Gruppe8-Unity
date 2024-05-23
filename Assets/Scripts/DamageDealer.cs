using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage;
    void Update()
    {
        damage++;
    }
    public int DealDamage(int damage)
    {
        return damage;
    }
}
