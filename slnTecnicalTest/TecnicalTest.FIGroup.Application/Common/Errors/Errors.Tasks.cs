using ErrorOr;

namespace TecnicalTest.FIGroup.Application.Common.Errors;

public static partial class Errors
{
   public static class Tasks
    {
        public static Error TasksNotFound(string message)
        { 
         return Error.NotFound(
            "Tasks.NotFound",
            string.IsNullOrEmpty(message) ? "Tasks not found." : message
            );

        }      

        public static Error TasksFailed(string message) {

            return Error.Conflict(
             "Tasks.Failed",
            string.IsNullOrEmpty(message) ? "Failed to create task": message
             );
        }
    
    }
}

