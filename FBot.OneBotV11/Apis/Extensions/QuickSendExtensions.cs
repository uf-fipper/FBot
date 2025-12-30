using FBot.OneBotV11.Events.Messages;
using FBot.OneBotV11.Events.Messages.Segments;

namespace FBot.OneBotV11.Apis.Extensions;

public static partial class ApiExtensions
{
    /// <summary>
    /// 根据消息事件快速发送消息
    /// </summary>
    /// <param name="bot"></param>
    /// <param name="messageEvent"></param>
    /// <param name="message"></param>
    /// <returns>消息id</returns>
    public static async Task<long?> SendAsync(
        this IOneBotV11Bot bot,
        BaseMessageEvent messageEvent,
        Message message
    )
    {
        switch (messageEvent)
        {
            case GroupMessageEvent e:
                var groupResult = await bot.SendGroupMsgAsync(
                    new() { GroupId = e.GroupId, Message = message }
                );
                return groupResult.Data.MessageId;
            case PrivateMessageEvent e:
                var privateResult = await bot.SendPrivateMsgAsync(
                    new() { UserId = e.UserId, Message = message }
                );
                return privateResult.Data.MessageId;
        }

        return null;
    }
}
