using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;

public class productfilter : MonoBehaviour
{
    [SerializeField]
    private TextAsset jsonFile;
    [SerializeField]
    private Transform productgrid;
    [SerializeField]
    private GameObject productPrefab;
    [SerializeField]
    private Dropdown categorydropdown,typeDropdown;

    [SerializeField]
    private GameObject productPanel, filterPanel;

    [Serializable]
    public class product
    {
        public string name;
        public string category;
        public string type;
        public string img;
        public float price;
        public GameObject pgameobject;
    }

    public List<product> Productdatabase;
    // Start is called before the first frame update
    void Start()
    {
        Productdatabase = new List<product>();
        createProductList(jsonFile.text);
    }

    void createProductList(string jsondata)
    {
        var N = JSON.Parse(jsondata) as JSONObject;
        JSONObject jk = N as JSONObject;
        foreach (JSONArray js in jk)
        {
            foreach (JSONObject jproduct in js)
            {
                product mproduct = JsonUtility.FromJson<product>(jproduct.ToString());
                Productdatabase.Add(mproduct);
            }
        }
        createProductCatalog();
    }

    void createProductCatalog()
    {
        foreach (product p in Productdatabase)
        {
            GameObject gk = Instantiate(productPrefab, productgrid);
            p.pgameobject = gk;
            gk.transform.GetChild(1).gameObject.GetComponent<Text>().text = p.name;
            gk.transform.GetChild(2).gameObject.GetComponent<Text>().text = "Rs "+p.price.ToString();
        }

    }

    public void filterProductbycat()
    {
        string catname=categorydropdown.options[categorydropdown.value].text;
        string type=typeDropdown.options[typeDropdown.value].text;

        Debug.Log(catname + "/" + type);
        if (string.IsNullOrEmpty(catname) || string.IsNullOrEmpty(type))
        {
            Debug.Log("Please Select category and subcategory");
            return;
        }
      
        foreach (product p in Productdatabase)
        {
            p.pgameobject.SetActive(false);

            if (p.category == catname)
            {
                if (p.type == type)
                {
                    p.pgameobject.SetActive(true);
                }
            }
        }

        filterPanel.gameObject.SetActive(false);


    }

 
}
