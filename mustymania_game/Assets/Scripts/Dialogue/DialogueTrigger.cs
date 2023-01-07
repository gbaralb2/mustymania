using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public DialogueManager manager;

    private bool playerIsClose;
    private bool dialogueInProgress;

    /*
    public void TriggerDialogue()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerIsClose = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        playerIsClose = false;
    }

    void Update()
    {
        if ((!playerIsClose && dialogueInProgress == true) || (Input.GetKeyDown(KeyCode.E) && dialogueInProgress == true && manager.sentences.Count == 0))
        {
            manager.EndDialogue();
            dialogueInProgress = false;
            Debug.Log("Ending dialogue");
        }
        else if (Input.GetKeyDown(KeyCode.E) && playerIsClose && dialogueInProgress == true)
        {
            manager.DisplayNextSentence();
            Debug.Log("Next sentence");
        }
        else if (Input.GetKeyDown(KeyCode.E) && playerIsClose && dialogueInProgress == false)
        {
            manager.StartDialogue(dialogue);
            dialogueInProgress = true;
            Debug.Log("Starting dialogue");
        }
    }
}
