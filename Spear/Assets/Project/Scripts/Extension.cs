using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Extension : MonoBehaviour
{
    [SerializeField] public Score score;
    [SerializeField] private GameObject finishUI;
    [SerializeField] private GameManager manager;
    public float extensionSize = 0.1f;

    public string textValue;

    private Transform t_head;
    private SpearHead s_head;
    void Start()
    {
        t_head = transform.GetChild(1);
        s_head = t_head.GetComponent<SpearHead>();

        finishUI.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Extension") )
        {
            extension(extensionSize,'+');
            other.gameObject.SetActive(false);
        }
        else if(other.name == "Finish")
        {
            transform.parent.GetComponent<Movement>().speed = 0;
            finishUI.SetActive(true);
            manager.isFinish = true;
        }
    }

    void FixedUpdate()
    {
        PassTheGate();
    }
    private void PassTheGate()
    {
        if (s_head.Collide("Gate"))
        {
            textValue = s_head.CollideObject.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text;
            extension(GetValue(), GetSign());
            Die();
            s_head.CollideObject.GetComponent<BoxCollider>().enabled = false;
        }

    }
    private void extension(float extensionSize,char sign)
    {
        Debug.Log(sign);
        switch (sign)
        {
            case '+':
                transform.localScale += new Vector3(0, 0, extensionSize);
                break;
            case '-':
                transform.localScale -= new Vector3(0, 0, extensionSize);
                break;
            case 'x':
                transform.localScale = new Vector3(1, 1, transform.localScale.z * extensionSize);
                break;
            case '÷':
                transform.localScale = new Vector3(1, 1, transform.localScale.z / extensionSize);
                break;
        }
        score.ExtensionScore = transform.localScale.z.ToString();
    }

    private void Die()
    {
        GameObject player = transform.parent.gameObject;

        if (transform.localScale.z <= 0)
        {
            Destroy(player);
        }
    }
    private char GetSign()
    {

        return textValue.ToCharArray()[0];
    }
    private float GetValue()
    {
        return float.Parse( textValue.Substring(1) );
    }


}
