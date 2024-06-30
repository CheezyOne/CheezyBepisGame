using System;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _textMeshPro;
    public static Action onLose;
    private bool _isGameOver = true;
    private int _lootPoints = 0;

    [SerializeField] private AudioSource audioSource;
    private void OnEnable()
    {
        LootGetter.OnLootGet += GetLoot;
        MenuButtons.OnGameStart += GameStart;
        OutOfBoundsZone.onLoseLoot += LoseLoot;
    }
    private void OnDisable()
    {
        LootGetter.OnLootGet -= GetLoot;
        MenuButtons.OnGameStart -= GameStart;
        OutOfBoundsZone.onLoseLoot -= LoseLoot;
    }
    private void GameStart()
    {
        _isGameOver = false;
        _textMeshPro.text = "0";
        _lootPoints = 0;
    }
    private void LoseLoot(int lootPoints)
    {
        _lootPoints -= lootPoints;
        if(_lootPoints < 0)
            _lootPoints= 0;
        SetLootPointsText();
    }
    private void GetLoot(int lootPoints)
    {
        audioSource.Play();
        if (_isGameOver)
            return;
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
        _isGameOver = true;
        onLose?.Invoke();
    }
}
