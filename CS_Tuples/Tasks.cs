using System;
using System.Collections.Generic;
using System.Text;

namespace CS_Tuples
{
    public class ProjectTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string AssignTo { get; set; }
        public bool Status { get; set; }
    }

    public class ProjectTasks : List<ProjectTask>
    {
        public ProjectTasks()
        {
            Add(new ProjectTask()
            {
                TaskId = 1,
                TaskName = "Write Use Cases",
                AssignTo = "Mahesh",
                Status = true
            });
            Add(new ProjectTask()
            {
                TaskId = 2,
                TaskName = "Verify Use Cases",
                AssignTo = "Kumar",
                Status = false
            });
            Add(new ProjectTask()
            {
                TaskId = 3,
                TaskName = "Define Test Cases",
                AssignTo = "Mahesh",
                Status = false
            });
            Add(new ProjectTask()
            {
                TaskId = 4,
                TaskName = "Verify test Cases",
                AssignTo = "Kumar",
                Status = false
            });
            Add(new ProjectTask()
            {
                TaskId = 5,
                TaskName = "Define Testing Environment",
                AssignTo = "Ajay",
                Status = false
            });
            Add(new ProjectTask()
            {
                TaskId = 6,
                TaskName = "Define Development Environment",
                AssignTo = "Avi",
                Status = false
            });
        }
    }
}
