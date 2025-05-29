# Windows Systems Programming Library

A comprehensive C# interop library providing low-level access to Windows APIs, graphics programming, and system internals.

## Overview

This project is a collection of C# wrappers and utilities for:
- **Windows API functions** (Kernel32, Ntdll, User32)
- **Vulkan graphics programming**
- **PE (Portable Executable) file parsing**
- **Low-level memory management**
- **Process Environment Block (PEB) manipulation**

## Main Components

### Memory Management
- **Mallocator** - Custom memory allocator using VirtualAlloc/VirtualFree
- **Kernel32/VirtualAlloc** - Windows memory allocation APIs with allocation types, protection constants, and page granularity

### Windows NT APIs
- **Ntdll** - Native NT API wrappers including:
  - `NtCreateSectionEx` - Section object creation with access rights and allocation attributes
  - `NtMapViewOfSection` - Memory mapping with inheritance and protection options
  - `NtOpenFile` - File access with sharing and open options
  - `NtQueueApcThreadEx2` - Asynchronous procedure call queuing
  - `ObjectAttributes` - NT object attribute structures
  - `UnicodeString` - NT Unicode string handling

### Graphics Programming
- **Vulkan** - Complete Vulkan API bindings for 3D graphics programming
- **User32** - Windows GUI APIs

### File Format Analysis
- **PE** - Portable Executable file format parser for analyzing Windows executables and DLLs

### Process Internals
- **PEB (Process Environment Block)** - Access to process internals including:
  - Loader data structures
  - Module information
  - Process parameters

### Build System
- Custom C# compiler wrapper with configuration support for building and testing individual components

## Architecture

The library uses unsafe C# code with extensive P/Invoke declarations to provide direct access to Windows system calls and low-level APIs. Each component is organized into focused modules with appropriate enumerations, structures, and wrapper methods.

## Use Cases

This library is designed for:
- Systems programming and low-level Windows development
- Reverse engineering and malware analysis
- Graphics programming with Vulkan
- Memory management and process manipulation
- PE file analysis and inspection