using FBot.OneBotV11.Apis.Dto;
using FBot.OneBotV11.Apis.Vo;

namespace FBot.OneBotV11.Apis.Extensions;

public static partial class ApiExtensions
{
    public static async Task<BaseResponseVo<SendPrivateMsgVo>> SendPrivateMsgAsync(
        this IOneBotV11Bot bot,
        SendPrivateMsgDto dto
    )
    {
        return await bot.CallApiAsync<SendPrivateMsgVo>("send_private_msg", dto);
    }
}
