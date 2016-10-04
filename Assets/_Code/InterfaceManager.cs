using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//By @JavierBullrich

public class InterfaceManager : MonoBehaviour {

    public Text woodAmount;
    public Text goldAmount;

    public static InterfaceManager instance;
    public GameObject barrackButton;
    public GameObject spaceshipButton;
    public GameObject congratulations;

    void Awake()
    {
        instance = this;
    }

    public void UpdateUI()
    {
        woodAmount.text = "Wood: " + ColonyManager.instance.resources.woodObtained;
        goldAmount.text = "Gold: " + ColonyManager.instance.resources.goldObtained;
    }

    public void BuildBarrack()
    {
        if (ColonyManager.instance.resources.woodObtained > ColonyManager.instance.barrack.woodCost && ColonyManager.instance.resources.goldObtained > ColonyManager.instance.barrack.goldCost)
        {
            ColonyManager.instance.barrack.Construct();
            ColonyManager.instance.resources.woodObtained -= ColonyManager.instance.barrack.woodCost;
            ColonyManager.instance.resources.goldObtained -= ColonyManager.instance.barrack.goldCost;
            UpdateUI();
            barrackButton.SetActive(false);
        }
    }

    public void BuildSpaceship()
    {
        if (ColonyManager.instance.resources.woodObtained > ColonyManager.instance.spaceship.woodCost && ColonyManager.instance.resources.goldObtained > ColonyManager.instance.spaceship.goldCost)
        {
            ColonyManager.instance.spaceship.Construct();
            ColonyManager.instance.resources.woodObtained -= ColonyManager.instance.spaceship.woodCost;
            ColonyManager.instance.resources.goldObtained -= ColonyManager.instance.spaceship.goldCost;
            UpdateUI();
            spaceshipButton.SetActive(false);
        }
    }

    public void ShowDescription(GameObject text)
    {
        text.SetActive(true);
    }
    public void HideDescription(GameObject text)
    {
        text.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void CheckWebsite()
    {
        Application.OpenURL("http://jbullrich.com.ar/gameDev/");
    }
}
