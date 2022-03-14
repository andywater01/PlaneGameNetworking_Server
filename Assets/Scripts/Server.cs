using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using TMPro;


public class Server : MonoBehaviour
{

    private GameObject myCube;
    private static byte[] buffer = new byte[512];
    private static Socket server;
    private static IPEndPoint client;
    private static EndPoint remoteClient;
    private static int rec = 0;
    private float posx;

    public TMP_InputField myName;
    public string playerName;
    public TMP_Text[] currentPlayers;

    //Lecture 5
    private float[] pos;

    public static void RunServer()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        IPAddress ip = IPAddress.Parse("127.0.0.1");
        Debug.Log("Server name: " + host.HostName + "   IP:" + ip);
        IPEndPoint localEP = new IPEndPoint(ip, 11111);

        server = new Socket(ip.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
        client = new IPEndPoint(IPAddress.Any, 0);

        remoteClient = (EndPoint)client;
        server.Bind(localEP);

        Debug.Log("Waiting for data...");

    }


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



    // Start is called before the first frame update
    void Start()
    {
        //myCube = GameObject.Find("Cube");
        RunServer();

        //Lecture 5
        //Non-blocking mode
        server.Blocking = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            
            rec = server.ReceiveFrom(buffer, ref remoteClient);
            
        }
        catch (SocketException e)
        {
            Debug.Log("Exception: " + e.ToString());
        }

        //posx = float.Parse(Encoding.ASCII.GetString(buffer, 0, rec));
        //Debug.Log("PosX: " + posx);

        // This is how you update the Server side cube's position

        //Lecture 5
        pos = new float[rec / 4];
        Buffer.BlockCopy(buffer, 0, pos, 0, rec);

        Debug.Log(pos[0].ToString());
        //Debug.Log(pos[0].ToString());
        //Debug.Log(pos[1].ToString());
        //Debug.Log(pos[2].ToString());

        //currentPlayers[1].text = pos[1].ToString();

        //if (pos[3] == 1.0f)
        //    myCube.transform.position = new Vector3(pos[0], pos[1], pos[2]);


    }
}
