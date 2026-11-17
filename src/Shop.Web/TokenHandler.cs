namespace Shop.Web
{
    public class TokenHandler : DelegatingHandler
    {
        private readonly AuthState _auth;

        public TokenHandler(AuthState auth)
        {
            _auth = auth;
            InnerHandler = new HttpClientHandler();
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Add("X-Token", _auth.Token);
            return await base.SendAsync(request, cancellationToken);
        }
    }
}