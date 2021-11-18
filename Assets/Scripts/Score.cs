using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public GameObject player;
    private Movement ms;
    public Text scoreText;

    private void Start()
    {
        ms = player.GetComponent<Movement>();
    }
    private void Update()
    {
        //Debug.Log(ms.ScoreUpdate());
        scoreText.text = ms.ScoreUpdate().ToString();
    }
}
