using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class FinalGateTrigger : MonoBehaviour
{
    public Transform score;
    public ParticleSystem finalFrag;
    private int count = 0;

    void Start()
    {
        finalFrag.Stop();    
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            count += 1;
            score.GetComponent<TextMeshProUGUI>().text = count.ToString();
            finalFrag.Play();
        }
    }
}
