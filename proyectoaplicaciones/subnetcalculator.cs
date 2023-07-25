// SubnetCalculator.cs
using System;
using System.Collections.Generic;
using System.Net;

namespace proyectoaplicaciones.Utils
{
    public static class SubnetCalculator
    {
        public static List<SubnetResult> CalculateVLSM(string ipAddressString, List<int> hostsNeededPerSubnet)
        {
            if (IPAddress.TryParse(ipAddressString, out IPAddress ipAddress))
            {
                List<SubnetResult> subnetResults = new List<SubnetResult>();
                uint ipAsUint = IpToUint(ipAddress);

                // Ordenar las subredes necesitadas en orden descendente
                hostsNeededPerSubnet.Sort((x, y) => -x.CompareTo(y));

                foreach (var hostsNeeded in hostsNeededPerSubnet)
                {
                    int subnetMask = CalculateSubnetMask(hostsNeeded);
                    uint subnetSize = 1u << (32 - subnetMask);
                    uint networkAddress = ipAsUint & (0xFFFFFFFF << (32 - subnetMask));

                    subnetResults.Add(new SubnetResult
                    {
                        NetworkAddress = UintToIp(networkAddress),
                        SubnetMask = subnetMask,
                        SubnetSize = subnetSize,
                        HostsNeeded = hostsNeeded
                    });

                    ipAsUint += subnetSize;
                }

                return subnetResults;
            }

            return null;
        }

        private static uint IpToUint(IPAddress ipAddress)
        {
            byte[] bytes = ipAddress.GetAddressBytes();
            return (uint)(bytes[0] << 24 | bytes[1] << 16 | bytes[2] << 8 | bytes[3]);
        }

        private static IPAddress UintToIp(uint ipAsUint)
        {
            byte[] bytes = BitConverter.GetBytes(ipAsUint);
            Array.Reverse(bytes); // Convertir de big-endian a little-endian
            return new IPAddress(bytes);
        }

        private static int CalculateSubnetMask(int hostsNeeded)
        {
            // Calcular el tamaño de la subred necesario para los hosts
            int subnetMaskBits = 32 - (int)Math.Ceiling(Math.Log(hostsNeeded + 2, 2));
            return subnetMaskBits;
        }
    }

    public class SubnetResult
    {
        public IPAddress NetworkAddress { get; set; }
        public int SubnetMask { get; set; }
        public uint SubnetSize { get; set; }
        public int HostsNeeded { get; set; }
    }
}


