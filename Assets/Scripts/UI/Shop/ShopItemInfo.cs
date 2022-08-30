using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItemInfo : MonoBehaviour
{

    public int ItemID;
    public TextMeshProUGUI priceTag;
    private bool onSale;

    private GameObject shopManager;

    // Start is called before the first frame update
    void Start()
    {
        shopManager = GameObject.Find("ShopManager");
        gameObject.GetComponentInChildren<Button>().onClick.AddListener(delegate { shopManager.GetComponent<ShopManager>().Buy(gameObject); });
        //priceTag.text = "Price: FC " + shopManager.GetComponent<ShopManager>().shopItems[(int) ShopManager.Info.PRICE, ItemID];   
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
