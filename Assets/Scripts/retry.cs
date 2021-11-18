using UnityEngine;
using UnityEngine.SceneManagement;
public class Retry : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
