using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIalogueManager : MonoBehaviour
{
    public Text nametext;
    public Text dialoguetext;

    private Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    public void startDialogue (Dialogue dialogue)
    {
        Debug.Log("Starting conversation with " + dialogue.name);

        nametext.text = dialogue.name;

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();



    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            Enddialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        dialoguetext.text = sentence;
    }

    public void Enddialogue()
    {
        Debug.Log("End of Conversation");
    }




}
