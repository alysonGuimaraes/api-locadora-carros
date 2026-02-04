using System.Globalization;

namespace RentCars.API.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public LanguageMiddleware(RequestDelegate next) 
        {
            _requestDelegate = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            var requestedLanguage = context.Request.Headers.AcceptLanguage.FirstOrDefault();

            var languageInfo = new CultureInfo("en");

            if (String.IsNullOrWhiteSpace(requestedLanguage) == false 
                && supportedLanguages.Any(c => c.Name.Equals(requestedLanguage)))
            {
                languageInfo = new CultureInfo(requestedLanguage);
            }

            CultureInfo.CurrentCulture = languageInfo;
            CultureInfo.CurrentUICulture = languageInfo;

            await _requestDelegate(context);
        }
    }
}
