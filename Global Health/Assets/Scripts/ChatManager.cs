//Tutorial link https://www.youtube.com/watch?v=IRAeJgGkjHk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public int maxMessages = 25;

    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public string userName;

    public Color playerMessageColor, systemMessageColor;

    [SerializeField]
    List<Message> messageList = new List<Message>();

    // Update is called once per frame
    void Update()
    {
        if (chatBox.text != "")
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(userName + ": " + chatBox.text, Message.MessageType.playerMessage);
                chatBox.text = "";
                chatBox.ActivateInputField();
            }
        }
        else
        {
            if (!chatBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat("Activated chatbox", Message.MessageType.systemMessage);
                chatBox.ActivateInputField();
            }
        }
    }

    public void SendMessageToChat(string text, Message.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textObject.gameObject);
            messageList.Remove(messageList[0]);
        }
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);
        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        newMessage.textObject.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(Message.MessageType messageType)
    {
        Color color;

        switch(messageType)
        {
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
public class Message
{
    public string text;
    public Text textObject;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        systemMessage
    }
}