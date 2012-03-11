﻿using Simple.Data;
using paramore.commandprocessor;
using tasklist.web.Commands;
using tasklist.web.DataAccess;
using tasklist.web.Models;

namespace tasklist.web.Handlers
{
    public class AddTaskCommandHandler : RequestHandler<AddTaskCommand>
    {
        private readonly ITasksDAO tasksDao;

        public AddTaskCommandHandler(ITasksDAO tasksDao)
        {
            this.tasksDao = tasksDao;
        }

        [Validation(step: 2, timing: HandlerTiming.Before)]
        [Trace(step:1, timing: HandlerTiming.Before)]
        public override AddTaskCommand Handle(AddTaskCommand addTaskCommand)
        {
            tasksDao.Add(
                new Task(
                    taskName: addTaskCommand.TaskName, 
                    taskDecription: addTaskCommand.TaskDecription,
                    dueDate: addTaskCommand.TaskDueDate
                    )
                );

            return addTaskCommand;
        }
    }
}