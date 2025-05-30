# Project 03d7ca

A C# cryptographic random number generation library that uses hardware-based random number generation (RDRAND instruction) through low-level x86_64 execution.

## Overview

This project implements a cryptographic random number generator that:
- Uses the x86_64 RDRAND instruction for hardware-based entropy
- Executes x86_64 code through dynamically allocated executable memory
- Provides a transaction-based interface for random byte generation
- Includes request/response structures for managing random data operations

## Architecture

### Core Components

- **C/methods/C/**: Main implementation containing x86_64 code for RDRAND-based random generation
- **Request/**: Data structures for random number generation requests
- **Response/**: Data structures for operation completion status  
- **Transaction/**: Container structures linking requests and responses
- **tests/**: Test implementations demonstrating usage

### Key Files

- `C/methods/C/_.cs`: Core random generation logic with inline x86-64
- `Request/S/_.cs`: Request structure defining byte count and buffer pointer
- `Response/S/_.cs`: Response structure with completion status and remaining bytes
- `Transaction/S/_.cs`: Transaction structure linking request and response pointers
- `tests/C/methods/e9b6ec/_.cs`: Test demonstrating the random generation workflow

## How It Works

1. **Memory Allocation**: Uses `Mallocator.C` to allocate executable memory pages
2. **x86_64 Injection**: Injects x86-64 that uses RDRAND instruction
3. **Transaction Processing**: Processes requests through a transaction structure
4. **Random Generation**: Generates random bytes using hardware entropy source
5. **Status Reporting**: Returns completion status and bytes remaining

## Usage Example

```csharp
// Allocate request, response, and transaction structures
ulong _req = m.Alloc(Req.C.Size);
ulong _res = m.Alloc(Res.C.Size);
ulong _tx = m.Alloc(Tx.C.Size);

// Configure request for 16 random bytes
*(ushort*)(_req+0) = 16;
*(ulong *)(_req+2) = m.Alloc(16);

// Link request and response in transaction
*(ulong*)(_tx+0) = _req;
*(ulong*)(_tx+8) = _res;

// Execute random generation
_03d7ca_.C._e9b6ec_(_tx);

// Check results
_03d7ca_.Response.S res = *(Res.S*)_res;
Console.WriteLine("Completed: {0}", res.Completed);
```

## Security Notes

This implementation uses low-level memory management and x86_64 execution. It should only be used in trusted environments where code injection protections are appropriate for the use case.

## Dependencies

- Kernel32 API for memory management
- Ntdll for thread APC queuing
- Mallocator utility for memory allocation
- Hardware support for RDRAND instruction