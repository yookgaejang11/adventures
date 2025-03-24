using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject ShopPage;
    public void GameStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        ShopPage.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
