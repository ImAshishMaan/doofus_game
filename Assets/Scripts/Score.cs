using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    private movement ms;
    public Text scoreText;

    private void Start()
    {
        ms = player.GetComponent<movement>();
    }
    private void Update()
    {
        Debug.Log(ms.ScoreUpdate());
        scoreText.text = ms.ScoreUpdate().ToString();
    }
}
