using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Lecture 4
using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using UnityEngine.UI;
using TMPro;


public class client : MonoBehaviour
{

    public TMP_InputField myName;
    public string playerName;
    public TMP_Text[] currentPlayers;

    private static byte[] outBuffer = new byte[512];
    private static IPEndPoint remoteEP;
    private static Socket client_socket;


    //Lecture 5
    private string[] sname;
    private byte[] bname;

    float isInput = 0.0f;
    bool isOpen = false;


    public void SaveName()
    {
        playerName = myName.text;
        for (int i = 0; i < 4; i++)
        {
            if (currentPlayers[i].text == "Open Slot")
            {
                currentPlayers[i].text = playerName;
                break;
            }
        }
    }


    public static void RunClient()
    {
        IPAddress ip = IPAddress.Parse("127.0.0.1");//192.168.2.144");
        remoteEP = new IPEndPoint(ip, 11111);

        client_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

    }

    // Start is called before the first frame update
    void Start()
    {
        

        //RunClient();

        //Lecture 5
        //pos = new float[] { myName.transform.position.x, myName.transform.position.y, myName.transform.position.z, isInput };
        //bname = new byte[name.Length * 4];
    }

    // Update is called once per frame
    void Update()
    {
        //outBuffer = Encoding.ASCII.GetBytes(myCube.transform.position.x.ToString());

        //Debug.Log("Sent X:" + myCube.transform.position.x);

        //if (currentPlayers[0].text != "Open Slot")
        //{
        //    if (isOpen == false)
        //    {
        //        RunClient();
        //        isOpen = true;
        //    }
            
        //    isInput = 1.0f;
        //}
        //else
        //{
        //    isInput = 0.0f;
        //    isOpen = false;
        //    if (client_socket != null)
        //        client_socket.Close();
        //}

        //if (isOpen == true)
        //{
        //    //pos = new float[] { myName.transform.position.x, myName.transform.position.y, myName.transform.position.z, isInput };

        //    //Debug.Log(pos[0].ToString());
        //    //Debug.Log(pos[1].ToString());
        //    //Debug.Log(pos[2].ToString());
        //    ////Debug.Log("isInput = " + pos[3].ToString());

        //    //Buffer.BlockCopy(pos, 0, bpos, 0, bpos.Length);


        //    //client_socket.SendTo(bpos, remoteEP);


        //    sname = new string[] { currentPlayers[0].text, currentPlayers[1].text, currentPlayers[2].text, currentPlayers[3].text };

        //    Debug.Log(currentPlayers[0].text.ToString());
        //    Debug.Log(currentPlayers[1].text.ToString());
        //    Debug.Log(currentPlayers[2].text.ToString());
        //    Debug.Log(currentPlayers[3].text.ToString());

        //    Buffer.BlockCopy(sname, 0, bname, 0, bname.Length);

        //    client_socket.SendTo(bname, remoteEP);

        //}
        sname = new string[] { currentPlayers[0].text, currentPlayers[1].text, currentPlayers[2].text, currentPlayers[3].text };

        Debug.Log(currentPlayers[0].text.ToString());
        Debug.Log(currentPlayers[1].text.ToString());
        Debug.Log(currentPlayers[2].text.ToString());
        Debug.Log(currentPlayers[3].text.ToString());

        Buffer.BlockCopy(sname, 0, bname, 0, bname.Length);

        client_socket.SendTo(bname, remoteEP);



    }
}
