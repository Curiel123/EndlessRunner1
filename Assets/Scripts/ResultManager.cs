using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Runtime.CompilerServices;

public class ResultManager : MonoBehaviour
{
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pointsText;
    private StatManager stats;
    private int protectedIndex;


    void Start()
    {
        stats = FindObjectOfType<StatManager>();

        if (stats != null)
        {
            Debug.Log("Success!");
            distanceText.text = Mathf.Floor(stats.distanceTraveled) + " m";
            if (stats.timeElapsed > 60)
            {
                timeText.text = Mathf.Floor(stats.timeElapsed / 60) + ":" + Mathf.Floor(stats.timeElapsed % 60);
            }
            else
            {
				timeText.text = "00:" + Mathf.Floor(stats.timeElapsed );
			}
            pointsText.text = stats.points.ToString();
        }
        if(stats == null)
        {
            Debug.LogError("StatManager missing");
        }
    }


    public void LoadScene(string SceneName)
    {
        if(SceneName == "KILLAPP")
        {  
            Application.Quit();
            #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            #endif
            return;
        }

        SceneManager.LoadScene(SceneName);
        protectedIndex = SceneManager.GetSceneByName(SceneName).buildIndex;
        foreach(Scene i in SceneManager.GetAllScenes())
        {
            SceneManager.UnloadScene(i);
        }
    }
}
