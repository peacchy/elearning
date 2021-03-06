﻿using System.Threading.Tasks;
using ELearning.Application.Users.Queries.GetUsersList;
using ELearning.Application.Users.Queries.GetUserById;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using ELearning.Application.Users.Command.CreateUser;
using ELearning.Application.Users.Command.UpdateUser;
using ELearning.Application.Users.Command.DeleteUser;
using ELearning.Application.Users.Queries.GetSectionsListById;
using ELearning.Application.Users.Queries.GetAssignmentsListWithDetailsById;
using ELearning.Application.Users.Queries.GetStudentsList;
using ELearning.Application.Users.Queries.GetPastAssignmentsListById;
using ELearning.Application.Users.Queries.GetPresentAssignmentsListById;
using ELearning.Domain.Entities;
using Microsoft.AspNetCore.Authorization;

namespace ELearning.WebUI.Controllers
{
    // TODO Authorization

    [ApiController]
    public class UsersController : BaseController
    {
        // GET: api/Users/GetAll
        [HttpGet]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<UsersListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetUsersListQuery()));
        }

        // GET: api/Users/GetAllStudents/
        [HttpGet]
        [Authorize(Roles = Role.None)]
        public async Task<ActionResult<StudentsListViewModel>> GetAllStudents()
        {
            return Ok(await Mediator.Send(new GetStudentsListQuery()));
        }

        // GET: api/Users/GetById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetUserByIdQuery { Id = id }));
        }

        // GET: api/Users/GetSectionsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<SectionsDetailedListViewModel>> GetSectionsById(int id)
        {
            return Ok(await Mediator.Send(new GetSectionsListByIdQuery { Id = id }));
        }

        // GET: api/Users/GetAssignmentsWithDetailsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Admin)]
        public async Task<ActionResult<AssignmentsListWithDetailsViewModel>> GetAssignmentsWithDetailsById(int id)
        {
            return Ok(await Mediator.Send(new GetAssignmentsListWithDetailsByIdQuery { Id = id }));
        }

        // GET: api/Users/GetPastAssignmentsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Student)]
        public async Task<ActionResult<PastAssignmentsListViewModel>> GetPastAssignmentsById(int id)
        {
            return Ok(await Mediator.Send(new GetPastAssignmentsListByIdQuery { Id = id }));
        }

        // GET: api/Users/GetPresentAssignmentsById/5
        [HttpGet("{id}")]
        [Authorize(Roles = Role.Student)]
        public async Task<ActionResult<PresentAssignmentsListViewModel>> GetPresentAssignmentsById(int id)
        {
            return Ok(await Mediator.Send(new GetPresentAssignmentsListByIdQuery { Id = id }));
        }

        // POST: api/Users/Create
        [HttpPost]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Create([FromBody]CreateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT: api/Users/Update
        [HttpPut]
        [Authorize(Roles = Role.None)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Update([FromBody]UpdateUserCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE: api/Users/Delete/5
        [HttpDelete("{id}")]
        [Authorize(Roles = Role.Admin)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteUserCommand { Id = id });

            return NoContent();
        }
    }
}
