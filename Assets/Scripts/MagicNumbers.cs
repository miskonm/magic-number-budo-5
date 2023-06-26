using TMPro;
using UnityEngine;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public int Max = 1000;
    public int Min = 1;

    public TMP_Text TextLabel;

    private int _currentMax;
    private int _currentMin;
    private int _guess;
    private bool _isPlaying;
    private int _stepCount;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        InitializeGame();
    }

    private void Update()
    {
        if (!_isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InitializeGame();
            }

            return;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _currentMax = _guess;
            CalculateGuessAndAsk();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _currentMin = _guess;
            CalculateGuessAndAsk();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            SetText($"Поздравляю! Я угадал! Твое число {_guess}, потрачено шагов {_stepCount}. Нажми пробел " +
                    "для рестарта.");

            _isPlaying = false;
        }
    }

    #endregion

    #region Private methods

    private void AskAboutGuess()
    {
        SetText($"Твое число {_guess}?");
    }

    private void CalculateGuess()
    {
        _guess = (_currentMin + _currentMax) / 2;
    }

    private void CalculateGuessAndAsk()
    {
        _stepCount++;
        CalculateGuess();
        AskAboutGuess();
    }

    private void InitializeGame()
    {
        _currentMin = Min;
        _currentMax = Max;
        SetText($"Привет! Загадай число от {_currentMin} до {_currentMax}");
        CalculateGuess();
        AskAboutGuess();
        _isPlaying = true;
    }

    private void SetText(string text)
    {
        TextLabel.text = text;
    }

    #endregion
}