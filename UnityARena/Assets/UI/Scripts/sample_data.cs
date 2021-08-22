using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sample_data : MonoBehaviour
{ 
    public List<Dictionary<string, string>> item = new List<Dictionary<string, string>>();
    public Dictionary<string, string> dic;
    // Start is called before the first frame update
    void Start()
    {
       
        // item.Add(new Dictionary<string, string>(dic));
        // item.Add(new Dictionary<string, string>(dic));
        // item.Add(new Dictionary<string, string>(dic));
        // item.Add(new Dictionary<string, string>(dic));

        
        item = GameObject.FindWithTag("scrape").GetComponent<scrape>().getDictionaries(GameObject.FindWithTag("scrape").GetComponent<scrape>().getProducts(new List<string>{
            "https://api.webscrapingapi.com/v1?api_key=8dplouf5IVVK6AZWPa83akQvrRlnXMIu&url=https%3A%2F%2Fwww.amazon.ca%2FPhilps-Computer-Monitors-278E1A-Replacement%2Fdp%2FB07ZSGR5TM%2Fref%3Dpd_di_sccai_9%2F132-3900957-0595955%3Fpd_rd_w%3D70wZ4%26pf_rd_p%3De92f388e-b766-4f7f-aac1-ee1d0056e8fb%26pf_rd_r%3DBDR8J2BMNE0F991NMV2G%26pd_rd_r%3D3eda7cc6-4b1b-46df-abe6-2667ec1da667%26pd_rd_wg%3DEoM5z%26pd_rd_i%3DB07ZSGR5TM%26psc%3D1&method=GET&device=desktop&proxy_type=datacenter",
            "https://api.webscrapingapi.com/v1?api_key=8dplouf5IVVK6AZWPa83akQvrRlnXMIu&url=https%3A%2F%2Fwww.amazon.ca%2FSamsung-Galaxy-lite-32GB-Mystic%2Fdp%2FB09695GVZ5%3Fref_%3DOct_DLandingS_D_78803a5b_60%26smid%3DA3DWYIK6Y9EEQB&method=GET&device=desktop&proxy_type=datacenter" 
            }));

         dic = new Dictionary<string, string>(){
            {"Title","SAMSUNG SR35 Series 27 inch FHD 1920x1080 Flat Desktop Monitor for Working or Learning, HDMI, D-Sub, Wall mountable (LS27R35AFHNXZA) "},
            {"Price","239.99"},
            {"Dimensions","25  61.2  46.3"},
            {"ProductType","monitor"},
            {"ImageLink",""}};
        item.Add(new Dictionary<string, string>(dic));
        dic = new Dictionary<string, string>(){
            {"Title","MSI Full HD FreeSync Gaming Monitor 24 Curved Non-Glare 1ms Led Wide Screen 1920 X 1080 144Hz Refresh Rate (Optix G24C),Black/Red "},
            {"Price","215.99"},
            {"Dimensions","54.3  40  17.9"},
            {"ProductType","monitor"},
            {"ImageLink",""}};
        item.Add(new Dictionary<string, string>(dic));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Dictionary<string, string>> getItem(){
        return item;
    }
}
