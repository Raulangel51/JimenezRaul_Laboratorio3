using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    //variables
    public GameObject pauseMenu;
    private bool isPaused = false;
    public GameObject player;
    private GameObject newObj;
    private GameObject op;

    // Start is called before the first frame update
    void Start()
    {
        if(player)
        {
            op = Instantiate(player, new Vector3(-12, 1, -9), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.KeypadEnter))
        {
            if(!op && !newObj)
            {
                newObj = Instantiate(player, new Vector3(0,2,0),Quaternion.identity);
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if(pauseMenu)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0.0f : 1.0f; 
        }
    }

    public void ChangeScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
