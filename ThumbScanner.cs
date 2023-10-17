using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.IO;
namespace MultiFaceRec
{
             class ThumbScanner
        {
            public static string Help
            {
                get
                {
                    return "NF - No finger \n\r NM - No match \n\r MF$$$ - Match found $$$ refers to Person identity";
                }
            }

            public static string Register(string strPortName)
            {
                int Location = 0;
                if (File.Exists("identity.dat"))
                {
                    Location = int.Parse(File.ReadAllText("identity.dat").Trim());
                    Location++;
                }

                SerialPort port = new SerialPort();
                if (strPortName.StartsWith("COM"))
                    port.PortName = strPortName;
                else
                    port.PortName = "COM" + strPortName;
                port.BaudRate = 9600;
                port.Open();
                port.DiscardInBuffer();
                byte[] data = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x01, 0x00, 0x05 };
                //0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01,0x00, 0x04, 0x02, 0x01, 0x00, 0x08, 
                //0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x01, 0x00, 0x05, 
                //0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x04, 0x02, 0x02, 0x00, 0x09, 
                //0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x05, 0x00, 0x09, 
                //0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x06, 0x06, 0x02, 0x00, 0x00, 0x00, 0x10};

                port.Write(data, 0, 12);
                data = readAck(port);
                string replyCode = data[9].ToString();
                //0 , 12
                //13, 24
                // 25,37
                // 38, 49
                // 50 , 64

                int[] index = { 0, 12, 25, 37, 50, 62 };
                int[] count = { 12, 13, 12, 13, 12, 15 };

                if (replyCode != "2")
                {
                    System.Threading.Thread.Sleep(1000);
                    byte[] storeData = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x01, 0x00, 0x05,
                                    0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01,0x00, 0x04, 0x02, 0x01, 0x00, 0x08, 
                                    0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x01, 0x00, 0x05, 
                                    0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x04, 0x02, 0x02, 0x00, 0x09, 
                                    0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x05, 0x00, 0x09, 
                                    0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x06, 0x06, 0x02, 0x00, 0x00, 0x00, 0x0F};

                    storeData[74] = Convert.ToByte(Location);
                    int checkSum = 15 + Location;
                    storeData[76] = Convert.ToByte(checkSum);
                    for (int ndx = 0; ndx <= 3; ndx++)
                    {
                        port.Write(storeData, index[ndx], count[ndx]);
                        System.Threading.Thread.Sleep(900);
                    }
                    for (int ndx = 4; ndx <= 5; ndx++)
                    {
                        port.Write(storeData, index[ndx], count[ndx]);
                        System.Threading.Thread.Sleep(100);
                    }
                    StreamWriter writer = File.CreateText("identity.dat");
                    writer.WriteLine(Location.ToString());
                    writer.Close();
                    replyCode = Location.ToString();
                }
                else
                    replyCode = "NF";
                port.Close();
                return replyCode;
            }

            public static string Verify(string strPortName)
            {
                SerialPort port = new SerialPort();
                if (strPortName.StartsWith("COM"))
                    port.PortName = strPortName;
                else
                    port.PortName = "COM" + strPortName;

                port.BaudRate = 9600;
                port.Open();
                port.DiscardInBuffer();
                byte[] data = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x11, 0x00, 0x15 };
                port.Write(data, 0, data.Length);

                byte[] response = readAck(port);
                port.Close();
                if (response[11] == 2)
                    return "NF";
                else if (response[11] == 9)
                    return "NM";
                else
                    return "" + response[11];
            }


            private static byte[] readAck(SerialPort port)
            {
                byte[] acks = new byte[13];
                port.DiscardInBuffer();
                for (int i = 0; i <= 11; i++)
                    acks[i] = Convert.ToByte(port.ReadByte());


                return acks;
            }

            public static string ResetEntries(string strPortName)
            {
                SerialPort port = new SerialPort();
                if (strPortName.StartsWith("COM"))
                    port.PortName = strPortName;
                else
                    port.PortName = "COM" + strPortName;
                port.BaudRate = 9600;
                port.Open();
                port.DiscardInBuffer();
                byte[] data = { 0xEF, 0x01, 0xFF, 0xFF, 0xFF, 0xFF, 0x01, 0x00, 0x03, 0x0D, 0x00, 0x11 };
                port.Write(data, 0, 12);
                byte[] response = readAck(port);
                port.Close();
                return "" + response[1];
            }
        }
}
