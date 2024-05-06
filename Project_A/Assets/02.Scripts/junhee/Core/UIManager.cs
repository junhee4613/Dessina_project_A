using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager
{
    public Slider air_gauge;
    public Dictionary<string, GameObject> window = new Dictionary<string, GameObject>();
    public Dictionary<string, Button> buttons = new Dictionary<string, Button>();
    public Text record_time_text;
    Canvas canvas;

    public void Init()
    {
        canvas = GameObject.FindAnyObjectByType<Canvas>();
        for (int i = 0; i < canvas.transform.childCount; i++)
        {
            if (canvas.transform.GetChild(i).TryGetComponent<Image>(out Image obj))
            {
                window.Add(obj.name, obj.gameObject);
                if (obj.transform.GetComponentInChildren<Button>() == true)
                {
                    for (int j = 0; j < obj.transform.childCount; j++)
                    {
                        if(obj.transform.GetChild(j).TryGetComponent<Button>(out Button button))
                        {
                            buttons.Add(button.gameObject.name, button);
                        }
                    }
                    buttons["Restart"].onClick.AddListener(() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex));
                    buttons["Exit"].onClick.AddListener(() => SceneManager.LoadScene("Main_scene"));
                }
                obj.gameObject.SetActive(false);
            }
            else if(canvas.transform.GetChild(i).TryGetComponent<Slider>(out Slider slider))
            {
                air_gauge = slider;
            }
            else if(canvas.transform.GetChild(i).TryGetComponent<Text>(out Text text))
            {
                record_time_text = text;
            }
        }
    }
    
}
