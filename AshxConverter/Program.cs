using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace AshxToPdfConverter
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Setup dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging(builder => builder.AddConsole())
                .AddHttpClient()
                .BuildServiceProvider();

            var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
            var httpClientFactory = serviceProvider.GetRequiredService<IHttpClientFactory>();

            if (args.Length < 2)
            {
                logger.LogError("Usage: AshxToPdfConverter <ashx-url> <output-pdf-path>");
                return;
            }

            string ashxUrl = args[0];
            string outputPath = args[1];

            try
            {
                await ConvertAshxToPdf(ashxUrl, outputPath, httpClientFactory, logger);
                logger.LogInformation($"PDF successfully created at: {outputPath}");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error converting ASHX to PDF");
            }
        }

        private static async Task ConvertAshxToPdf(string ashxUrl, string outputPath, 
            IHttpClientFactory httpClientFactory, ILogger logger)
        {
            // Validate URL
            if (!Uri.TryCreate(ashxUrl, UriKind.Absolute, out var uri))
            {
                throw new ArgumentException("Invalid URL format", nameof(ashxUrl));
            }

            // Download the file directly using HttpClient
            using var httpClient = httpClientFactory.CreateClient();
            try
            {
                logger.LogInformation($"Downloading file from URL: {ashxUrl}");
                var response = await httpClient.GetAsync(ashxUrl);
                response.EnsureSuccessStatusCode();

                // Get the content type
                var contentType = response.Content.Headers.ContentType?.MediaType;
                logger.LogInformation($"Content-Type: {contentType}");

                // Read the content as bytes
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                
                // Save the file
                logger.LogInformation($"Saving file to: {outputPath}");
                await File.WriteAllBytesAsync(outputPath, fileBytes);
            }
            catch (HttpRequestException ex)
            {
                logger.LogError(ex, $"Failed to download file from: {ashxUrl}");
                throw;
            }
        }
    }
}