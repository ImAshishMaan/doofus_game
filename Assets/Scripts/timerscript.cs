using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Collections;

public class timerscript : MonoBehaviour
{
    jsonController jc;
    public GameObject jsonObject;
    float maxDestroyTime = 5f;
    float spawnTime = 2f;
 
    bool newGroundInstanciated;
    readonly List<Vector3> pos = new List<Vector3>() { new Vector3(9, 0, 0), new Vector3(-9, 0, 0), new Vector3(0, 0, 9), new Vector3(0, 0, -9) } ;

    private void Awake()
    {
        jc = jsonObject.GetComponent<jsonController>();
        newGroundInstanciated = false;
        StartCoroutine(Wait());
    }
    private IEnumerator Wait()
    {
        Debug.Log("Waiting for the json data loading");
        yield return new WaitUntil(() => jc.isJsonLoaded == true);
        Debug.Log("Done");

        maxDestroyTime = jc.getMaxDestroyTime();
        spawnTime = jc.getSpawnTime();

        Debug.Log("Max destroy time : " + maxDestroyTime);
        Debug.Log("Spawn time : " + spawnTime);
    }
    private void Update()
    {
        maxDestroyTime -= 1 * Time.deltaTime;
        gameObject.transform.Find("Canvas").Find("Timer").GetComponent<TMP_Text>().text = maxDestroyTime.ToString().Substring(0,4);

        if (!newGroundInstanciated && maxDestroyTime < spawnTime)
        {
            newGroundInstanciated = true;

            int index = Random.Range(0, pos.Capacity);
            Vector3 newpos = new Vector3(gameObject.transform.position.x + pos[index].x, 0, gameObject.transform.position.z + pos[index].z);
            Instantiate(gameObject, newpos, Quaternion.identity);
        }
 
        if (maxDestroyTime <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}