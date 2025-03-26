using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public int BagPrice;
    public Text BagLevelTxt;
    public Text GasLevelTxt;
    public Text errorTxt;
    public GameObject ShopPage;
    public void Start()
    {
        SceneManager.LoadScene(1);
    }

    public void Shop()
    {
        ShopPage.SetActive(true);
    }

    public void Buy(int num)
    {
        switch (num)
        {
            case 0:
                {
                   if (DataManager.Instance.playerData.Gold >= BagPrice)
                    {
                        if (DataManager.Instance.playerData.BagLevel < 3)
                        {
                            DataManager.Instance.playerData.BagLevel += 1;
                            BagLevelTxt.text = "���� ���� ����:" + DataManager.Instance.playerData.BagLevel;
                            if (DataManager.Instance.playerData.BagLevel == 3)
                            {
                                BagLevelTxt.text = "���� ���� ����:MAX";
                            }
                        }
                        else
                        {
                            errorTxt.text = "���̻� ���� ������ �ø� �� �����ϴ�!";
                        }
                    }
                   else
                    {
                        errorTxt.text = "���� �����մϴ�!";
                    }
                }
                break;
            case 1:
                {
                    if (DataManager.Instance.playerData.Gold >= BagPrice)
                    {
                        if (DataManager.Instance.playerData.GasLevel < 3)
                        {
                            DataManager.Instance.playerData.GasLevel += 1;
                            BagLevelTxt.text = "���� ���� ����:" + DataManager.Instance.playerData.GasLevel;
                            if (DataManager.Instance.playerData.GasLevel == 3)
                            {
                                GasLevelTxt.text = "���� ���� ����:MAX";
                            }
                        }
                        else
                        {
                            errorTxt.text = "���̻� ����� ������ �ø� �� �����ϴ�!";
                        }
                    }
                    else
                    {
                        errorTxt.text = "���� �����մϴ�!";
                    }
                }
                break;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Back(int num)
    {
        switch (num)
        {
            case 0:
                {
                    ShopPage.SetActive(false);
                }
                break;
        }
    } 
}
