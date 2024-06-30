using System;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public static Action OnGameStart;
    [SerializeField] private GameObject MenuCanvas, GameCanvas, GameOverCanvas;
    private void OnEnable()
    {
        PointsManager.onLose += GameLose;
    }
    private void OnDisable()
    {
        PointsManager.onLose -= GameLose;
    }
    private void GameLose()
    {
        GameOverCanvas.SetActive(true);
    }
    public void GameStart()
    {
        OnGameStart?.Invoke();
        GameCanvas.SetActive(true);
        MenuCanvas.SetActive(false);
    }
    public void RestartGame()
    {
        OnGameStart?.Invoke();
        GameOverCanvas.SetActive(false);    
    }
}
