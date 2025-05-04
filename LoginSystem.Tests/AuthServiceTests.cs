using LoginSystem.Application.Services;
using LoginSystem.Domain.Entities;
using LoginSystem.Domain.Interfaces;
using Moq;
using Xunit;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using LoginSystem.Domain.Exceptions.LoginSystem.Domain.Exceptions;
using LoginSystem.Domain.Exceptions;

public class AuthServiceTests
{
   
    [Fact]
    public async Task LoginAsync_ValidUser_ReturnsToken()
    {
        // Arrange
        var password = "password";
        var hmac = new System.Security.Cryptography.HMACSHA512();
        var user = new User
        {
            Username = "testuser",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(x => x.GetByUsernameAsync(user.Username)).ReturnsAsync(user);

        var configMock = new Mock<IConfiguration>();
        configMock.Setup(x => x["Jwt:Key"]).Returns("TESTE123456789012345678901234567890TESTE12345678901234567890");
        configMock.Setup(x => x["Jwt:Issuer"]).Returns("test");
        configMock.Setup(x => x["Jwt:Audience"]).Returns("test");
        configMock.Setup(x => x["Jwt:ExpiresInMinutes"]).Returns("60");

        var authService = new AuthService(repoMock.Object, configMock.Object);

        // Act
        var token = await authService.LoginAsync(user.Username, password);

        // Assert
        Assert.False(string.IsNullOrEmpty(token));
    }

    [Fact]
    public async Task LoginAsync_InvalidUser_ThrowsUnauthorizedAccessException()
    {
        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(x => x.GetByUsernameAsync("user")).ReturnsAsync((User)null);

        var configMock = new Mock<IConfiguration>();

        var authService = new AuthService(repoMock.Object, configMock.Object);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => authService.LoginAsync("user", "pass"));
    }

    [Fact]
    public async Task LoginAsync_InvalidPassword_ThrowsUnauthorizedAccessException()
    {
        var password = "correct";
        var hmac = new System.Security.Cryptography.HMACSHA512();
        var user = new User
        {
            Username = "testuser",
            PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
            PasswordSalt = hmac.Key
        };

        var repoMock = new Mock<IUserRepository>();
        repoMock.Setup(x => x.GetByUsernameAsync(user.Username)).ReturnsAsync(user);

        var configMock = new Mock<IConfiguration>();

        var authService = new AuthService(repoMock.Object, configMock.Object);

        await Assert.ThrowsAsync<UnauthorizedAccessException>(() => authService.LoginAsync(user.Username, "wrongpassword"));
    }

    [Fact]
    public void DomainException_WhenThrown_ReturnsCorrectMessage()
    {
        var exception = new DomainException("Erro de domínio");

        Assert.Equal("Erro de domínio", exception.Message);
    }

    [Fact]
    public void AssertionConcern_AssertArgumentNotEmpty_WhenEmpty_ThrowsDomainException()
    {
        Assert.Throws<DomainException>(() =>
            AssertionConcern.AssertArgumentNotEmpty("", "Campo obrigatório"));
    }

    [Fact]
    public void AssertionConcern_AssertArgumentNotNull_WhenNull_ThrowsDomainException()
    {
        Assert.Throws<DomainException>(() =>
            AssertionConcern.AssertArgumentNotNull(null, "Não pode ser nulo"));
    }



}
