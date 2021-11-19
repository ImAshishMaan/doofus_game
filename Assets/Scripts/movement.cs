using System.Collections;
using UnityEngine;
public class Movement : MonoBehaviour {
    public float speed;
    JsonController jc = new JsonController();
    public GameObject jsonObject;
    public GameObject GameOverUI;

    int score = 0;
    private void Awake() {
        jc = jsonObject.GetComponent<JsonController>();
        StartCoroutine(Wait());
    }

    private IEnumerator Wait() {
        Debug.Log("Waiting for the json data loading");
        yield return new WaitUntil(() => jc.isJsonLoaded == true);
        Debug.Log("Done");
        Debug.Log("JSON LOADED " + jc.isJsonLoaded);
        speed = jc.getSpeed();
    }
    private void Update() {
        MovePlayer();
        GameOver();
    }
    private void MovePlayer() {
        float xValue = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float zValue = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.Translate(xValue, 0, zValue);
    }

    private void GameOver() {
        if (transform.position.y < -1) {
            Debug.Log("Game Over");
            GameOverUI.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        score++;
    }

    public int ScoreUpdate() {
        return score;
    }
}
