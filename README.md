# Random Number Generator Module

This directory contains a low-level random number generator implementation using the Intel RDRAND instruction.

## Contents

- `_.cs` - Random number generator with hardware-accelerated cryptographic randomness

## Implementation Details

The module provides a `RandResult` structure and `Rand()` method that:

- Uses Intel's RDRAND instruction for hardware-based random number generation
- Allocates executable memory and injects x64 assembly code at runtime
- Leverages Windows NT APIs (`NtQueueApcThreadEx2`) for asynchronous execution
- Supports both bit-count and byte-count based random data generation

### Key Features

- **Hardware randomness** via RDRAND instruction
- **Dynamic code generation** with executable memory allocation
- **Asynchronous execution** using APC (Asynchronous Procedure Call) queuing
- **Memory management** with VirtualAlloc/VirtualFree

The implementation demonstrates advanced techniques including runtime assembly injection, unsafe memory operations, and low-level Windows API integration.