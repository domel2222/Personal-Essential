global using Application.Abstractions.Messaging;
global using Application.Common.Behaviours;
global using Application.Common.Interfaces;
global using Application.Common.Utilities;
global using Application.Contracts.Assessments;
global using Application.Contracts.Journals;
global using Application.Contracts.MostWinsDuringTheDay;
global using Application.Contracts.Users;
global using Domain.Entities;
global using Domain.Exceptions;
global using Domain.Repositories;
global using Domain.Shared;
global using FluentValidation;
global using FluentValidation.Results;
global using Mapster;
global using MapsterMapper;
global using MediatR;
global using MediatR.Pipeline;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Logging;
global using System.Reflection;
global using Application.Journals.Command.CreateJournal;
global using Application.Journals.Command.DeleteJournal;

namespace Application
{
}