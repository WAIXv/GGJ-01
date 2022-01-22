using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject pauseMenu;
    


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void UIEnabled()
    {
        //目录方式找到文件,字符型方式找
        GameObject.Find("Canvas/MainMenu/UI").SetActive(true);

    }

    //暂停
    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;//控制时间比例
    }
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;//恢复运作
    }
}
