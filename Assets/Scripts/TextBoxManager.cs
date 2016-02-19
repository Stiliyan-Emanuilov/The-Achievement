using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;

    // Use this for initialization
    public TextAsset textFile;
    public string[] textLines;

    public int currentLine, endAtLine;
    public PlayerMovement player;
    public bool isActive;
    public bool stopPlayerMovement;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        if (textFile != null)
        {
            textLines = textFile.text.Split('\n');
        }

        if(endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
            EnableTextBox();
        else
            DisableTextBox();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActive) return;
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown("x"))
            currentLine++;
        if (currentLine > endAtLine)
            DisableTextBox();
    }

    public void EnableTextBox()
    {
        if (stopPlayerMovement)
            player.canMove = false;
        isActive = true;
        textBox.SetActive(true);
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        player.canMove = true;
        isActive = false;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = theText.text.Split('\n');
        }
    }
}
