using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSD.Util.Async
{
    public static class TaskUtil
    {
        public static Task<R> CreateTaskAsync<R>(Func<object, R> callback, object obj)
        {
            var task = new Task<R>(callback, obj);
            task.Start();

            return task;
        }

        public static Task CreateTaskAsync(Action<object> callback, object obj)
        {
            var task = new Task(callback, obj);
            task.Start();

            return task;
        }
    }
}
