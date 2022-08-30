using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DefensesFeatures;

public class ShopManager : MonoBehaviour
{

    [SerializeField] public GameObject shop;

    [SerializeField] private Transform m_ContentContainer;
    [SerializeField] private GameObject m_ItemPrefab;
    [SerializeField] private int m_ItemsToGenerate;

    private TextMeshProUGUI[] infos;
    private Button upgrade;

    public Dictionary<int, GameObject> items;
    private LevelController lc;

    // Start is called before the first frame update
    void Start()
    {
        lc = LevelController.lc;
        items = new Dictionary<int, GameObject>();

        for (int i = 0; i < m_ItemsToGenerate; i++)
        {
            var item_go = Instantiate(m_ItemPrefab);
            // do something with the instantiated item -- for instance
            infos = item_go.GetComponentsInChildren<TextMeshProUGUI>();
            infos[0].text = "AntiVirus";
            infos[1].text = "Price FC: 100";
            infos[2].text = "This is an antivirus";
            upgrade = item_go.GetComponentInChildren<Button>();

            //parent the item to the content container
            item_go.transform.SetParent(m_ContentContainer);
            //reset the item's scale -- this can get munged with UI prefabs
            item_go.transform.localScale = Vector2.one;
            items[i] = item_go;
        }
    }

    // Update is called once per frame
    public void Buy(GameObject item)
    {
        // TO FIX
        if(lc.coins > 100)
        {
            lc.ModifyCoin(- 100);
            item.GetComponentInChildren<Button>().interactable = false;
        }
    }

    public void Update()
    {
    }

    public void openShop(string tag) {
        Debug.Log("open shop");
        shop.SetActive(true);
    }
}
