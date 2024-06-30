using UnityEngine;

public class Loot : MonoBehaviour
{
    public int LootPoints;
    private void OnEnable()
    {
        PointsManager.onLose += GetBackToPool;
    }
    private void OnDisable()
    {
        PointsManager.onLose -= GetBackToPool;
    }
    private void GetBackToPool()
    {
        PoolManager.ReturnObjectToPool(gameObject);
    }
}
