﻿global using AutoMapper;
global using FluentValidation;
global using HR_Management.Application.Contracts.Persistence;
global using HR_Management.Application.DTOs.Common;
global using HR_Management.Application.DTOs.LeaveAllocation;
global using HR_Management.Application.DTOs.LeaveAllocation.Validators;
global using HR_Management.Application.DTOs.LeaveRequest;
global using HR_Management.Application.DTOs.LeaveRequest.Validators;
global using HR_Management.Application.DTOs.LeaveType;
global using HR_Management.Application.DTOs.LeaveType.Validators;
global using HR_Management.Application.Exceptions;
global using HR_Management.Application.Features.LeaveAllocation.Requests.Commands;
global using HR_Management.Application.Features.LeaveAllocation.Requests.Queries;
global using HR_Management.Application.Features.LeaveRequest.Requests.Commands;
global using HR_Management.Application.Features.LeaveRequest.Requests.Queries;
global using HR_Management.Application.Features.LeaveType.Requests.Commands;
global using HR_Management.Application.Responses;
global using HR_Management.Domain.Entities;
global using MediatR;
global using HR_Management.Application.Features.LeaveType.Requests.Queries;