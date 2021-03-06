﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BcGov.Malt.Web.Models;
using BcGov.Malt.Web.Models.Configuration;
using BcGov.Malt.Web.Services;
using MediatR;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;

namespace BcGov.Malt.Web.Features.Projects
{
    public static class AddUserToProject
    {
        public class Request : IRequest<ProjectAccess>
        {
            public Request(string projectId, string username)
            {
                ProjectId = projectId ?? throw new ArgumentNullException(nameof(projectId));
                Username = username ?? throw new ArgumentNullException(nameof(username));
            }

            public string ProjectId { get; }
            public string Username { get; }
        }

        public class Handler : IRequestHandler<Request, ProjectAccess>
        {
            private readonly IUserSearchService _userSearchService;
            private readonly IUserManagementService _userManagementService;
            private readonly ProjectConfigurationCollection _projects;
            private readonly ILogger<Handler> _logger;

            public Handler(IUserSearchService userSearchService, IUserManagementService userManagementService, ProjectConfigurationCollection projects, ILogger<Handler> logger)
            {
                _userSearchService = userSearchService ?? throw new ArgumentNullException(nameof(userSearchService));
                _userManagementService = userManagementService ?? throw new ArgumentNullException(nameof(userManagementService));
                _projects = projects ?? throw new ArgumentNullException(nameof(projects));
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }

            public async Task<ProjectAccess> Handle(Request request, CancellationToken cancellationToken)
            {
                var project = _projects.SingleOrDefault(_ => _.Id == request.ProjectId);

                if (project == null)
                {
                    _logger.LogInformation("Project {ProjectId} not found", request.ProjectId);
                    throw new ProjectNotFoundException(request.ProjectId);
                }

                var user = await _userSearchService.SearchAsync(request.Username);
                if (user == null)
                {
                    _logger.LogInformation("User {Username} not found", request.Username);
                    throw new UserNotFoundException(request.Username);
                }

                var access = await _userManagementService.AddUserToProjectAsync(user, project);
                
                return new ProjectAccess
                {
                    Id = project.Id,
                    Name = project.Name,
                    Users = new List<UserAccess>
                    {
                        new UserAccess {Username = user.UserName, Access = access }
                    }
                };
            }
        }
    }
}
