using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using EasySteamSockets.Classes.Payloads;
using EasySteamSocketsExample.Payloads.BytePayloads;
using EasySteamSocketsExample.Payloads.JSONPayloads;

namespace SteamSockets.Tests
{
    public class MessageSerialisationTests
    {
        [Fact]
        public void GivenBytePayload_GetSamePayloadBack()
        {
            // Arrange
            
            EasySteamSockets.Initialiser.Initialise(Assembly.GetAssembly(typeof(PlayerPositionUpdateMessage)));

            PlayerPositionUpdateMessage payloadBeingSent = new()
            {
                Id = 200,
                X = 100f,
                Y = 10.2f,
            };

            byte[] bytes = payloadBeingSent.GetByteArray();

            (IntPtr intPtr, int size) = ConvertFromByteArray(bytes);

            // Act

            AbstractPayload? response;

            try
            {
                response = Deserialiser.IntPtrToPayload(intPtr, size);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            // Assert

            response.Should().NotBeNull();

            response.Should().BeEquivalentTo(payloadBeingSent);
        }

        [Fact]
        public void GivenJSONPayload_GetSamePayloadBack()
        {
            // Arrange

            EasySteamSockets.Initialiser.Initialise(Assembly.GetAssembly(typeof(ChatMessage)));

            ChatMessage payloadBeingSent = new()
            {
                Message = "hello world",
                ColourARGB = Color.Red.ToArgb(),
            };

            byte[] bytes = payloadBeingSent.GetByteArray();

            (IntPtr intPtr, int size) = ConvertFromByteArray(bytes);

            // Act

            AbstractPayload? response;

            try
            {
                response = Deserialiser.IntPtrToPayload(intPtr, size);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            // Assert

            response.Should().NotBeNull();

            response.Should().BeEquivalentTo(payloadBeingSent);
        }

        [Fact]
        public void GivenEmptyJSONPayload_GetSamePayloadBack()
        {
            // Arrange

            EasySteamSockets.Initialiser.Initialise(Assembly.GetAssembly(typeof(EmptyMessage)));

            EmptyMessage payloadBeingSent = new()
            {

            };

            byte[] bytes = payloadBeingSent.GetByteArray();

            (IntPtr intPtr, int size) = ConvertFromByteArray(bytes);

            // Act

            AbstractPayload? response;

            try
            {
                response = Deserialiser.IntPtrToPayload(intPtr, size);
            }
            finally
            {
                Marshal.FreeHGlobal(intPtr);
            }

            // Assert

            response.Should().NotBeNull();

            response.GetType().Should().BeSameAs(payloadBeingSent.GetType());
        }

        private static (IntPtr intPtr, int size) ConvertFromByteArray(byte[] arrayToConvert)
        {
            int size = arrayToConvert.Length;
            IntPtr intPtr = Marshal.AllocHGlobal(size);

            Marshal.Copy(arrayToConvert, 0, intPtr, size);

            return (intPtr, size);
        }
    }
}