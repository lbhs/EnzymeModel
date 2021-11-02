using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextManagerScript : MonoBehaviour
{
    private TMP_Text tmpText;

    // Start is called before the first frame update
    void Start()
    {
        tmpText = GetComponent<TMP_Text>();
    }

    private void Awake()
    {
        EventManager.bondBreakSuccess += DisplaySuccessMessage;
        EventManager.bondBreakFailure += DisplayFailureMessage;
    }

    private void DisplaySuccessMessage()
    {
        tmpText.text = CommonMessages.successMessage;
    }

    private void DisplayFailureMessage()
    {
        tmpText.text = CommonMessages.failureMessage;
    }

    private void OnDestroy()
    {
        EventManager.bondBreakSuccess -= DisplaySuccessMessage;
        EventManager.bondBreakFailure -= DisplayFailureMessage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
