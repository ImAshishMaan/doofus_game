using UnityEngine;
using UnityEngine.SceneManagement;
public class retry : MonoBehaviour
{
    public void RetryButton()
    {
        SceneManager.LoadScene(0);
    }
}
