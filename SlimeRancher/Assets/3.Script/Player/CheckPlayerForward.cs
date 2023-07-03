using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPlayerForward : MonoBehaviour
{
    [SerializeField] GameObject interpretation_ui;
    [SerializeField] Text name_text;
    [SerializeField] Text details_text;
    [SerializeField] GameObject Press_E;

    private void LateUpdate()
    {
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position, transform.forward, 50f);

        for(int i=0; i<hits.Length; i++)
        {
            if(hits[i].transform.GetComponent<Interpretation>() != null)
            {
                if (!interpretation_ui.activeSelf)
                {
                    interpretation_ui.SetActive(true);
                }

                name_text.text = hits[i].transform.GetComponent<Interpretation>().my_name;
                details_text.text = hits[i].transform.GetComponent<Interpretation>().my_details;

                return;
            }
            else if (hits[i].transform.GetComponent<Corral>() != null)
            {
                Press_E.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Press_E.SetActive(false);
                    hits[i].transform.GetComponent<Corral>().ShowCorralUI();
                }

            }
            else if (hits[i].transform.GetComponent<Unlock>() != null)
            {
                Press_E.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Press_E.SetActive(false);
                    hits[i].transform.GetComponent<Unlock>().ShowUnlockUI();
                }
            }
            else if (interpretation_ui.activeSelf)
            {
                interpretation_ui.SetActive(false);
            }else if (Press_E.activeSelf)
            {
                Press_E.SetActive(false);
            }
        }


        Debug.DrawRay(transform.position, transform.forward * 50f, Color.red);
    }
}
