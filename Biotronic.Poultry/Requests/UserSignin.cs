namespace Biotronic.Poultry.Requests
{
    public class UserSignin
    {
        public string Name { get; set; }
        public string Email  { get; set; }
        public string Token { get; set; }

        public string TokenHeader => Token.Split('.')[0];
        public string TokenPayload => Token.Split('.')[1];
        public string Signature => Token.Split('.')[2];
    }
}
