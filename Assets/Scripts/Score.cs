using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject rborig;
    Rigidbody rbrg;
    int scoreperdiamond=15;
    int total_score=0;
    public TextMeshProUGUI score_txt_obj;

    private void Start()
    {
        rbrg = rborig.GetComponent<Rigidbody>();
        score_txt_obj.text = "0";
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Diamond")
        {
            other.gameObject.SetActive(false);
            total_score += scoreperdiamond;
            score_txt_obj.text = total_score.ToString();
        }
    }
}
