using FBot.OneBotV11.Apis.Dto;
using FBot.OneBotV11.Apis.Vo;

namespace FBot.OneBotV11.Apis.Extensions;

public static partial class ApiExtensions
{
    public static async Task<BaseResponseVo<SendMsgVo>> SendMsgAsync(
        this IOneBotV11Bot bot,
        SendMsgDto dto
    )
    {
        return await bot.CallApiAsync<SendMsgVo>("send_msg", dto);
    }
}
