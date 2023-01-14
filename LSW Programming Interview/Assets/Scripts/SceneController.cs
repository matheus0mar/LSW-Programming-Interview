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
    [SerializeField]
    private GameObject shopPanel;
    [SerializeField]
    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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

    public void OpenShop()
    {
        shopPanel.SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = false;

    }

    public void CloseShop()
    {
        shopPanel.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;
    }
}
