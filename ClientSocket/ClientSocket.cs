using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using NAudio.Wave;
using System.Diagnostics.Tracing;

namespace ClientSocket
{
    public class ClientSocket
    {
        static int PortNumber = 58056;
        static IPHostEntry host = Dns.GetHostEntry("localhost");
        static IPAddress ipAddress = host.AddressList[0];
        static IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PortNumber);

        static Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        static WaveInEvent waveIn;
        static MemoryStream audioStream;

        //Console.WriteLine("Waiting for a connection...");
        Socket handler = listener.Accept();

        // Define a delegate for the callback
    


        public void StartClientAudio(int PortNumber)
        {



            while (true)
            {
                StartRecordAudio();


                try
                {
                    listener.Bind(localEndPoint);
                    listener.Listen(10);
                    byte[] bytes = new byte[1024];
                    // Receive audio data from the client
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                        while ((bytesRead = handler.Receive(buffer)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }

                        // Reset the stream position to the beginning
                        ms.Position = 0;

                        // Play the received audio
                        Console.WriteLine("Playing received audio...");
                        PlayAudio(ms);




                    }
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.Close();
                    listener.Dispose();



                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }




        }

        private static void PlayAudio(MemoryStream ms)
        {
            try
            {
                // Use WaveFileReader to read the audio from the MemoryStream
                using (WaveFileReader waveReader = new WaveFileReader(ms))
                {
                    using (WaveOutEvent waveOut = new WaveOutEvent())
                    {
                        waveOut.Init(waveReader);
                        waveOut.Play();
                        while (waveOut.PlaybackState == PlaybackState.Playing)
                        {
                            System.Threading.Thread.Sleep(100);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error playing audio: " + ex.Message);
            }
        }


        public static void StopRecordAndSendAudio(int PortNumber)
        {
            if (waveIn != null)
            {
                waveIn.StopRecording();
                waveIn.Dispose();
                waveIn = null;
            }

            if (audioStream != null)
            {
                byte[] audioData = audioStream.ToArray();
                byte[] wavData = CreateWavHeader(audioData);

                // Send the audio data to the specified port
                SendAudioData(wavData, PortNumber);

                audioStream.Dispose();
                audioStream = null; 

               
            }

            Console.WriteLine("Recording stopped and audio data sent.");
        }
        public static void StartRecordAudio()
        {


            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 1) // 44.1 kHz mono
            };

            audioStream = new MemoryStream();

            waveIn.DataAvailable += (s, e) =>
            {
                // Write audio data to the memory stream
                audioStream.Write(e.Buffer, 0, e.BytesRecorded);
            };

            waveIn.StartRecording();
            Console.WriteLine("Recording started...");


        }






        // Method to create WAV header and prepend it to the audio data
        private static byte[] CreateWavHeader(byte[] audioData)
        {
            int totalAudioLen = audioData.Length;
            int totalDataLen = totalAudioLen + 36;
            int channels = 1; // Mono
            int sampleRate = 44100; // 44.1 kHz
            int bitsPerSample = 16; // 16-bit audio

            using (MemoryStream ms = new MemoryStream())
            {
                using (BinaryWriter writer = new BinaryWriter(ms))
                {
                    writer.Write(Encoding.ASCII.GetBytes("RIFF"));
                    writer.Write(totalDataLen);
                    writer.Write(Encoding.ASCII.GetBytes("WAVE"));
                    writer.Write(Encoding.ASCII.GetBytes("fmt "));
                    writer.Write(16); // Subchunk1Size
                    writer.Write((short)1); // AudioFormat (PCM)
                    writer.Write((short)channels);
                    writer.Write(sampleRate);
                    writer.Write(sampleRate * channels * bitsPerSample / 8); // ByteRate
                    writer.Write((short)(channels * bitsPerSample / 8)); // BlockAlign
                    writer.Write((short)bitsPerSample); // BitsPerSample
                    writer.Write(Encoding.ASCII.GetBytes("data"));
                    writer.Write(totalAudioLen);

                    // Write the audio data
                    writer.Write(audioData);
                }

                return ms.ToArray();
            }
        }

        // Method to send audio data to the server
        public static  void SendAudioData(byte[] audioData, int PortNumber)
        {
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, PortNumber);

            using (Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
            {
                sender.Connect(remoteEP);

                Console.WriteLine("Connected to server. Sending audio data...");
                sender.Send(audioData);
                sender.Shutdown(SocketShutdown.Both);
                //sender.Disconnect(true);
                //sender.Dispose(); 
                sender.Close();
            }


        }

        public static void StartServer(int PortNumber)
        {
            // Get Host IP Address that is used to establish a connection
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1
            // If a host has multiple addresses, you will get a list of addresses
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, PortNumber);

            try
            {

                // Create a Socket that will use Tcp protocol
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                // A Socket must be associated with an endpoint using the Bind method
                listener.Bind(localEndPoint);

                // Specify how many requests a Socket can listen before it gives Server busy response.
                // We will listen 10 requests at a time
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection...");
                Socket handler = listener.Accept();

                // Incoming data from the client.
                string data = null;
                byte[] bytes = null;

                while (true)
                {
                    bytes = new byte[1024];
                    int bytesRec = handler.Receive(bytes);
                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                }

                Console.WriteLine("Text received : {0}", data);

                byte[] msg = Encoding.ASCII.GetBytes(data);
                handler.Send(msg);
                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }

        
        public class SocketClientt
        {


            public static void StartClient(int PortNumber)
            {
                byte[] bytes = new byte[1024];

                try
                {
                    // Connect to a Remote server
                    // Get Host IP Address that is used to establish a connection
                    // In this case, we get one IP address of localhost that is IP : 127.0.0.1
                    // If a host has multiple addresses, you will get a list of addresses
                    IPHostEntry host = Dns.GetHostEntry("localhost");
                    IPAddress ipAddress = host.AddressList[0];
                    IPEndPoint remoteEP = new IPEndPoint(ipAddress, PortNumber);

                    // Create a TCP/IP  socket.


                    while (true)
                    {
                        try
                        {
                            Socket sender = new Socket(ipAddress.AddressFamily,
                                SocketType.Stream, ProtocolType.Tcp);
                            // Connect to Remote EndPoint
                            sender.Connect(remoteEP);

                            Console.WriteLine("Socket connected to {0}",
                                sender.RemoteEndPoint.ToString());


                            //string mess = Console.ReadLine(); 
                            // Encode the data string into a byte array.
                            string mess = Console.ReadLine();
                            mess = mess + "<EOF>";
                            byte[] msg = Encoding.ASCII.GetBytes(mess);

                            // Send the data through the socket.
                            int bytesSent = sender.Send(msg);

                            // Receive the response from the remote device.
                            int bytesRec = sender.Receive(bytes);
                            Console.WriteLine("Echoed test = {0}",
                                Encoding.ASCII.GetString(bytes, 0, bytesRec));

                            // Release the socket.

                            sender.Shutdown(SocketShutdown.Both);
                            sender.Close();


                        }
                        catch (ArgumentNullException ane)
                        {
                            Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                        }
                        catch (SocketException se)
                        {
                            Console.WriteLine("SocketException : {0}", se.ToString());
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Unexpected exception : {0}", e.ToString());
                        }


                    }

                    // Connect the socket to the remote endpoint. Catch any errors.


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }








    public class Message
    {
        public int Id { get; set; }
        public string content { get; set; }

        public User sender { get; set; }
        public User receiver { get; set; }

    }
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> ReceivedMessages { get; set; }
        public List<string> SentMessages { get; set; }

        public User(string name)
        {
            this.Name = name;
            this.ReceivedMessages = new List<string>();
            this.SentMessages = new List<string>();

        }
        public void SendMessage(string message, User UserToReceiver)
        {
            this.SentMessages.Add(message);

            UserToReceiver.ReceivedMessages.Add(message);


        }

    }
    public class Client
    {
        static void DisplayConversation(User sender, User receiver)
        {
            Console.WriteLine(sender.Name + "        :   " + sender.SentMessages.Last());
            //Console.WriteLine(receiver.Name + "        :   " + receiver.ReceivedMessages.Last());

        }

        static User SelectSender(string userName)
        {
            switch (userName)
            {
                case "ahmed":
                    return new User("ahmed");
                case "soufi":
                    return new User("soufi");
                default:
                    return new User("soufi");

            }
        }
        static User SelectReceiver(User sender)
        {
            switch (sender.Name)
            {
                case "soufi":
                    return new User("ahmed");
                case "ahmed":
                    return new User("soufi");
                default:
                    return new User("soufi");

                    break;
            }
        }
        static void SwitchUsers(ref User sender, ref User receiver)
        {
            User inter = new User("inter");

            inter = sender;
            sender = receiver;
            receiver = inter;

        }




        // chatApp 

        /*.WriteLine("which user you are ");
        string userName = Console.ReadLine();

        string pause = ""; 

        while (true)
        {

            User sender = SelectSender(userName);
            User receiver = SelectReceiver(sender);

            Console.Write($"{sender.Name}  :  ");

            string message = Console.ReadLine();
            sender.SendMessage(message, receiver);


            //DisplayConversation(sender, receiver);

            Console.Write($"{receiver.Name}  :  ");
            SwitchUsers(ref sender , ref receiver);

             message = Console.ReadLine();
            sender.SendMessage(message, receiver);

            //DisplayConversation(sender, receiver);

            //pause = Console.ReadLine(); 
        }*/

        //Socket Using c# 

        //SocketClient.StartClient();

        //RecordAndSendAudio();


        //StartServerAudio(58056);






    }
}
