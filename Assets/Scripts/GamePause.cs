using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;

    // Start is called before the first frame update
    void Start()
    {
        unPause();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pausePanel.activeInHierarchy)
            {
                pause();
            }
            else
            if (pausePanel.activeInHierarchy)
            {
                unPause();
            }
        }
    }

    public void pause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void unPause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
