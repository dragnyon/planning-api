using planning.Application.Authentification.DTOs;

namespace planning.Application.Common.Mappings;

public class ResponsesProfile : Profile
{
    public ResponsesProfile()
    {
        CreateMap<User, LoginResponse>();
        CreateMap<SystemPrompt, SystemPromptResponse>();
        CreateMap<Message, MessageResponse>();


        CreateMap<ChatSession, ChatSessionResponse>().ForMember(x => x.Model,
            opt => opt.MapFrom(src => src.Model.ToString()));
        CreateMap<ChatSession, ChatSessionCreatedResponse>().ForMember(x => x.Model,
            opt => opt.MapFrom(src => src.Model.ToString()));
        CreateMap<ChatSession, GetAllChatSessionsResponse>().ForMember(x => x.Model,
            opt => opt.MapFrom(src => src.Model.ToString()));
    }
}