namespace planning.Application.Common.Mappings;

public class CommandsProfile : Profile
{
    public CommandsProfile()
    {
        CreateMap<SignUpCommand, User>();
        CreateMap<AddSystemPromptCommand, SystemPrompt>();

        CreateMap<EditSystemPromptCommand, SystemPrompt>()
            .ForMember(x => x.Id, 
                opt => opt.Ignore());
        
        CreateMap<AddMessageCommand, Message>();
        
        CreateMap<AddChatSessionCommand, ChatSession>()
            .ForMember(x => x.Model, 
                opt => opt.MapFrom(src => Enum.Parse<GPTModel>(src.Model)));

        CreateMap<ForkMessageCommand, ChatSession>()
            .ForMember(x => x.Messages,
                opt => opt.MapFrom(src => new List<Message> { new Message(src.Content, src.IsFromUser, src.ForkedFromChatSessionId) }))
            .ForMember(x => x.Model,
                opt => opt.MapFrom(src => Enum.Parse<GPTModel>(src.Model)));
    }
}