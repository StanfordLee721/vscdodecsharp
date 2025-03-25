using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// builder.Logging.ClearProviders(); // 清除預設的日誌提供者，並添加自定義的日誌提供者   
// builder.Logging.AddConsole(); // 添加主控臺日誌
// 設定 Serilog
Log.Logger = new LoggerConfiguration()
    .WriteTo.Console() // 可選：輸出至 Console
    .WriteTo.File("logs/log.log", rollingInterval: RollingInterval.Day) // 輸出至 logs 資料夾
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning) // 忽略 Microsoft 大部分的日誌
    .MinimumLevel.Override("System", LogEventLevel.Warning) // 忽略 System 大部分的日誌
    .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Information) // 保留 Hosting 啟動日誌
    .CreateLogger(); 

// 使用 Serilog 作為 Logging Provider
builder.Host.UseSerilog();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

// 記錄 HTTP 請求
app.UseSerilogRequestLogging(options =>
{
    options.GetLevel = (httpContext, elapsed, ex) =>
        ex != null || httpContext.Response.StatusCode >= 500
            ? LogEventLevel.Error    // 只有 500 以上錯誤才記錄
            : LogEventLevel.Verbose; // 其他請求不記錄
});
//app.MapStaticAssets();
app.UseStaticFiles();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//   .WithStaticAssets();


app.Run();
