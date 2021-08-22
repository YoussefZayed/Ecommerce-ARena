using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class item_page_script : MonoBehaviour
{
    Animator anim;
    public bool toggle; 
    public Button close;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "item_page";
	    anim = gameObject.GetComponent<Animator>();
	    Button cl = close.GetComponent<Button>(); 
	    // op.onClick.AddListener(MenuOpen);
	    cl.onClick.AddListener(MenuClose);
    }


    public void MenuOpen()
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
    toggle = !toggle;
    }

}
