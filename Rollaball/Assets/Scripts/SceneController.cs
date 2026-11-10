using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}