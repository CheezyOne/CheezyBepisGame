using UnityEngine;

public class OutOfBoundsZone : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.ReturnObjectToPool(collision.gameObject);
    }
}
