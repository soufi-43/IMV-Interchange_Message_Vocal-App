using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NAudio.Wave;
using System.Threading;
using System.Runtime.InteropServices;


  



    namespace ServerSocket
    {
    public class ServerSocket
    {
        public  enum enPortNum { server = 11000 ,client = 58056 }
        //static int PortNumber = 11000;
        

        public static event Action RecordingStopped;



        public static void RecordAndSendAudio(int PortNumber)
        {


            using (WaveInEvent waveIn = new WaveInEvent())
            {
                waveIn.WaveFormat = new WaveFormat(44100, 1); // 44.1 kHz mono

                using (MemoryStream audioStream = new MemoryStream())
                {
                    waveIn.DataAvailable += (s, e) =>
                    {
                        // Write audio data to the memory stream
                        audioStream.Write(e.Buffer, 0, e.BytesRecorded);
                    };

                    waveIn.StartRecording();
                    Console.WriteLine("Recording audio... Press Enter to stop.");

                    // Wait for the user to stop recording
                    Console.ReadLine();
                    waveIn.StopRecording();

                    byte[] audioData = audioStream.ToArray();
                    byte[] wavData = CreateWavHeader(audioData);
                    SendAudioData(wavData, PortNumber);


                    //PlayAudioo(audioData);

                }
            }


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
        public static void SendAudioData(byte[] audioData, int PortNumber)
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
                sender.Close();
            }
        }

        // Make sure to add this using directive

        public static void DisposeListening()
        {
           // listener.Dispose();
        }

        public void ReceiveAndPlayAudio()
        {
            while (true)
            {
                try
                {


                    // Receive audio data from the client
                    using (MemoryStream ms = new MemoryStream())
                    {
                        byte[] buffer = new byte[1024];
                        int bytesRead;
                       /* while ((bytesRead = handler.Receive(buffer)) > 0)
                        {
                            ms.Write(buffer, 0, bytesRead);
                        }

                        // Reset the stream position to the beginning
                        ms.Position = 0;

                        // Play the received audio
                        Console.WriteLine("Playing received audio...");

                        //handler.Shutdown(SocketShutdown.Both);
                        //handler.Close();
                        listener.Dispose();

                        PlayAudio(ms);

                        //Thread.Sleep(5000); 
                        RecordAndSendAudio(58056);*/



                    }




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
        public static  void StartServerAudio(enPortNum PortNumber)
        {
             IPHostEntry host = Dns.GetHostEntry("localhost");
             IPAddress ipAddress = host.AddressList[0];
             IPEndPoint localEndPoint = new IPEndPoint(ipAddress, (int)PortNumber);

             Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
             Socket handler;

            listener.Bind(localEndPoint);
            listener.Listen(10);
            handler = listener.Accept();

            Console.WriteLine("Waiting for a connection...");
            //Socket handler = listener.Accept();
            byte[] bytes = new byte[1024];
          
            Task task = Task.Run(() =>
            {
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

                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.Close();
                    listener.Dispose();

                    PlayAudio(ms);


                }
                

            }) ;


            task.Wait();

            RecordingStopped?.Invoke();

            //Thread.Sleep(5000); 
            // RecordAndSendAudio(58056);

        }



        // Method to record and send audio

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



                // Incoming data from the client.


                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();

                    string data = null;
                    byte[] bytes = null;


                    bytes = new byte[1024];

                    while (true)
                    {
                        int bytesRec = handler.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            break;
                        }


                    }
                    Console.WriteLine("SERVER SIDE LISTENING ...... ");

                    Console.WriteLine("Text received : {0}", data);

                    byte[] msg = Encoding.ASCII.GetBytes(data);
                    handler.Send(msg);
                    handler.Shutdown(SocketShutdown.Both);
                    handler.Close();
                    //handler.Disconnect(true); 

                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }


        }

        static int GetFreePort()
        {
            // Use TcpListener to find a free port
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();

            return port;
        }


        //StartServerAudio(11000);



        //Console.WriteLine(GetFreePort()); 

    }
}



