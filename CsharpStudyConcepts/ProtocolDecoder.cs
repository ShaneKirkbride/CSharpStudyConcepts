using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpStudyConcepts
{
    public interface IProtocolDecoder
    {
        string ProtocolName { get; }
        void Decode<T>(T[] data) where T: unmanaged;
    }

    public class UsbDecoder : IProtocolDecoder
    {
        private readonly string protocolName = "USB";

        public UsbDecoder()
        { 
        }

        public string ProtocolName { get { return protocolName; } }

        public void Decode<T>(T[] Data) where T : unmanaged
        {
            ReadOnlySpan<T> spanData = new ReadOnlySpan<T>(Data);

            foreach (var item in spanData)
            {
                Console.Write($" {item} ");
            }
            Console.WriteLine("");
            Console.WriteLine("Decoding Complete");
        }
    }

    internal class DecoderProcessor
    {
        private readonly IProtocolDecoder protocolDecoder;

        public DecoderProcessor(IProtocolDecoder protocolDecoder)
        {
            this.protocolDecoder = protocolDecoder;
        }

        public void Process(byte[] Data)
        {
            this.protocolDecoder.Decode(Data);
        }

    }
}
