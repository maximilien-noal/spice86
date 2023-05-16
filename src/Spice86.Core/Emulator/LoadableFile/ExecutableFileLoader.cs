﻿namespace Spice86.Core.Emulator.LoadableFile;

using System.IO;
using Spice86.Core.Emulator.Memory;
using Spice86.Core.Emulator.CPU;
using Spice86.Core.Emulator.VM;
using Spice86.Shared.Interfaces;
using Spice86.Shared.Utils;

/// <summary>
/// Base class for loading executable files in the VM like exe, bios, ...
/// </summary>
public abstract class ExecutableFileLoader {
    /// <summary>
    /// The emulator CPU.
    /// </summary>
    protected Cpu _cpu;
    
    /// <summary>
    /// The emulator machine.
    /// </summary>
    protected Machine _machine;
    
    /// <summary>
    /// The memory bus.
    /// </summary>
    protected Memory _memory;
    
    private readonly ILoggerService _loggerService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExecutableFileLoader"/> class.
    /// </summary>
    /// <param name="machine">The <see cref="Machine"/> instance.</param>
    /// <param name="loggerService">The <see cref="ILoggerService"/> instance.</param>
    protected ExecutableFileLoader(Machine machine, ILoggerService loggerService) {
        _loggerService = loggerService;
        _machine = machine;
        _cpu = machine.Cpu;
        _memory = machine.Memory;
    }

    /// <summary>
    /// Gets a value indicating whether DOS initialization is needed.
    /// </summary>
    public abstract bool DosInitializationNeeded { get; }

    /// <summary>
    /// Loads an executable file and returns its bytes.
    /// </summary>
    /// <param name="file">The path of the file to load.</param>
    /// <param name="arguments">Optional arguments to pass to the loaded file.</param>
    /// <returns>The bytes of the loaded file.</returns>
    public abstract byte[] LoadFile(string file, string? arguments);

    /// <summary>
    /// Reads the contents of a file and returns its bytes.
    /// </summary>
    /// <param name="file">The path of the file to read.</param>
    /// <returns>The bytes of the read file.</returns>
    protected byte[] ReadFile(string file) {
        return File.ReadAllBytes(file);
    }

    /// <summary>
    /// Sets the entry point of the loaded file to the specified segment and offset values.
    /// </summary>
    /// <param name="cs">The segment value of the entry point.</param>
    /// <param name="ip">The offset value of the entry point.</param>
    protected void SetEntryPoint(ushort cs, ushort ip) {
        State state = _cpu.State;
        state.CS = cs;
        state.IP = ip;
        if (_loggerService.IsEnabled(Serilog.Events.LogEventLevel.Verbose)) {
            _loggerService.Verbose("Program entry point is {ProgramEntry}", ConvertUtils.ToSegmentedAddressRepresentation(cs, ip));
        }
    }
}