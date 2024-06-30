using UnityEngine;

public class OutOfBoundsZone : MonoBehaviour


{
    [SerializeField] private BarrierBehaviour BB;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.ReturnObjectToPool(collision.gameObject);
    }
}
