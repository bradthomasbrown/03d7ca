using K32 = Kernel32            ;
using Res = _03d7ca_.Response   ;
using Tx  = _03d7ca_.Transaction;

namespace                  _03d7ca_   {
partial class              C          {
unsafe public static bool  _e9b6ec_(
 ulong _tx
)                                     {


Mallocator.C m = new Mallocator.C(protect:K32.C.MemoryProtectionConstants.PAGE_READWRITE);
ulong prog = m.AllocByteString(

 "  48    8b 31           "// 00: mov rsi,QWORD PTR [rcx]
+"  48    8b 79    08     "// 03: mov rdi,QWORD PTR [rcx+0x8]
+"        31 c0           "// 07: xor eax,eax
+"     0f b7 0e           "// 09: movzx cx,WORD PTR [rsi]
+"  48    8b 76    02     "// 0c: mov rsi,QWORD PTR [rsi+0x2]
+"        e3       18     "// 10: jrcxz 0x2a
+"  48    c1 ea       08  "// 12: shr rdx,0x8
+"        a8          07  "// 16: test al,0x7
+"        75       06     "// 18: jnz 0x20
+"  48 0f c7 f2           "// 1a: rdrand rdx
+"        73       07     "// 1e: jnc 0x27
+"        88 14 06        "// 20: mov BYTE PTR [rsi+rax*1],dl
+"        ff c0           "// 23: inc eax
+"        e2       eb     "// 25: loop 0x12
+"  66    89 4f    01     "// 27: mov DWORD PTR [rdi+0x1],ecx
+"        83 f9       00  "// 2a: cmp ecx,0x0
+"     0f 9e 07           "// 2d: setge BYTE PTR [rdi]
+"        c3              "// 30: ret

);
m.ChangeProtection(protect:Kernel32.C.MemoryProtectionConstants.PAGE_EXECUTE_READ);
Ntdll.NtQueueApcThreadEx2.C.M(apcRoutine:prog, arg0:_tx);
m.Free();
return (*(Res.S*)(*(Tx.S*)_tx).Response).Completed;


} } }