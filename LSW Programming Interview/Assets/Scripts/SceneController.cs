using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField]
    private Collider2D triggerPlayer;
    [SerializeField]
    private Collider2D triggerShop;
    [SerializeField]
    private Collider2D shopDoor;

    [SerializeField]
    private Animator leftDoor;
    [SerializeField]
    private Animator rightDoor;

    [SerializeField]
    private GameObject buyButton;
   
    //Interaction if the player is near seller and door-------
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "triggerSHOP")
        {
            buyButton.SetActive(true);
        }
        if(collision.name == "shopDoor")
        {
            leftDoor.SetBool("close", false);
            rightDoor.SetBool("close", false);
        }
    }

    //Interaction if the player is far seller and door--------
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "triggerSHOP")
        {
            buyButton.SetActive(false);
        }
        if (collision.name == "shopDoor")
        {
            leftDoor.SetBool("close", true);
            rightDoor.SetBool("close", true);
        }

    }

    //Quit Game------------
    public void ExitGame()
    {
        Application.Quit();
    }

}
