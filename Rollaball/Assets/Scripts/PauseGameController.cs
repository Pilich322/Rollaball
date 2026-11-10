using UnityEngine;

public class PauseGameController : MonoBehaviour
{
    private bool isPause = false;        // переменная для управления состоянием паузы
    public void PauseOrResume()
    {
        if (isPause)
        {
            Time.timeScale = 1f;         // Возвращаем нормальную скорость времени
            isPause = !isPause;
        }
        else
        {
            Time.timeScale = 0f;          // Останавливаем игровое время
            isPause = !isPause;
        }
    }
}