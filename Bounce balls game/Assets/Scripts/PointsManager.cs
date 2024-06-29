using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMeshPro;
    private int _lootPoints = 0;
    private void OnEnable()
    {
        LootGetter.OnLootGet += GetLoot;
    }
    private void OnDisable()
    {
        LootGetter.OnLootGet -= GetLoot;
    }
    private void GetLoot(int lootPoints)
    {
        if (lootPoints > 0)
        {
            _lootPoints += lootPoints;
            SetLootPointsText();
        }
        else
            GotBadLoot();
    }
    private void SetLootPointsText()
    {
        _textMeshPro.text = _lootPoints.ToString();
    }
    private void GotBadLoot()
    {
        //mb redacted so that we have more than 1 life
        Lose();
    }
    private void Lose()
    {
        Debug.Log("You lost");
    }
}
