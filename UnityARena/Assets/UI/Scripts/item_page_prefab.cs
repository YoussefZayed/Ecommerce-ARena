using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class item_page_prefab : MonoBehaviour
{
    // public item_page_script item;
    public List<Dictionary<string, string>> data;
    public Button button;
    public Image img;
    // Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        // anim = gameObject.GetComponent<Animator>();
    
        // string name = ;
        Button product = button.GetComponent<Button>();
        product.onClick.AddListener(Open);

     
        
        // item_page_script item =
    }

    void Open()
    {
        //  GameObject.FindWithTag("item_page").GetComponent<item_page_script>().toggle = true;
        name = EventSystem.current.currentSelectedGameObject.name;
        int index = int.Parse(name.Substring(name.Length - 1));
        Debug.Log(index.ToString());

        data = GameObject.FindWithTag("data").GetComponent<sample_data>().getItem();
        Dictionary<string, string> product = data[index];

        GameObject.FindWithTag("item_page").GetComponentInChildren<Text>().text = "";
        foreach(KeyValuePair<string, string> entry in product){
            // if(entry.Key != "ImageLink"){
                GameObject.FindWithTag("item_page").GetComponentInChildren<Text>().text += entry.Key + ": ";
                GameObject.FindWithTag("item_page").GetComponentInChildren<Text>().text += entry.Value + "\n";
            // }
            // else {       
            //     if(entry.Value != null){
            //         Url_Image(entry.Value);
            //         GameObject.FindWithTag("item_page").GetComponentInChildren<Image>().sprite = img.sprite;
            //     }
            // }
        }
        
        

        GameObject.FindWithTag("item_page").GetComponent<item_page_script>().MenuOpen();

    }
    // IEnumerator Url_Image(string url) {
    //         WWW www = new WWW(url);
    //         yield return www;
    //         if(www.texture != null){
    //             img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    //         }
    // }
}
