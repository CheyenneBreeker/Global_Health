//Tutorial link https://www.youtube.com/watch?v=IRAeJgGkjHk

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManagerMetNetwerk : MonoBehaviour
{
    public int maxMessages = 50;

    public GameObject contentPanel, textPrefab;
    public InputField inputBox;
    public string userName;

    public Color playerMessageColor, systemMessageColor;

    [SerializeField] //This is only Serialized for debug reasons
    List<NetworkMessage> messageList = new List<NetworkMessage>();

    void Update()
    {
        if (inputBox.text != "")
        {
            if (inputBox.text == "/system" && Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat("This is a message sent by the system.", NetworkMessage.MessageType.systemMessage);
                inputBox.text = "";
                inputBox.ActivateInputField();
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                SendMessageToChat(userName + ": " + inputBox.text, NetworkMessage.MessageType.playerMessage);
                inputBox.text = "";
                inputBox.ActivateInputField();
            }
        }
        else
        {
            if (!inputBox.isFocused && Input.GetKeyDown(KeyCode.Return))
            {
                inputBox.ActivateInputField();
            }
        }
    }

    public void SendMessageToChat(string text, NetworkMessage.MessageType messageType)
    {
        if (messageList.Count >= maxMessages)
        {
            Destroy(messageList[0].textPrefab.gameObject);
            messageList.Remove(messageList[0]);
        }
        NetworkMessage newMessage = new NetworkMessage();

        newMessage.text = text;

        GameObject newText = Instantiate(textPrefab, contentPanel.transform);
        newMessage.textPrefab = newText.GetComponent<Text>();

        newMessage.textPrefab.text = newMessage.text;
        newMessage.textPrefab.color = MessageTypeColor(messageType);

        messageList.Add(newMessage);
    }

    Color MessageTypeColor(NetworkMessage.MessageType messageType)
    {
        Color color;

        switch (messageType)
        {
            case NetworkMessage.MessageType.playerMessage:
                color = playerMessageColor;
                break;

            case NetworkMessage.MessageType.systemMessage:
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
public class NetworkMessage
{
    public string text;
    public Text textPrefab;
    public MessageType messageType;

    public enum MessageType
    {
        playerMessage,
        systemMessage
    }
}