# IMV-interchange Message voal app 

**Description**: 

> _"This application enables real-time audio communication over a local network, utilizing a custom client-server architecture developed in C# with .NET Framework. It demonstrates
> network programming, multithreading, and asynchronous communication using WEB SOCKETS "_

## Table of Contents

- [Features](#features)
- [Setup](#setup)
- [Usage](#usage)
- [Technologies](#technologies)
- [Architecture](#architecture)
- [Demo](#demo)
- [Future Improvements](#future-improvements)
- [Contact](#contact)

## Features
- **Real-time Audio Streaming**: Supports live audio transmission between server and clients.
- **Asynchronous Programming**: Utilizes `async` and `await` for efficient data handling.
- **Modular Design**: Built with a clear separation of data and UI layers for easy maintainability and scalability.

## Application Highlights

- **Real-Time Communication**: Facilitates real-time audio communication between client and server, showcasing efficient networked audio transmission.
- **Cross-Platform Testing**: The dual-port form simulation allows you to test and demonstrate client-server interactions in a single application, making debugging and testing easier and more flexible.
- **User-Friendly Interface**: The form-based UI enables straightforward control of recording and playback features, making it easy to manage audio data flow between client and server.
- **Scalable Design**: This architecture can be extended to multiple clients or adapted for larger, more complex audio or data streaming applications.
- **Enhanced UI Responsiveness**: By implementing asynchronous programming and proper cross-thread handling, this app maintains a smooth and responsive interface even during intensive audio data transmission tasks.
- **Practical Skill Demonstration**: This app highlights skills in socket programming, asynchronous operations, and client-server architecture, demonstrating a deep understanding of real-time application development in C#.

## Setup
1. **Clone the repository**: `git clone [https://github.com/yourusername/project-name](https://github.com/soufi-43/IMV-Interchange_Message_Vocal-App.git).git`
2. **Install dependencies** : Naudio 
3. **Compile and Run**:.NET framework 4.8 `.

## Usage


For testing, a form is provided to simulate the interaction between the server and client. In this form, two separate listeners are set up on different ports to simulate a real 
application, with one acting as the server and the other as the client.


1. **Run the Server:**  
   Start the server application, which will listen for incoming connections on a designated port.

2. **Run the Client:**  
   Start the client application on a different port to connect to the server. The simulated form in this repository enables testing of the server-client communication within a single application instance.

3. **Record Audio:**
   - Click the "Start Recording" button to begin recording audio on either the server or client.
   - Click "Stop Recording" to end the recording and automatically send the audio to the other side.

4. **Playback Audio:**
   - The client or server will automatically play the received audio after it is sent from the other side.

## Technologies : 
- **C# (.NET Framework)**
- **NAudio for Audio Processing**
- **Socket Programming** for client-server communication

### Architecture

The application architecture consists of a **Client-Server Model** designed to enable real-time audio communication. Below is a breakdown of each component and their interactions:

1. **Client Application**
   - Establishes a connection with the server on a designated port.
   - Records audio data and sends it to the server upon stopping the recording.
   - Receives audio data from the server and plays it back automatically.

2. **Server Application**
   - Listens for incoming connections on a specific port.
   - Receives audio data from the client, stores it temporarily, and plays it back automatically.
   - Sends recorded audio data back to the client when recording is stopped on the server side.

3. **Simulated Form**
   - Provides a user interface to control both client and server within a single application instance.
   - Uses two separate listening ports to simulate real client-server interaction, allowing the form to act as both client and server for testing purposes.

4. **Audio Communication Workflow**
   - **Recording**: Audio is recorded on the client or server and stored in memory.
   - **Data Transmission**: Once recording is stopped, the audio data is sent over a socket connection to the other side.
   - **Playback**: The receiving side plays the audio immediately upon receiving it, completing the real-time communication cycle.

5. **Error Handling and UI Responsiveness**
   - Implements cross-thread communication handling to ensure UI components are updated smoothly without causing thread conflicts.
   - Uses asynchronous programming to avoid blocking the UI thread during network communication, providing a responsive user experience.

The design enables seamless two-way audio communication, with a robust UI to simulate the client-server interaction within the same application for testing and demonstration purposes.


## Demo
![Screenshot](IMV(Interchange_Message_Vocal)App/Resources/demo.png)

## Future Improvements
- **Enhanced UI/UX**
- **Higher Scalability with WebSocket Support**
- **Error Reporting and Logging**

## Security and Privacy

- **Local Network Compatibility**: Operates within a local network, ensuring that audio data does not traverse public networks, which enhances security and control over data flow.
- **Data Privacy**: By keeping communication within a closed network, sensitive information remains protected from external access.
- **Potential for Security Enhancements**: Can be extended with additional security features, such as encryption, to safeguard audio transmissions against unauthorized interception.


## Contact

Feel free to reach out:

- **Email**: [soufi-43@hotmail.fr]
