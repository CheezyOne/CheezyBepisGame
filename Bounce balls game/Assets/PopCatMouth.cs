using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopCatMouth : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Sprite est;
    public Sprite shut;
    [SerializeField] private Sprite _deadCat;
    private bool _isAlive = false;

    private void OnEnable()
    {
        PointsManager.onLose += DeadCat;
        MenuButtons.OnGameStart += GameStart;
    }
    private void OnDisable()
    {
        PointsManager.onLose -= DeadCat;
        MenuButtons.OnGameStart -= GameStart;
    }
    private void GameStart()
    {
        _isAlive = true;
        spriteRenderer.sprite = est;
    }
    private void DeadCat()
    {
        _isAlive = false;
        spriteRenderer.sprite = _deadCat;
    }
    void OnTriggerStay2D()
    {
        if (spriteRenderer && _isAlive)
        spriteRenderer.sprite = shut;
    }
    void OnTriggerExit2D()
    {
        if (spriteRenderer && _isAlive)
        spriteRenderer.sprite = est;
    }
}
