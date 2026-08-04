using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace OSEP_2026
{
    public static class PEHelper
    {
        public static System.Collections.Generic.List<string> GetExportedFunctions(string dllPath)
        {
            if (System.String.IsNullOrWhiteSpace(dllPath))
            {
                throw new System.ArgumentException("DLL path cannot be empty.", "dllPath");
            }

            if (!System.IO.File.Exists(dllPath))
            {
                throw new System.IO.FileNotFoundException("The specified DLL could not be found.", dllPath);
            }

            System.Collections.Generic.List<string> exports = new System.Collections.Generic.List<string>();

            System.IO.FileStream fileStream = null;
            System.Reflection.PortableExecutable.PEReader peReader = null;
            System.IO.BinaryReader binaryReader = null;

            try
            {
                fileStream = new System.IO.FileStream(
                    dllPath,
                    System.IO.FileMode.Open,
                    System.IO.FileAccess.Read,
                    System.IO.FileShare.ReadWrite);

                peReader = new System.Reflection.PortableExecutable.PEReader(
                    fileStream,
                    System.Reflection.PortableExecutable.PEStreamOptions.LeaveOpen);

                System.Reflection.PortableExecutable.PEHeaders headers = peReader.PEHeaders;
                System.Reflection.PortableExecutable.PEHeader peHeader = headers.PEHeader;

                if (peHeader == null)
                {
                    throw new System.IO.InvalidDataException("The file does not contain a valid PE header.");
                }

                System.Reflection.PortableExecutable.DirectoryEntry exportDirectory = peHeader.ExportTableDirectory;

                if (exportDirectory.RelativeVirtualAddress == 0 || exportDirectory.Size == 0)
                {
                    return exports;
                }

                binaryReader = new System.IO.BinaryReader(
                    fileStream,
                    System.Text.Encoding.ASCII,
                    true);

                long exportDirectoryOffset = RvaToFileOffset(
                    exportDirectory.RelativeVirtualAddress,
                    headers.SectionHeaders);

                fileStream.Position = exportDirectoryOffset;

                // IMAGE_EXPORT_DIRECTORY
                binaryReader.ReadUInt32(); // Characteristics
                binaryReader.ReadUInt32(); // TimeDateStamp
                binaryReader.ReadUInt16(); // MajorVersion
                binaryReader.ReadUInt16(); // MinorVersion
                binaryReader.ReadUInt32(); // Name RVA
                binaryReader.ReadUInt32(); // Ordinal Base
                binaryReader.ReadUInt32(); // NumberOfFunctions

                uint numberOfNames = binaryReader.ReadUInt32();

                binaryReader.ReadUInt32(); // AddressOfFunctions

                uint addressOfNamesRva = binaryReader.ReadUInt32();

                binaryReader.ReadUInt32(); // AddressOfNameOrdinals

                long namesTableOffset = RvaToFileOffset(
                    (int)addressOfNamesRva,
                    headers.SectionHeaders);

                for (uint index = 0; index < numberOfNames; index++)
                {
                    long nameRvaEntryOffset = namesTableOffset + (index * 4);

                    ValidateFileOffset(
                        nameRvaEntryOffset,
                        sizeof(uint),
                        fileStream.Length);

                    fileStream.Position = nameRvaEntryOffset;

                    uint functionNameRva = binaryReader.ReadUInt32();

                    long functionNameOffset = RvaToFileOffset(
                        (int)functionNameRva,
                        headers.SectionHeaders);

                    ValidateFileOffset(
                        functionNameOffset,
                        1,
                        fileStream.Length);

                    fileStream.Position = functionNameOffset;

                    string functionName = ReadNullTerminatedAsciiString(binaryReader);

                    if (!System.String.IsNullOrEmpty(functionName))
                    {
                        exports.Add(functionName);
                    }
                }

                return exports;
            }
            finally
            {
                if (binaryReader != null)
                {
                    binaryReader.Dispose();
                }

                if (peReader != null)
                {
                    peReader.Dispose();
                }

                if (fileStream != null)
                {
                    fileStream.Dispose();
                }
            }
        }

        private static long RvaToFileOffset(int rva, System.Collections.Immutable.ImmutableArray<System.Reflection.PortableExecutable.SectionHeader> sectionHeaders)
        {
            if (rva < 0)
            {
                throw new System.IO.InvalidDataException("The RVA cannot be negative.");
            }

            for (int index = 0; index < sectionHeaders.Length; index++)
            {
                System.Reflection.PortableExecutable.SectionHeader section = sectionHeaders[index];

                int sectionSize = System.Math.Max(
                    section.VirtualSize,
                    section.SizeOfRawData);

                long sectionStart = section.VirtualAddress;
                long sectionEnd = sectionStart + sectionSize;

                if (rva >= sectionStart && rva < sectionEnd)
                {
                    return section.PointerToRawData + (rva - section.VirtualAddress);
                }
            }

            return -1;
            //throw new System.IO.InvalidDataException(
            //    "Could not map RVA 0x" + rva.ToString("X8") + " to a file offset.");
        }

        private static string ReadNullTerminatedAsciiString(System.IO.BinaryReader binaryReader)
        {
            System.Collections.Generic.List<byte> bytes = new System.Collections.Generic.List<byte>();

            while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
            {
                byte value = binaryReader.ReadByte();

                if (value == 0)
                {
                    break;
                }

                bytes.Add(value);
            }

            return System.Text.Encoding.ASCII.GetString(bytes.ToArray());
        }

        private static void ValidateFileOffset(long offset, long requiredBytes, long fileLength)
        {
            if (offset < 0 || requiredBytes < 0 || offset > fileLength - requiredBytes)
            {
                throw new System.IO.InvalidDataException("The PE file contains an invalid file offset.");
            }
        }


    }
}