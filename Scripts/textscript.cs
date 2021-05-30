using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textscript : MonoBehaviour
{
    public Text text;
    rock rock;
    void Update()
    {
        text.text = rock.score.ToString();
    }
}
