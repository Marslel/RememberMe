using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PanelDialogue : MonoBehaviour
{

    public TextMeshProUGUI textComponent;
    public string[] dialogueLines;
    public float textSpeed;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
        
    }

    IEnumerator TypeLine(){

        foreach (char c in dialogueLines[index].ToCharArray()){
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine(){
        if(index < dialogueLines.Length - 1){
            index ++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
    }
}
