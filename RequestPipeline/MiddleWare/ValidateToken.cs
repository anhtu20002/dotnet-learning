using System.Text;

namespace RequestPipeline.MiddleWare
{
    public class ValidateToken
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<FirstMiddleWare> _logger;

        // constructor chỉ để tạo middleware 1 lần duy nhất khi app load
        public ValidateToken(RequestDelegate next, ILogger<FirstMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        // invoke chạy sau và đc chạy mỗi khi có request

        public async Task InvokeAsync(HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            var token = context.Request.Headers["Authorization"].FirstOrDefault();
            _logger.LogInformation($"Token: {token}");


            if (string.IsNullOrEmpty(token) || token != "Bearer mysecrettoken")
            {
                context.Items["TokenError"] = "Token không hợp lệ hoặc thiếu!";
                // Vẫn cho đi tiếp, nhưng đánh dấu lỗi
                await _next(context);
                return;
            }
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
            // lần đầu vào request vào middle
            context.Items["TokenMsg"] = "thông báo request lần 1 vào validate token";
            // gọi đến delegate đã truyền từ constructor để chuyển sang middleware tiếp theo
            await _next(context);

            context.Items["TokenExitMsg"] = "thông báo response ra khỏi validate token";
        }
    }
}
