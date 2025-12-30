using FBot.OneBotV11.Apis.Dto;
using FBot.OneBotV11.Apis.Vo;

namespace FBot.OneBotV11.Apis.Extensions;

public static partial class ApiExtensions
{
    public static async Task<BaseResponseVo<SendGroupMsgVo>> SendGroupMsgAsync(
        this IOneBotV11Bot bot,
        SendGroupMsgDto dto
    )
    {
        return await bot.CallApiAsync<SendGroupMsgVo>("send_group_msg", dto);
    }
}
