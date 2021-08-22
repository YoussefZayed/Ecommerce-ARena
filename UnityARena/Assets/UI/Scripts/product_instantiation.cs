using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class product_instantiation : MonoBehaviour
{
    public List<Dictionary<string, string>> data;
    public GameObject panel, scroll_pane;
    public GameObject product_button_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
        GameObject scroll_pane = panel.GetComponent<GameObject>();
        // Button bt = button.GetComponent<Button>();
        // bt.onClick.AddListener(add_item);

        data = GameObject.FindWithTag("data").GetComponent<sample_data>().getItem();

        for(int i = 0; i < data.Count; i++) {
            add_item(data[i], i);
        }
        
        
    }   

    void add_item(Dictionary<string, string> product, int i)
    {
        GameObject item = Instantiate(product_button_prefab);
        item.transform.SetParent(scroll_pane.transform);
        item.name = item.name + i;
        item.transform.Find("Prod_Name").GetComponentInChildren<Text>().text = (i+1).ToString() + ": " + product["Title"];
        //item.AddComponent<item_page_script>();
        item.transform.Find("Price").GetComponentInChildren<Text>().text = "$" + product["Price"];
    
    }
}
