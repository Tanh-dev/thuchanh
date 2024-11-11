using System;
using System.Threading;
using System.Threading.Tasks;

namespace CancellationExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;

            // Bắt đầu một task bất đồng bộ và truyền CancellationToken
            var task = LongRunningOperationAsync(token);

            // Giả lập người dùng muốn hủy sau 3 giây
            await Task.Delay(3000);
            cancellationTokenSource.Cancel();

            try
            {
                await task;
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("cong viec bi huy.");
            }

            Console.WriteLine("end.");
        }

        // Hàm bất đồng bộ có thể bị hủy, sử dụng CancellationToken
        static async Task LongRunningOperationAsync(CancellationToken token)
        {
            Console.WriteLine("dat dau...");

            for (int i = 0; i < 10; i++)
            {
                // Kiểm tra nếu token yêu cầu hủy
                token.ThrowIfCancellationRequested();

                Console.WriteLine($"dang xu li {i + 1}/10...");
                await Task.Delay(1000); // Giả lập công việc mỗi lần 1 giây
            }

            Console.WriteLine("xong.");
        }
    }
}
