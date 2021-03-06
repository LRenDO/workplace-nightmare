using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextPrompt : MonoBehaviour
{
    /// <summary>
    /// used to turn off hints to allow for text entry use of  key
    /// </summary>
    public bool isFrozen { set; get; }

    private Text PromptText;
    private GameObject TextBox;

    public void UpdateTextBox(string text)
    {
        if (!TextBox.activeSelf)
        {
            TextBox.SetActive(true);
        }
        PromptText.text = text;
    }

    public void CloseTextBox()
    {
        PromptText.text = "";
        TextBox.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        PromptText = this.gameObject.transform.GetComponentInChildren<Text>();

        // Start with text box hidden
        TextBox = this.gameObject.transform.GetChild(0).gameObject;
        TextBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(TextBox.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            CloseTextBox();
        }
    }
}
