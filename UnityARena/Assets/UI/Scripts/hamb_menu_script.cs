using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class hamb_menu_script : MonoBehaviour
{
    Animator anim;
    public Button hamb_open;
    public Button hamb_close;

    // Start is called before the first frame update
    void Start()
    {
	anim = gameObject.GetComponent<Animator>();
    	Button op = hamb_open.GetComponent<Button>();
	Button cl = hamb_close.GetComponent<Button>(); 
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
	anim.ResetTrigger("hamb_button_cl");
	anim.SetTrigger("hamb_button_op");
    }

    void MenuClose()
    {
	Debug.Log("Close");
	anim.ResetTrigger("hamb_button_op");
	anim.SetTrigger("hamb_button_cl");
    }

}
