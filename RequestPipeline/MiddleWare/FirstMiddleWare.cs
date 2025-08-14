namespace RequestPipeline.MiddleWare
{
    public class FirstMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<FirstMiddleWare> _logger;

        // constructor chỉ để tạo middleware 1 lần duy nhất khi app load
        public FirstMiddleWare(RequestDelegate next, ILogger<FirstMiddleWare> logger)
        {
            _next = next;
            _logger = logger;
        }

        // invoke chạy sau và đc chạy mỗi khi có request

        public async Task InvokeAsync (HttpContext context)
        {
            context.Response.ContentType = "text/html; charset=utf-8";
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");
            // lần đầu vào request vào middle
            //await context.Response.WriteAsync("thông báo request lần 1 vào middleware 1 <br>"); // TH này ko nên dùng vì nếu response writeAsync luôn thì nó vẫn vào các middle khác nhưng sẽ không sửa đc các response ví dụ như statusCode

            // sẽ gộp nó vào items của httpContext
            context.Items["FirstMsg"] = "thông báo request lần 1 vào middleware 1 <br>";
            // gọi đến delegate đã truyền từ constructor để chuyển sang middleware tiếp theo
            await _next(context);
            context.Items["FirstMiddlsExitMsg"] = "thông báo response ra khỏi middleware 1 <br>";
        }
    }
}
