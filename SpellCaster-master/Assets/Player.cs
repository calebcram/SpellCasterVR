using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int hp = 5;
    public int score = 0;
    string level = "Tutorial";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hp <= 0)
        {
            SceneManager.LoadScene(level);
        }

        if (score == 10)
        {
            SceneManager.LoadScene("Dessert");
        }
    }
}
