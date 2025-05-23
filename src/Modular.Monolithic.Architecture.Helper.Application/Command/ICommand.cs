// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Modular.Monolithic.Architecture.Helper.Application.Command;

public interface ICommand : IBaseCommand;

public interface ICommand<out TResponse> : IBaseCommand;

public interface IBaseCommand;
