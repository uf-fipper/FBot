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

    public static async Task<BaseResponseVo<SendGroupMsgVo>> SendGroupMsgAsync(
        this IOneBotV11Bot bot,
        SendGroupMsgDto dto
    )
    {
        return await bot.CallApiAsync<SendGroupMsgVo>("send_group_msg", dto);
    }

    public static async Task<BaseResponseVo<SendPrivateMsgVo>> SendPrivateMsgAsync(
        this IOneBotV11Bot bot,
        SendPrivateMsgDto dto
    )
    {
        return await bot.CallApiAsync<SendPrivateMsgVo>("send_private_msg", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> DeleteMsgAsync(
        this IOneBotV11Bot bot,
        DeleteMsgDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("delete_msg", dto);
    }

    public static async Task<BaseResponseVo<GetMsgVo>> GetMsgAsync(
        this IOneBotV11Bot bot,
        GetMsgDto dto
    )
    {
        return await bot.CallApiAsync<GetMsgVo>("get_msg", dto);
    }

    public static async Task<BaseResponseVo<GetForwardMsgVo>> GetForwardMsgAsync(
        this IOneBotV11Bot bot,
        GetForwardMsgDto dto
    )
    {
        return await bot.CallApiAsync<GetForwardMsgVo>("get_forward_msg", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SendLikeAsync(
        this IOneBotV11Bot bot,
        SendLikeDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("send_like", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupKickAsync(
        this IOneBotV11Bot bot,
        SetGroupKickDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_kick", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupBanAsync(
        this IOneBotV11Bot bot,
        SetGroupBanDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_ban", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupAnonymousBanAsync(
        this IOneBotV11Bot bot,
        SetGroupAnonymousBanDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_anonymous_ban", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupWholeBanAsync(
        this IOneBotV11Bot bot,
        SetGroupWholeBanDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_whole_ban", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupAdminAsync(
        this IOneBotV11Bot bot,
        SetGroupAdminDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_admin", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupAnonymousAsync(
        this IOneBotV11Bot bot,
        SetGroupAnonymousDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_anonymous", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupCardAsync(
        this IOneBotV11Bot bot,
        SetGroupCardDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_card", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupNameAsync(
        this IOneBotV11Bot bot,
        SetGroupNameDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_name", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupLeaveAsync(
        this IOneBotV11Bot bot,
        SetGroupLeaveDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_leave", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupSpecialTitleAsync(
        this IOneBotV11Bot bot,
        SetGroupSpecialTitleDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_special_title", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetFriendAddRequestAsync(
        this IOneBotV11Bot bot,
        SetFriendAddRequestDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_friend_add_request", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetGroupAddRequestAsync(
        this IOneBotV11Bot bot,
        SetGroupAddRequestDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_group_add_request", dto);
    }

    public static async Task<BaseResponseVo<GetLoginInfoVo>> GetLoginInfoAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<GetLoginInfoVo>("get_login_info", null);
    }

    public static async Task<BaseResponseVo<GetStrangerInfoVo>> GetStrangerInfoAsync(
        this IOneBotV11Bot bot,
        GetStrangerInfoDto dto
    )
    {
        return await bot.CallApiAsync<GetStrangerInfoVo>("get_stranger_info", dto);
    }

    public static async Task<BaseResponseVo<List<GetFriendListVo>>> GetFriendListAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<List<GetFriendListVo>>("get_friend_list", null);
    }

    public static async Task<BaseResponseVo<GetGroupInfoVo>> GetGroupInfoAsync(
        this IOneBotV11Bot bot,
        GetGroupInfoDto dto
    )
    {
        return await bot.CallApiAsync<GetGroupInfoVo>("get_group_info", dto);
    }

    public static async Task<BaseResponseVo<List<GetGroupInfoVo>>> GetGroupListAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<List<GetGroupInfoVo>>("get_group_list", null);
    }

    public static async Task<BaseResponseVo<GetGroupMemberInfoVo>> GetGroupMemberInfoAsync(
        this IOneBotV11Bot bot,
        GetGroupMemberInfoDto dto
    )
    {
        return await bot.CallApiAsync<GetGroupMemberInfoVo>("get_group_member_info", dto);
    }

    public static async Task<BaseResponseVo<List<GetGroupMemberInfoVo>>> GetGroupMemberListAsync(
        this IOneBotV11Bot bot,
        GetGroupMemberListDto dto
    )
    {
        return await bot.CallApiAsync<List<GetGroupMemberInfoVo>>("get_group_member_list", dto);
    }

    public static async Task<BaseResponseVo<GetGroupHonorInfoVo>> GetGroupHonorInfoAsync(
        this IOneBotV11Bot bot,
        GetGroupHonorInfoDto dto
    )
    {
        return await bot.CallApiAsync<GetGroupHonorInfoVo>("get_group_honor_info", dto);
    }

    public static async Task<BaseResponseVo<GetCookiesVo>> GetCookiesAsync(
        this IOneBotV11Bot bot,
        GetCookiesDto dto
    )
    {
        return await bot.CallApiAsync<GetCookiesVo>("get_cookies", dto);
    }

    public static async Task<BaseResponseVo<GetCsrfTokenVo>> GetCsrfTokenAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<GetCsrfTokenVo>("get_csrf_token", null);
    }

    public static async Task<BaseResponseVo<GetCredentialsVo>> GetCredentialsAsync(
        this IOneBotV11Bot bot,
        GetCredentialsDto dto
    )
    {
        return await bot.CallApiAsync<GetCredentialsVo>("get_credentials", dto);
    }

    public static async Task<BaseResponseVo<GetRecordVo>> GetRecordAsync(
        this IOneBotV11Bot bot,
        GetRecordDto dto
    )
    {
        return await bot.CallApiAsync<GetRecordVo>("get_record", dto);
    }

    public static async Task<BaseResponseVo<GetImageVo>> GetImageAsync(
        this IOneBotV11Bot bot,
        GetImageDto dto
    )
    {
        return await bot.CallApiAsync<GetImageVo>("get_image", dto);
    }

    public static async Task<BaseResponseVo<CanSendImageVo>> CanSendImageAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<CanSendImageVo>("can_send_image", null);
    }

    public static async Task<BaseResponseVo<CanSendRecordVo>> CanSendRecordAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<CanSendRecordVo>("can_send_record", null);
    }

    public static async Task<BaseResponseVo<GetStatusVo>> GetStatusAsync(this IOneBotV11Bot bot)
    {
        return await bot.CallApiAsync<GetStatusVo>("get_status", null);
    }

    public static async Task<BaseResponseVo<GetVersionInfoVo>> GetVersionInfoAsync(
        this IOneBotV11Bot bot
    )
    {
        return await bot.CallApiAsync<GetVersionInfoVo>("get_version_info", null);
    }

    public static async Task<BaseResponseVo<EmptyVo>> SetRestartAsync(
        this IOneBotV11Bot bot,
        SetRestartDto dto
    )
    {
        return await bot.CallApiAsync<EmptyVo>("set_restart", dto);
    }

    public static async Task<BaseResponseVo<EmptyVo>> CleanCacheAsync(this IOneBotV11Bot bot)
    {
        return await bot.CallApiAsync<EmptyVo>("clean_cache", null);
    }
}
