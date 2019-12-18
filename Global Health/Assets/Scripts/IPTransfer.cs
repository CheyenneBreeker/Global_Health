using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class IPTransfer : MonoBehaviour
{
    public string username;
    public GameObject inputField;
    public GameObject textDisplay;

    string ipv4 = IPManager.GetIP(ADDRESSFAM.IPv4);

    public void StoreName()
    {
        username = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = "Welcome " + username + " " + ipv4;
        StartCoroutine(GetUsername(username, ipv4));
    }

    IEnumerator GetUsername(string username, string ipaddress)
    {
        WWWForm form = new WWWForm();
        form.AddField("userName", username);
        form.AddField("userIP", ipaddress);

        using (UnityWebRequest www = UnityWebRequest.Post("https://epigastric-conseque.000webhostapp.com/GetIP.php", form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            } else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
