//Tutorial link https://www.youtube.com/watch?v=IRAeJgGkjHk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour {
    public int maxMessages = 50;

    public GameObject contentPanel, textPrefab;
    public InputField inputBox;
    public string userName;

    public Color playerMessageColor, systemMessageColor;

    [SerializeField] //This is only Serialized for debug reasons
    List<Message> messageList = new List<Message> ();

    void Update () {
        if (inputBox.text != "") {
            if (inputBox.text == "/system" && Input.GetKeyDown (KeyCode.Return)) {
                SendMessageToChat ("This is a message sent by the system.", Message.MessageType.systemMessage);
                inputBox.text = "";
                inputBox.ActivateInputField ();
            } else if (Input.GetKeyDown (KeyCode.Return)) {
                SendMessageToChat (userName + ": " + inputBox.text, Message.MessageType.playerMessage);
                inputBox.text = "";
                inputBox.ActivateInputField ();
            }
        } else {
            if (!inputBox.isFocused && Input.GetKeyDown (KeyCode.Return)) {
                inputBox.ActivateInputField ();
            }
        }
    }

    public void SendMessageToChat (string text, Message.MessageType messageType) {
        if (messageList.Count >= maxMessages) {
            Destroy (messageList[0].textPrefab.gameObject);
            messageList.Remove (messageList[0]);
        }
        Message newMessage = new Message ();

        newMessage.text = text;

        GameObject newText = Instantiate (textPrefab, contentPanel.transform);
        newMessage.textPrefab = newText.GetComponent<Text> ();

        newMessage.textPrefab.text = newMessage.text;
        newMessage.textPrefab.color = MessageTypeColor (messageType);

        messageList.Add (newMessage);
    }

    Color MessageTypeColor (Message.MessageType messageType) {
        Color color;

        switch (messageType) {
            case Message.MessageType.playerMessage:
                color = playerMessageColor;
                break;

            case Message.MessageType.systemMessage:
                color = systemMessageColor;
                break;

            default:
                color = systemMessageColor;
                break;
        }
        return color;
    }
}

[System.Serializable]
public class Message {
    public string text;
    public Text textPrefab;
    public MessageType messageType;

    public enum MessageType {
        playerMessage,
        systemMessage
    }
}