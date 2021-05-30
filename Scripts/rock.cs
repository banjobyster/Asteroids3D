using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rock : MonoBehaviour
{

    public ParticleSystem boom;
    float damage = 1;
    float time = 0;
    bool isPlayed = false;
    public static int score = 0;
    //public Text text;

    // Update is called once per frame
    private void Start()
    {
        boom.Pause();
    }
    void Update()
    {
        if (damage <= 0 && isPlayed == false)
        {
            boom.Play();
            isPlayed = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            time += 0.1f;
            score += 10;
        }
        if (time > 2)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "laser")
        {
            damage -= 1;
        }
        if(collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
