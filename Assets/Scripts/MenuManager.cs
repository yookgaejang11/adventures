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
        BagPriceTxt.text ="가방\n  가격 : \n" + BagPrice.ToString();
        GasPriceTxt.text ="산소통\n  가격 : \n" + GasPrice.ToString();
    }
    private void Update()
    {
        if(PriceTxt != null)
        {
            PriceTxt.text = "소지금:" + DataManager.Instance.playerData.Gold.ToString();
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
                        Debug.Log("돈이 되잖아");
                        if (DataManager.Instance.playerData.BagLevel < 3)
                        {
                            DataManager.Instance.playerData.Gold -= BagPrice;
                            DataManager.Instance.playerData.BagLevel += 1;
                            BagPrice += 25;
                            BagPriceTxt.text = "가방\n  가격 : \n" + BagPrice.ToString();
                            BagLevelTxt.text = "현재 가방 레벨:" + DataManager.Instance.playerData.BagLevel;
                            if (DataManager.Instance.playerData.BagLevel == 3)
                            {
                                BagLevelTxt.text = "현재 가방 레벨:MAX";
                            }
                        }
                        else
                        {
                            errorTxt.text = "더이상 가방 레벨을 올릴 수 없습니다!";
                            yield return new WaitForSeconds(1);
                            errorTxt.text = " ";
                        }
                    }
                    else
                    {
                        errorTxt.text = "돈이 부족합니다!";
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
                            GasLevelTxt.text = "현재 산소통 레벨:" + DataManager.Instance.playerData.GasLevel;
                            GasPriceTxt.text = "산소통\n  가격 : \n" + GasPrice.ToString();
                            if (DataManager.Instance.playerData.GasLevel == 3)
                            {
                                GasLevelTxt.text = "현재 산소통 레벨:MAX";
                            }
                        }
                        else
                        {
                            errorTxt.text = "더이상 산소통 레벨을 올릴 수 없습니다!";
                            yield return new WaitForSeconds(1);
                            errorTxt.text = " ";
                        }
                    }
                    else
                    {
                        errorTxt.text = "돈이 부족합니다!";
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
