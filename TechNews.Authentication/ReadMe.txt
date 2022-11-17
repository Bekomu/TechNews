To ConfigureServices => 

method yaparsın !!!

services.AddAuthentication(x => 
{
	x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
	x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
}).AddJwtBearer(x => 
{
	x.RequireHttpMetadata = false;
	x.SaveToken = true;
	x.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuerSigningKey = true,
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("stringtokenkey")),
		ValidateIssuer = false,
		ValidateAudience = false
	};
});

services.AddSingleton<IJWTAuthenticationService>(new JwtAuthenticationManager());

To Configure before "app.UseAuthorization();"
add =>
app.UseAuthentication();