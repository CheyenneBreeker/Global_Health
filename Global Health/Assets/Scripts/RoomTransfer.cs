using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RoomTransfer : MonoBehaviour
{
    public string roomname;
    public GameObject inputField;
    public GameObject textDisplay;

    string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);

    public void StoreRoom()
    {
        roomname = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Created " + roomname.ToString();
        StartCoroutine(GetRoomname(roomname, ipv4));
    }

    IEnumerator GetRoomname(string roomname, string ipaddress)
    {
        WWWForm form = new WWWForm();
        form.AddField("roomName", roomname);
        form.AddField("userIP", ipaddress);


        using (UnityWebRequest www = UnityWebRequest.Post("https://epigastric-conseque.000webhostapp.com/GetRoom.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
