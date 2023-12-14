using CleanArchitecture.Presentation;
using Serilog;

namespace CleanArchitecture.WF;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        //initialize the application loger
        Log.Information("Starting application");

        try
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();

            // run the application
            Application.Run(new TestForm());
        }
        catch (Exception ex) when (ex.GetType().Name is not "StopTheHostException" && ex.GetType().Name is not "HostAbortedException")
        {
            Log.Fatal(ex, "Application terminated unexpectedly");
        }
        finally
        {
            // close the application loger
            Log.Information("Shutting down the application");
            Log.CloseAndFlush();
        }

    }
}