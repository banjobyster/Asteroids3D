using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;
    rock rock;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        button.onClick.AddListener(starrt) ;
    }
    void starrt()
    {

        rock.score = 0;
        SceneManager.LoadScene("MainGame");

    }
}
