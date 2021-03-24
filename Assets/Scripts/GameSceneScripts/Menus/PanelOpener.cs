using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;
    public void ManageButton()
    {
        if (!Panel.activeInHierarchy)
        {
            OpenPanel();
        }
        else
        {
            ClosePanel();
        }
    }

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("open", true);
            }
        }

    }
    public void ClosePanel()
    {

        if (Panel != null)
        {
            Animator animator = gameObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("open", false);
            }
        }
    }
}
