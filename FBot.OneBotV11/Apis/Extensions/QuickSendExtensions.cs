using FBot.OneBotV11.Events.Messages;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Extensions;

public static partial class ApiExtensions
{
    public static async Task<bool> SendAsync(
        this IOneBotV11Bot bot,
        BaseMessageEvent messageEvent,
        Message message
    )
    {
        switch (messageEvent)
        {
            case GroupMessageEvent e:
                await bot.SendGroupMsgAsync(new() { GroupId = e.GroupId, Message = message });
                return true;
            case PrivateMessageEvent e:
                await bot.SendPrivateMsgAsync(new() { UserId = e.UserId, Message = message });
                return true;
        }

        return false;
    }
}
