using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class item_page_script : MonoBehaviour
{
    Animator anim;
    public Button open;
    public Button close;

    // Start is called before the first frame update
    void Start()
    {
	anim = gameObject.GetComponent<Animator>();
    	Button op = open.GetComponent<Button>();
	Button cl = close.GetComponent<Button>(); 
	op.onClick.AddListener(MenuOpen);
	cl.onClick.AddListener(MenuClose);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void MenuOpen()
    {
	Debug.Log("Open");
	anim.ResetTrigger("item_page_cl");
	anim.SetTrigger("item_page_op");
    }

    void MenuClose()
    {
	Debug.Log("Close");
	anim.ResetTrigger("item_page_op");
	anim.SetTrigger("item_page_cl");
    }

}
