using System.Runtime.InteropServices;

namespace _03d7ca_ {
namespace Request {

[StructLayout(LayoutKind.Explicit)]
public struct S {
 [FieldOffset(0)] public ushort ByteCount;
 [FieldOffset(2)] public ulong  Buffer   ;
}

} }