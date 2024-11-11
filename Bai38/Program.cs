using System;
using System.Threading.Tasks;

namespace Bai38 
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Gọi hàm bất đồng bộ và chờ hoàn thành
            await LongRunningOperationAsync();
            Console.WriteLine("da xong.");
        }

        // Hàm bất đồng bộ trả về Task
        static async Task LongRunningOperationAsync()
        {
            Console.WriteLine("bat dau lam...");
            await Task.Delay(5000); // Giả lập một công việc tốn 5 giây
            Console.WriteLine("xong.");
        }
    }
}
