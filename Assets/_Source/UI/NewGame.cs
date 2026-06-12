using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Source.UI
{
    public class NewGame : MonoBehaviour
    {
        public void ReloadCurrentScene()
        {
            // Получаем индекс текущей открытой сцены
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Загружаем сцену заново по её индексу
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}
