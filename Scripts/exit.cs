using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exit : MonoBehaviour
{
    public Button button;
    rock rock;
    private void Start()
    {
        button.onClick.AddListener(starr);
    }
    void starr()
    {

        rock.score = 0;
        Application.Quit();
    }
}
