using System;
using UnityEngine;

public class LootGetter : MonoBehaviour
{
    public static Action<int> OnLootGet;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Loot>(out Loot loot))
            OnLootGet?.Invoke(loot.LootPoints);
        PoolManager.ReturnObjectToPool(collision.gameObject);
    }
}
