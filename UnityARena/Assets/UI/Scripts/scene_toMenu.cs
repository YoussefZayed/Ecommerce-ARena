using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class scene_toMenu : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Button bt = button.GetComponent<Button>();
        bt.onClick.AddListener(SwitchScene);
    }

    void SwitchScene()
    {
        SceneManager.LoadScene("UI");
    }
}
