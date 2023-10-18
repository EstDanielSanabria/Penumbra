using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

public class IpAddress : MonoBehaviour
{
    void Awake()
    {
        string ipv4Address = string.Empty;

        // Obtiene todas las interfaces de red disponibles
        NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();

        foreach (NetworkInterface networkInterface in networkInterfaces)
        {
            // Filtra las interfaces de red que est�n en funcionamiento
            if (networkInterface.OperationalStatus == OperationalStatus.Up)
            {
                // Obtiene las propiedades de configuraci�n de IP de la interfaz
                IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();

                foreach (UnicastIPAddressInformation ipInfo in ipProperties.UnicastAddresses)
                {
                    if (ipInfo.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipv4Address = ipInfo.Address.ToString();
                        break; // Det�n el bucle cuando se encuentre la primera direcci�n IPv4
                    }
                }
            }

            if (!string.IsNullOrEmpty(ipv4Address))
            {
                break; // Det�n el bucle si ya se ha encontrado una direcci�n IPv4
            }
        }

        OptitrackStreamingClient optitrackStramingClient = GameObject.Find("TrackSystem").GetComponent<OptitrackStreamingClient>();
        if (optitrackStramingClient != null)
            optitrackStramingClient.LocalAddress = ipv4Address;
    }
}
