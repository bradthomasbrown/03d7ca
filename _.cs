using System.Runtime.InteropServices;

class _212a3cbcd7bb3b0147570e48665a1ee7_ {

 [StructLayout(LayoutKind.Explicit)]
 public struct RandResult {
  [FieldOffset(0x00)]public bool   Completed   ;
  [FieldOffset(0x08)]public ushort BytesWritten;
  [FieldOffset(0x10)]public byte[] Rand        ;
  public static RandResult SatisfyingByteCount(uint byteCount) {
   return new RandResult {
    Completed    = false              ,
    BytesWritten = 0                  ,
    Rand         = new byte[byteCount]
   };
  }
  public static RandResult SatisfyingBitCount(uint bitCount) {
   ushort byteCount = (ushort)(Algorithms._6bf6a89cbe4e9246643cece419fbb1ac_((ulong)bitCount, (ulong)8)>>3);
   return RandResult.SatisfyingByteCount(byteCount);
  }
 };

 unsafe public static RandResult Rand(uint bitCount) {
  ulong mem = Kernel32.VirtualAlloc(protect:Kernel32.MemoryProtectionConstants.PAGE_EXECUTE_READWRITE);
  int i = 0; foreach (byte b in new byte[] {
//  REX   E0F   OP1   OP2   MOD   SIB   DIS   IMM
//   02    03    0b    0c    15    16    17    19
   0x4c,       0x89,       0xc6,                      // 00: mov rsi,r8
   0x48,       0x89,       0xcd,                      // 03: mov rbp,rcx
               0x31,       0xc0,                      // 06: xor eax,eax
               0xfe,       0x02,                      // 08: inc BYTE PTR [rdx]
   0x48,       0xc1,       0xe9,             0x08,    // 0a: shr rcx,0x8
               0xa8,                         0x07,    // 0e: test al,0x7
               0x75,                   0x0b,          // 10: jnz 0x1a
   0x48, 0x0f,       0xc7, 0xf1,                      // 12: rdrand rcx
         0x0f,       0x92, 0xc3,                      // 16: setc bl
               0x20,       0x1a,                      // 19: and BYTE PTR [rdx],bl
               0x74,                   0x0c,          // 1b: jz 0x29
               0x88,       0x0c, 0x06,                // 1d: mov BYTE PTR [rsi+rax*1],cl
   0x48,       0xff,       0xc0,                      // 20: inc rax
   0x48,       0x83,       0xed,       0x08,          // 23: sub rbp,0x8
               0x77,                   0xe1,          // 27: ja 0xa
   0x48,       0x89,       0x44, 0x22, 0x08,          // 29: mov QWORD PTR [rdx+riz*1+0x8],rax
               0xc3                                   // 2e: ret
  }) { *(byte*)(mem+(ulong)i) = b; i++; }
  RandResult res = RandResult.SatisfyingBitCount(bitCount);
  fixed (byte* b = res.Rand)
   Ntdll.NtQueueApcThreadEx2(
    apcRoutine : mem,
    arg0       : bitCount,
    arg1       : (ulong)&res.Completed,
    arg2       : (ulong)b
   );
  Kernel32.VirtualFree(mem);
  return res;
 }

}