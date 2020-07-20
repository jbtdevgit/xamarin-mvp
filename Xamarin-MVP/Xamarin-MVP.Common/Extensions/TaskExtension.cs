using System.Threading.Tasks;

namespace Xamarin_MVP.Common.Extensions
{
    public static class TaskExtension
    {
        /// <summary>
        /// Run a task concurrently without error
        /// </summary>
        public static void RunTaskConcurrent(this Task task)
        {
            if (task.Status.Equals(TaskStatus.Created))
            {
                task.Start();
            }
        }
    }
}
