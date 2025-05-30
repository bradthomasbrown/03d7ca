using K32 = Kernel32            ;
using Req = _03d7ca_.Request    ;
using Res = _03d7ca_.Response   ;
using Tx  = _03d7ca_.Transaction;

using System;
class _ {
unsafe public static void Main() {


Mallocator.C m = new Mallocator.C(protect:K32.C.MemoryProtectionConstants.PAGE_READWRITE);

ulong _req = m.Alloc(Req.C.Size);
Console.WriteLine("_req: {0:X16}", _req);
*(ushort*)(_req+0) = 16;
*(ulong *)(_req+2) = m.Alloc(16);
Req.S req = *(Req.S*)_req;
Console.WriteLine("Request.ByteCount: {0:X4}", req.ByteCount);
Console.WriteLine("Request.Buffer: {0:X16}", req.Buffer);

ulong _res = m.Alloc(Res.C.Size);
Console.WriteLine("_res: {0:X16}", _res);

ulong _tx = m.Alloc(Tx.C.Size);
Console.WriteLine("_tx: {0:X16}", _tx);
*(ulong*)(_tx+0) = _req;
*(ulong*)(_tx+8) = _res;
_03d7ca_.Transaction.S tx = *(Tx.S*)_tx;
Console.WriteLine("Transaction.Request: {0:X16}", _req);
Console.WriteLine("Transaction.Response: {0:X16}", _res);

Console.WriteLine("`_03d7ca_.C._e9b6ec_(_tx);`");
_03d7ca_.C._e9b6ec_(_tx);

_03d7ca_.Response.S res = *(Res.S*)_res;
Console.WriteLine("Response.Completed: {0:X8}", res.Completed);
Console.WriteLine("Response.BytesLeft: {0:X4}", res.BytesLeft);
Console.WriteLine("Request.Buffer:");

for (int i = 0; i < 16; i++) Console.Write("{0:X2}{1}", *(byte*)(req.Buffer+(ulong)i), (i+1)%16==0?'\n':' ');


} }