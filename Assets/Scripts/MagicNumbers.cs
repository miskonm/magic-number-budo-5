using UnityEngine;

public class MagicNumbers : MonoBehaviour
{
    #region Variables

    public int Max = 1000;
    public int Min = 1;
    private int _guess;

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        Debug.Log($"Привет! Загадай число от {Min} до {Max}");
        CalculateGuess();
        AskAboutGuess();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Max = _guess;
            CalculateGuess();
            AskAboutGuess();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Min = _guess;
            CalculateGuess();
            AskAboutGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log($"Поздравляю! Я угадал! Твое число {_guess}");
        }
    }

    #endregion

    #region Private methods

    private void AskAboutGuess()
    {
        Debug.Log($"Твое число {_guess}?");
    }

    private void CalculateGuess()
    {
        _guess = (Min + Max) / 2;
    }

    #endregion
}