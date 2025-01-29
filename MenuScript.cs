using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public GameObject buttonPlay;
    public GameObject buttonAbout;
    public GameObject buttonControls;
    public GameObject buttonBack;
    public GameObject buttonMainMenu;
    public GameObject textAbout;
    public GameObject textControls;
    public GameObject textLoading;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        buttonPlay.SetActive(false);
        buttonAbout.SetActive(false);
        buttonControls.SetActive(false);
        textLoading.SetActive(true);
        SceneManager.LoadScene("Level 1");
    }

    public void Back()
    {
        //SceneManager.LoadScene("Main Menu");
        buttonPlay.SetActive(true);
        buttonAbout.SetActive(true);
        buttonControls.SetActive(true);
        buttonBack.SetActive(false);
        textAbout.SetActive(false);
        textControls.SetActive(false);
    }

    public void ShowAbout()
    {
        buttonPlay.SetActive(false);
        buttonAbout.SetActive(false);
        buttonControls.SetActive(false);
        buttonBack.SetActive(true);
        textAbout.SetActive(true);
    }

    public void ShowControls()
    {
        buttonPlay.SetActive(false);
        buttonAbout.SetActive(false);
        buttonControls.SetActive(false);
        buttonBack.SetActive(true);
        textControls.SetActive(true);
    }

    public void ShowGoToMainMenuButton()
    {
        buttonMainMenu.SetActive(true);
    }

    public void GoToMainMenu()
    {
        Debug.Log("GoToMainMenu");
        SceneManager.LoadScene("Main Menu");
    }
}
