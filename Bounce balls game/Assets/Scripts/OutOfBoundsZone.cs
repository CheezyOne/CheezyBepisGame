using System;
using UnityEngine;

public class OutOfBoundsZone : MonoBehaviour
{
    [SerializeField] private BarrierBehaviour BB;
    public static Action<int> onLoseLoot;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Loot>(out Loot lootComponent))
            if (lootComponent.LootPoints > 0)
                onLoseLoot?.Invoke(lootComponent.LootPoints);
        PoolManager.ReturnObjectToPool(collision.gameObject);
    }
}
