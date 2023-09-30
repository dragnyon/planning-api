namespace planning.Application.Common.Interfaces;

public interface IEmailService
{
    Task SendAsync(MimeMessage message);
}