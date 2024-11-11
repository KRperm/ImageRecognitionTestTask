using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace ImageRecognitionTestTask
{
    public class ServerViewModel
    {
        public virtual int Port { get; set; }

        private TcpListener _listener;

        public async Task StartServerAsync()
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            
            try
            {
                _listener.Start();

                using var handler = await _listener.AcceptSocketAsync();

                var inputBuffer = new byte[1024];
                var size = await handler.ReceiveAsync(inputBuffer);
                var clientMessage = Encoding.ASCII.GetString(inputBuffer, 0, size);

                var response = $"SERVER ECHO: {clientMessage}";
                var outputBuffer = Encoding.ASCII.GetBytes(response);
                await handler.SendAsync(outputBuffer);
            }
            finally
            {
                _listener.Stop();
            }
        }

        public bool CanStartServer()
        {
            return true;
        }
    }
}
