using System.IO;
using System;

namespace CodareLZ
{
    class BitReader : IDisposable
    {
        private FileStream stream;
        private byte buffer;
        private int contorBiti = 0;
        private BinaryReader binaryReader;

        public BitReader(string fileName)
        {
            this.stream = new FileStream(fileName, FileMode.OpenOrCreate);
            this.binaryReader = new BinaryReader(stream);
        }

        private bool IsBufferEmpty()
        {
            if(contorBiti == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public byte ReadBit()
        {
            byte result = 0;

            if(IsBufferEmpty())
            {
                buffer = binaryReader.ReadByte();
                contorBiti = 8;
            }

            result = (byte)(0x80 & buffer); // 0000.0001
            result = (byte)(result >> 7);
            buffer = (byte)(buffer << 1);
            contorBiti--;
            
            return result;
        }

        public int ReadNBits(int NrDeBiti)
        {
            int result = 0;

            for(int i = 0; i < NrDeBiti; i++)
            {
                result = (int)result << 1;
                result = (int)result | ReadBit();
            }
            
            return result;
        }

        public void InchideFisier()
        {
            binaryReader.Close();
        }

        public void Dispose()
        {
            binaryReader.Dispose();
        }
    }
}
