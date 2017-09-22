﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ChilliCream.Tracing.Generator.Tasks
{
    internal sealed class BindTask<TTask>
        : IBindTask<TTask>
        where TTask : class, ITask
    {
        private readonly ICollection<TaskDefinition> _tasks;
        private readonly TaskDefinition _task;

        public BindTask(ICollection<TaskDefinition> tasks)
        {
            if (tasks == null)
            {
                throw new ArgumentNullException(nameof(tasks));
            }

            _tasks = tasks;
            _task = new TaskDefinition();

            _tasks.Add(_task);
        }

        public IBindTaskDefault<TTask> AsDefault()
        {
            if (_tasks.Any(t => t.IsDefault))
            {
                throw new InvalidOperationException("There is already a default task.");
            }

            _task.IsDefault = true;
            return new BindTaskDefault<TTask>(_tasks, _task);
        }

        public IBindTaskName<TTask> WithName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (_tasks.Any(t => string.Equals(t.Name, name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException("There is alread a task with the specified name.", nameof(name));
            }

            _task.Name = name;
            return new BindTaskName<TTask>(_tasks, _task);
        }
    }
}
