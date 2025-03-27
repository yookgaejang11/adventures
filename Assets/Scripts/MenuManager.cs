using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject RankingPage;
    public int BagPrice = 100;
    public int GasPrice = 100;
    public Text BagPriceTxt;
    public Text GasPriceTxt;
    public Text BagLevelTxt;
    public Text GasLevelTxt;
    public Text errorTxt;
    public Text PriceTxt;
    public GameObject ShopPage;
    public void StartBtn()
    {
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        BagPriceTxt.text ="����\n  ���� : \n" + BagPrice.ToString();
        GasPriceTxt.text ="�����\n  ���� : \n" + GasPrice.ToString();
    }
    private void Update()
    {
        if(PriceTxt != null)
        {
            PriceTxt.text = "������:" + DataManager.Instance.playerData.Gold.ToString();
        }
    }
    public void Shop()
    {
        ShopPage.SetActive(true);
    }

    public void Buy(int num)
    {
        StartCoroutine(BuyItem(num));
    }

    IEnumerator BuyItem(int num)
    {
        switch (num)
        {
            case 0:
                {
                    if (DataManager.Instance.playerData.Gold >= BagPrice)
                    {
                        Debug.Log("���� ���ݾ�");
                        if (DataManager.Instance.playerData.BagLevel < 3)
                        {
                            DataManager.Instance.playerData.Gold -= BagPrice;
                            DataManager.Instance.playerData.BagLevel += 1;
                            BagPrice += 25;
                            BagPriceTxt.text = "����\n  ���� : \n" + BagPrice.ToString();
                            BagLevelTxt.text = "���� ���� ����:" + DataManager.Instance.playerData.BagLevel;
                            if (DataManager.Instance.playerData.BagLevel == 3)
                            {
                                BagLevelTxt.text = "���� ���� ����:MAX";
                            }
                        }
                        else
                        {
                            errorTxt.text = "���̻� ���� ������ �ø� �� �����ϴ�!";
                            yield return new WaitForSeconds(1);
                            errorTxt.text = " ";
                        }
                    }
                    else
                    {
                        errorTxt.text = "���� �����մϴ�!";
                        yield return new WaitForSeconds(1);
                        errorTxt.text = " ";
                    }
                }
                break;
            case 1:
                {
                    if (DataManager.Instance.playerData.Gold >= GasPrice)
                    {
                        if (DataManager.Instance.playerData.GasLevel < 3)
                        {
                            DataManager.Instance.playerData.Gold -= GasPrice;
                            DataManager.Instance.playerData.GasLevel += 1;
                            GasPrice += 25;
                            GasLevelTxt.text = "���� ����� ����:" + DataManager.Instance.playerData.GasLevel;
                            GasPriceTxt.text = "�����\n  ���� : \n" + GasPrice.ToString();
                            if (DataManager.Instance.playerData.GasLevel == 3)
                            {
                                GasLevelTxt.text = "���� ����� ����:MAX";
                            }
                        }
                        else
                        {
                            errorTxt.text = "���̻� ����� ������ �ø� �� �����ϴ�!";
                            yield return new WaitForSeconds(1);
                            errorTxt.text = " ";
                        }
                    }
                    else
                    {
                        errorTxt.text = "���� �����մϴ�!";
                        yield return new WaitForSeconds(1);
                        errorTxt.text = " ";
                    }
                }
                break;
        }
        yield return null;
    }

    public void RankingBtn()
    {
        RankingPage.SetActive(true);
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
            case 1:
                {
                    RankingPage.SetActive(false);
                }
                break;
        }
    } 
}
