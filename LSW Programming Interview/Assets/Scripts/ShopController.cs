using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopController : MonoBehaviour
{
    //Lists of items prefabs----------------------------------
    [SerializeField]
    private List<GameObject> armours = new List<GameObject>();
    [SerializeField]
    private List<GameObject> helmets = new List<GameObject>();
    [SerializeField]
    private List<GameObject> weapons = new List<GameObject>();

    //shopPreview ans Player separeted parts-----------------------
    [SerializeField]
    private SpriteRenderer previewBody, previewHead, previewWeapon;
    [SerializeField]
    private SpriteRenderer playerBody, playerHead, playerWeapon;
    [SerializeField]
    private GameObject previewShield, playerShield, shopPanel, player;

    //animators-----------------------------
    [SerializeField] 
    private Animator playerAnim, moneyAnim;

    //Money UI var---------------------------
    public static int moneyAmount;
    public static int maxMoneyAmount = 9999;
    [SerializeField] 
    private int addMoneyAmount;
    [SerializeField]
    private GameObject addCashButton;
    [SerializeField]
    private TextMeshProUGUI moneyText;

    //Shop utilitie-------
    private bool equiped;

    // Start is called before the first frame update
    void Start()
    {
        moneyAmount = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        //Limit max money amount--------------------------------------
        if(moneyAmount >= maxMoneyAmount)
        {
            addCashButton.GetComponent<Button>().interactable = false;
        }

        //Show money left------------------------
        moneyText.text = moneyAmount.ToString();
    }
    
    //function to add cash button-----------------
    public void AddCash()
    {
        moneyAmount += addMoneyAmount;
        moneyAnim.SetBool("moneyWarning", false);//turn off noMoneyWarning animation

    }


    //Function to Buy and change preview Armour---------------------------------------------------------------------
    public void ChangeArmour()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        foreach (GameObject go in armours)
        {
            if(go.name == clickedButtonName)
            {
                previewBody.sprite = go.transform.GetChild(0).GetComponent<Image>().sprite;
                if(go.transform.GetChild(1).gameObject.activeSelf == false)
                {
                    int price = int.Parse(go.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text);
                    if (moneyAmount - price >= 0)
                    {
                        moneyAnim.SetBool("moneyWarning", false);
                        moneyAmount -= price;
                        go.transform.GetChild(2).gameObject.SetActive(false);
                        go.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    else
                    {
                        moneyAnim.SetBool("moneyWarning", true);
                    }
                }                
            }
        }
    }

    //Function to Buy and change preview Helmets---------------------------------------------------------------------
    public void ChangeHelmet()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        foreach (GameObject go in helmets)
        {
            if (go.name == clickedButtonName)
            {
                previewHead.sprite = go.transform.GetChild(0).GetComponent<Image>().sprite;
                if(go.transform.GetChild(1).gameObject.activeSelf == false)
                {
                    int price = int.Parse(go.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text);
                    if(moneyAmount-price >= 0)
                    {
                        moneyAnim.SetBool("moneyWarning", false);
                        moneyAmount -= price;
                        go.transform.GetChild(2).gameObject.SetActive(false);
                        go.transform.GetChild(1).gameObject.SetActive(true);
                    }
                    else
                    {
                        moneyAnim.SetBool("moneyWarning", true);
                    }
                }
            }
        }
    }

    //Function to Buy and change preview Weapons---------------------------------------------------------------------
    public void ChangeWeapon()
    {
        string clickedButtonName = EventSystem.current.currentSelectedGameObject.name;
        foreach (GameObject go in weapons)
        {
            if (go.name == clickedButtonName)
            {
                previewWeapon.sprite = go.transform.GetChild(0).GetComponent<Image>().sprite;
                if (go.transform.GetChild(1).gameObject.activeSelf == false)
                {
                    int price = int.Parse(go.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text);
                    if (moneyAmount - price >= 0)
                    {
                        moneyAnim.SetBool("moneyWarning", false);
                        moneyAmount -= price;
                        go.transform.GetChild(2).gameObject.SetActive(false);
                        go.transform.GetChild(1).gameObject.SetActive(true);
                        playerAnim.SetTrigger("BuyWeapon");
                    }
                    else
                    {
                        moneyAnim.SetBool("moneyWarning", true);
                    }
                }
            }
        }
    }

    //Equip the bought things on main player--------
    public void EquipOnPlayer()
    {
        playerBody.sprite = previewBody.sprite;
        playerHead.sprite = previewHead.sprite;
        playerWeapon.sprite = previewWeapon.sprite;
        equiped = true;
    }

    //Disable shield on button----------------------
    public void DisablePreviewShield()
    {
        if(previewShield.activeSelf == true)
        {
            previewShield.SetActive(false);
        }
        else
        {
            previewShield.SetActive(true);
        }
    }

    //Open shop on Buy button------------------------------------
    public void OpenShop()
    {
        shopPanel.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;//Main player stays idle while the shop is opened

    }

    //Close shop on X button------------------------------------
    public void CloseShop()
    {
        shopPanel.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;//Main player stays idle while the shop is opened

        //Turn On and Off shield of main player based on preview
        if (previewShield.activeSelf == false)
        {
            playerShield.SetActive(false);
        }
        else
        {
            playerShield.SetActive(true);
        }

        //If you dont equip the bought itens the preview return to original--------------------
        if(equiped == false)
        {
            previewBody.sprite = armours[0].transform.GetChild(0).GetComponent<Image>().sprite;
            previewHead.sprite = helmets[0].transform.GetChild(0).GetComponent<Image>().sprite;
            previewWeapon.sprite = weapons[0].transform.GetChild(0).GetComponent<Image>().sprite;
        }
    }


}
