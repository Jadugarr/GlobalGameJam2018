using System;
using System.Text.RegularExpressions;
using Components;
using Events;
using UnityEngine;

public class TerminalComponent : MonoBehaviour
{
    [SerializeField] private TextMesh terminalTextField;
    [SerializeField] private float cursorInterval;
    [SerializeField] private TerminalMode terminalMode;
    [SerializeField] private int maxTextLength;
    [SerializeField] private int terminalId;

    public AudioManager AudioManager;

    private EventManager eventManager = EventManager.Instance;
    private float currentTimer = 0f;
    private bool cursorDisplayed = false;
    private string textPattern = "^[a-zA-Z]$";
    private string numberPattern = "^[0-9]$";
    private string activePattern;
    private bool isActive;

    private void Awake()
    {
        if (terminalMode == TerminalMode.Text)
        {
            activePattern = textPattern;
        }
        else
        {
            activePattern = numberPattern;
        }
    }

    private void Update()
    {
        currentTimer -= Time.deltaTime;

        if (currentTimer <= 0f)
        {
            ToggleCursor();
            currentTimer = cursorInterval;
        }

        if (isActive)
        {
            CheckInput();
        }
    }

    public void Activate(bool isActive)
    {
        this.isActive = isActive;
        if (!isActive)
        {
            ResetText();
        }
    }

    private void AddText(string text)
    {
        if (terminalTextField.text.Length - Convert.ToInt32(cursorDisplayed) < maxTextLength)
        {
            if (AudioManager)
            {
                AudioManager.PlayTerminalButtonSound();
            }
            if (cursorDisplayed)
            {
                terminalTextField.text = terminalTextField.text.Insert(terminalTextField.text.Length - 1, text);
            }
            else
            {
                terminalTextField.text = terminalTextField.text.Insert(terminalTextField.text.Length, text);
            }
        }
    }

    private void RemoveLastInput()
    {
        if (terminalTextField.text.Length > Convert.ToInt32(cursorDisplayed))
        {
            if (cursorDisplayed)
            {
                terminalTextField.text = terminalTextField.text.Substring(0, terminalTextField.text.Length - 2) + "_";
            }
            else
            {
                terminalTextField.text = terminalTextField.text.Substring(0, terminalTextField.text.Length - 1);
            }
        }
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown)
        {
            if (Input.GetKeyDown(KeyCode.Backspace))
            {
                RemoveLastInput();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendInput();
                return;
            }
            foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(vKey))
                {
                    string sourceString = vKey.ToString();
                    string pressedKey = sourceString.Substring(sourceString.Length - 1, 1);
                    if (Regex.IsMatch(pressedKey, activePattern))
                    {
                        AddText(pressedKey);
                    }
                }
            }
        }
    }

    private void ResetText()
    {
        terminalTextField.text = cursorDisplayed ? "_" : "";
    }

    private void SendInput()
    {
        eventManager.FireEvent(EventTypes.SendTerminalInput,
            new SendTerminalInputEvent(terminalTextField.text.Substring(0,
                terminalTextField.text.Length - Convert.ToInt32(cursorDisplayed)), terminalId));
        ResetText();
    }

    private void ToggleCursor()
    {
        if (cursorDisplayed)
        {
            if (terminalTextField.text.Length > 1)
            {
                terminalTextField.text = terminalTextField.text.Substring(0, terminalTextField.text.Length - 1);
            }
            else
            {
                terminalTextField.text = "";
            }
        }
        else
        {
            terminalTextField.text += "_";
        }

        cursorDisplayed = !cursorDisplayed;
    }
}