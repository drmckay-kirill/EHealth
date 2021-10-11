using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace EHealth.Application.Services.Abe.Mock
{
    public static class LocalHost
    {
        public static string GetRandomFilename()
        {
            return Path.GetTempFileName();
        }

        public static async Task<string> WriteFileAsync(byte[] fileData, string filePath = "")
        {
            if (string.IsNullOrEmpty(filePath))
                filePath = GetRandomFilename();

            await using var fs = new FileStream(filePath, FileMode.OpenOrCreate);
            await fs.WriteAsync(fileData, 0, fileData.Length);
            return filePath;
        }

        public static async Task<byte[]> ReadFileAsync(string filePath)
        {
            await using var fs = new FileStream(filePath, FileMode.Open);
            var result = new byte[fs.Length];
            await fs.ReadAsync(result, 0, (int)fs.Length);
            return result;
        }

        public static Task RunProcessAsync(string command, string arguments = "")
        {
            var tcs = new TaskCompletionSource<object>();
            var process = new Process
            {
                EnableRaisingEvents = true,
                StartInfo = new ProcessStartInfo(command)
                {
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    Arguments = arguments
                }
            };
            process.Exited += (sender, args) =>
            {
                if (process.ExitCode != 0)
                {
                    var errorMessage = process.StandardError.ReadToEnd();
                    tcs.SetException(new InvalidOperationException(errorMessage));
                }
                else
                {
                    tcs.SetResult(null);
                }

                process.Dispose();
            };
            process.Start();
            return tcs.Task;
        }
    }
}