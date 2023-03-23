﻿using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Contracts;
using System.Drawing;
using TaskProject.LairLogic.Models.Tasks;
using TaskProject.LairLogic.Models.Users;
using TaskWebProject.Models.Users;

namespace TaskWebProject.Models.Tasks
{
    public class TaskListViewModel
    {
        public List<TaskShortViewModel> Tasks { get; set; }

        public int TotalCount { get; set; }
        public int Page { get; set; }
        public int Size { get; set; }

        public bool CanBack { get; set; }
        public bool CanForward { get; set; }

        public TaskListViewModel()
        {
            Tasks = new List<TaskShortViewModel>();
        }

        public TaskListViewModel(TaskListDTO list, int page, int size)
        {
            Tasks = new List<TaskShortViewModel>();
            foreach (TaskDTO task in list.Tasks)
            {
                Tasks.Add(new TaskShortViewModel(task));
            }

            TotalCount = list.TotalCount;
            Page = page;
            Size = size;

            CanBack = Page > 0;
            CanForward = (Page + 1) * Size < TotalCount;
        }

    }
}
