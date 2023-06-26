using UnityEngine;

namespace DefaultNamespace
{
    public class BlackMagicNumbers : MonoBehaviour
    {
        #region Variables

        public int SumForWin = 50;
        private bool _isPlaying;
        private int _stepCount;

        private readonly KeyCode[] _keysToCheck =
        {
            KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3, KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
            KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9,
        };

        private int _sum;

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
                TryRestart();

                return;
            }

            CheckUserInput();
            CheckGameEnd();
        }

        #endregion

        #region Private methods

        private void CheckGameEnd()
        {
            if (_sum >= SumForWin)
            {
                Debug.Log($"Игра окончена. Сумма равна {_sum}. Ходов потрачено {_stepCount}. Нажми пробел для рестарта.");
                _isPlaying = false;
            }
        }

        private void CheckUserInput()
        {
            for (int i = 0; i < _keysToCheck.Length; i++)
            {
                if (Input.GetKeyDown(_keysToCheck[i]))
                {
                    Increment(i + 1);
                }
            }
        }

        private void Increment(int amount)
        {
            _sum += amount;
            _stepCount++;
            Debug.Log($"Ты нажал {amount}. Сумма равна {_sum}");
        }

        private void InitializeGame()
        {
            Debug.Log("Нажмите цифру:");
            _isPlaying = true;
            _sum = 0;
            _stepCount = 0;
        }

        private void TryRestart()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                InitializeGame();
            }
        }

        #endregion
    }
}