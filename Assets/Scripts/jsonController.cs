using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
public class JsonController : MonoBehaviour
{

    private static JsonController jController;
    //private JsonController() { }
    public static JsonController JController()
    {
        if(jController == null)
        {
            jController = new JsonController();
        }
        return jController;
    }  

    public string jsonURL;
    public JsonData jsnData;
    public bool isJsonLoaded;
    private void Awake()
    {
        StartCoroutine(GetJsonData(jsonURL));
    }
    IEnumerator GetJsonData(string _url)
    {
        Debug.Log("Processing Data, Please Wait");
        UnityWebRequest webRequest = UnityWebRequest.Get(_url);
        yield return webRequest.SendWebRequest();

        if (webRequest.result == UnityWebRequest.Result.ConnectionError)
        {
            //error
            Debug.Log("Something is wrong");
        }
        else
        {
            //success
            ProcessJson(webRequest.downloadHandler.text);
        }
    }
    private void ProcessJson(string _url)
    {
        Debug.Log(_url);
        jsnData = JsonUtility.FromJson<JsonData>(_url);
        Debug.Log("Controller debug:  " + jsnData.player_data.speed);
        isJsonLoaded = true;
    }
    public bool isLoaded()
    {
        return isJsonLoaded;
    }
    public int getSpeed()
    {
        return jsnData.player_data.speed;
    }
    public int getMinDestroyTime()
    {
        return jsnData.pulpit_data.min_pulpit_destroy_time;

    }
    public int getMaxDestroyTime()
    {
        return jsnData.pulpit_data.max_pulpit_destroy_time;
    }
    public float getSpawnTime()
    {
        return jsnData.pulpit_data.pulpit_spawn_time;
    }

}
