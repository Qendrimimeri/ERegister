namespace Presentation.Extensions
{
    public static class MiddleWarePipline
    {
        public static WebApplication MiddleWareCustomPipline( this WebApplication app )
        {
            app.UseStatusCodePagesWithReExecute("/ErrorHandler/Error/{0}");

            app.UseHttpsRedirection();
            
            app.UseStaticFiles();
            
            app.UseRouting();
            
            app.UseAuthentication();
            
            app.UseAuthorization();

            return app;
        }
    }
}
