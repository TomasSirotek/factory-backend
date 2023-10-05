using Microsoft.Playwright;

namespace playwright_tests;

public class ContextConfig
{
    public  async Task<IAPIRequestContext> SetContext()
    {
        var playwright = await Playwright.CreateAsync();
        var reqContext = await playwright.APIRequest.NewContextAsync(new APIRequestNewContextOptions{
            
            BaseURL = "http://localhost:5000/",
            IgnoreHTTPSErrors = true,
        });

        return reqContext;
    }
}