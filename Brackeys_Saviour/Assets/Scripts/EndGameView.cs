using System;
using ModestTree;
using SpiritResources;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

public class EndGameView : ContentUI {

    [SerializeField]
    private GameObject _goodEnding;
    
    [SerializeField]
    private GameObject _badEnding;

    [SerializeField]
    private TextMeshProUGUI _finalText;
    
    [TextArea(0, 10)]
    [SerializeField]
    private string _finalBadEndingHappiness;
    
    [TextArea(0, 10)]
    [SerializeField]
    private string _finalBadEndingMoney;
    
    [TextArea(0, 10)]
    [SerializeField]
    private string _finalGoodEndingHappiness;
    
    [TextArea(0, 10)]
    [SerializeField]
    private string _defaultFinalTextGood;
    
    [TextArea(0, 10)]
    [SerializeField]
    private string _defaultFinalTextBad;

    protected override void Awake() {
        base.Awake();
        Assert.IsNotNull(_goodEnding);
        Assert.IsNotNull(_badEnding);
    }

    public void ShowGoodEnding() {
        ShowContent();
        //happiness max end
        _badEnding.SetActive(false);
        _goodEnding.SetActive(true);
        _finalText.text = _finalGoodEndingHappiness;
    }

    public void ShowBadEnding(SpiritResourceType spiritResourceType) {
        ShowContent();
        _goodEnding.SetActive(false);
        _badEnding.SetActive(true);
        _finalText.text = CreateBadEndingForResource(spiritResourceType);
    }

    private string CreateBadEndingForResource(SpiritResourceType spiritResourceType) {
        switch (spiritResourceType) {
            case SpiritResourceType.Happiness:
                return _finalBadEndingHappiness;
            case SpiritResourceType.Money:
                return _finalBadEndingMoney;
        }
        return _finalBadEndingHappiness;
    }

    public void ShowEventEnding(int happyCount, int volunteersCount, int initHappiness) {
        ShowContent();
        if (happyCount > initHappiness) {
            Debug.Log("init: " + initHappiness);
            Debug.Log("current: " + happyCount);
            ShowDefaultGood(happyCount, volunteersCount);
        } else {
            ShowDefaultBad(happyCount, volunteersCount);
        }
    }
    
    
    private void ShowDefaultGood(int happyCount, int volunteersCount) {
        //happiness max end
        _badEnding.SetActive(false);
        _goodEnding.SetActive(true);
        _finalText.text = CreateDefaultTextForGood(happyCount, volunteersCount);
    }

    private string CreateDefaultTextForGood(int happyCount, int volunteersCount) {
        string finalText = _defaultFinalTextGood.Replace("VolunteersCount", volunteersCount.ToString());
        return finalText;
    }

    private void ShowDefaultBad(int happyCount, int volunteersCount) {
        //happiness max end
        _badEnding.SetActive(false);
        _goodEnding.SetActive(true);
        _finalText.text = CreateDefaultTextForBad(happyCount, volunteersCount);
    }
    
    private string CreateDefaultTextForBad(int happyCount, int volunteersCount) {
        string finalText = _defaultFinalTextBad.Replace("VolunteersCount", volunteersCount.ToString());
        return finalText;
    }
}