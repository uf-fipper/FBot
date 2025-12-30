using System.Net;
using System.Net.WebSockets;
using System.Text.Json;
using FBot.OneBotV11.Apis.Dto;
using FBot.OneBotV11.Apis.Vo;

namespace FBot.OneBotV11;

public interface IOneBotV11Bot : IBot
{
    long SelfId { get; }

    OneBotV11Adapter Adapter { get; }

    Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params);

    public async Task<BaseResponseVo<SendMsgVo>> SendMsgAsync(SendMsgDto dto)
    {
        return await CallApiAsync<SendMsgVo>("send_msg", dto);
    }

    public async Task<BaseResponseVo<SendGroupMsgVo>> SendGroupMsgAsync(SendGroupMsgDto dto)
    {
        return await CallApiAsync<SendGroupMsgVo>("send_group_msg", dto);
    }

    public async Task<BaseResponseVo<SendPrivateMsgVo>> SendPrivateMsgAsync(SendPrivateMsgDto dto)
    {
        return await CallApiAsync<SendPrivateMsgVo>("send_private_msg", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> DeleteMsgAsync(DeleteMsgDto dto)
    {
        return await CallApiAsync<EmptyVo>("delete_msg", dto);
    }

    public async Task<BaseResponseVo<GetMsgVo>> GetMsgAsync(GetMsgDto dto)
    {
        return await CallApiAsync<GetMsgVo>("get_msg", dto);
    }

    public async Task<BaseResponseVo<GetForwardMsgVo>> GetForwardMsgAsync(GetForwardMsgDto dto)
    {
        return await CallApiAsync<GetForwardMsgVo>("get_forward_msg", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SendLikeAsync(SendLikeDto dto)
    {
        return await CallApiAsync<EmptyVo>("send_like", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupKickAsync(SetGroupKickDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_kick", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupBanAsync(SetGroupBanDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_ban", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupAnonymousBanAsync(
        SetGroupAnonymousBanDto dto
    )
    {
        return await CallApiAsync<EmptyVo>("set_group_anonymous_ban", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupWholeBanAsync(SetGroupWholeBanDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_whole_ban", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupAdminAsync(SetGroupAdminDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_admin", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupAnonymousAsync(SetGroupAnonymousDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_anonymous", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupCardAsync(SetGroupCardDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_card", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupNameAsync(SetGroupNameDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_name", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupLeaveAsync(SetGroupLeaveDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_leave", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupSpecialTitleAsync(
        SetGroupSpecialTitleDto dto
    )
    {
        return await CallApiAsync<EmptyVo>("set_group_special_title", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetFriendAddRequestAsync(SetFriendAddRequestDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_friend_add_request", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetGroupAddRequestAsync(SetGroupAddRequestDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_group_add_request", dto);
    }

    public async Task<BaseResponseVo<GetLoginInfoVo>> GetLoginInfoAsync()
    {
        return await CallApiAsync<GetLoginInfoVo>("get_login_info", null);
    }

    public async Task<BaseResponseVo<GetStrangerInfoVo>> GetStrangerInfoAsync(
        GetStrangerInfoDto dto
    )
    {
        return await CallApiAsync<GetStrangerInfoVo>("get_stranger_info", dto);
    }

    public async Task<BaseResponseVo<List<GetFriendListVo>>> GetFriendListAsync()
    {
        return await CallApiAsync<List<GetFriendListVo>>("get_friend_list", null);
    }

    public async Task<BaseResponseVo<GetGroupInfoVo>> GetGroupInfoAsync(GetGroupInfoDto dto)
    {
        return await CallApiAsync<GetGroupInfoVo>("get_group_info", dto);
    }

    public async Task<BaseResponseVo<List<GetGroupInfoVo>>> GetGroupListAsync()
    {
        return await CallApiAsync<List<GetGroupInfoVo>>("get_group_list", null);
    }

    public async Task<BaseResponseVo<GetGroupMemberInfoVo>> GetGroupMemberInfoAsync(
        GetGroupMemberInfoDto dto
    )
    {
        return await CallApiAsync<GetGroupMemberInfoVo>("get_group_member_info", dto);
    }

    public async Task<BaseResponseVo<List<GetGroupMemberInfoVo>>> GetGroupMemberListAsync(
        GetGroupMemberListDto dto
    )
    {
        return await CallApiAsync<List<GetGroupMemberInfoVo>>("get_group_member_list", dto);
    }

    public async Task<BaseResponseVo<GetGroupHonorInfoVo>> GetGroupHonorInfoAsync(
        GetGroupHonorInfoDto dto
    )
    {
        return await CallApiAsync<GetGroupHonorInfoVo>("get_group_honor_info", dto);
    }

    public async Task<BaseResponseVo<GetCookiesVo>> GetCookiesAsync(GetCookiesDto dto)
    {
        return await CallApiAsync<GetCookiesVo>("get_cookies", dto);
    }

    public async Task<BaseResponseVo<GetCsrfTokenVo>> GetCsrfTokenAsync()
    {
        return await CallApiAsync<GetCsrfTokenVo>("get_csrf_token", null);
    }

    public async Task<BaseResponseVo<GetCredentialsVo>> GetCredentialsAsync(GetCredentialsDto dto)
    {
        return await CallApiAsync<GetCredentialsVo>("get_credentials", dto);
    }

    public async Task<BaseResponseVo<GetRecordVo>> GetRecordAsync(GetRecordDto dto)
    {
        return await CallApiAsync<GetRecordVo>("get_record", dto);
    }

    public async Task<BaseResponseVo<GetImageVo>> GetImageAsync(GetImageDto dto)
    {
        return await CallApiAsync<GetImageVo>("get_image", dto);
    }

    public async Task<BaseResponseVo<CanSendImageVo>> CanSendImageAsync()
    {
        return await CallApiAsync<CanSendImageVo>("can_send_image", null);
    }

    public async Task<BaseResponseVo<CanSendRecordVo>> CanSendRecordAsync()
    {
        return await CallApiAsync<CanSendRecordVo>("can_send_record", null);
    }

    public async Task<BaseResponseVo<GetStatusVo>> GetStatusAsync()
    {
        return await CallApiAsync<GetStatusVo>("get_status", null);
    }

    public async Task<BaseResponseVo<GetVersionInfoVo>> GetVersionInfoAsync()
    {
        return await CallApiAsync<GetVersionInfoVo>("get_version_info", null);
    }

    public async Task<BaseResponseVo<EmptyVo>> SetRestartAsync(SetRestartDto dto)
    {
        return await CallApiAsync<EmptyVo>("set_restart", dto);
    }

    public async Task<BaseResponseVo<EmptyVo>> CleanCacheAsync()
    {
        return await CallApiAsync<EmptyVo>("clean_cache", null);
    }
}

public class OneBotV11HttpBot(OneBotV11Adapter adapter, long id, HttpServerConfig httpServerConfig)
    : IOneBotV11Bot
{
    public long SelfId { get; } = id;

    public OneBotV11Adapter Adapter { get; } = adapter;

    public HttpServerConfig HttpServerConfig { get; } = httpServerConfig;

    public async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        var httpServerConfig = HttpServerConfig;
        var httpClient = new HttpClient();
        if (!string.IsNullOrEmpty(httpServerConfig.Token))
        {
            httpClient.DefaultRequestHeaders.Add("Authorization", httpServerConfig.Token);
        }

        var response = await httpClient.PostAsJsonAsync(httpServerConfig.Url, @params);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            return null!;
        }

        var res =
            await response.Content.ReadFromJsonAsync<BaseResponseVo<TVo>>()
            ?? throw new NotSupportedException("not support null response");
        return res;
    }
}

public class OneBotV11WebSocketBot(OneBotV11Adapter adapter, long id, WebSocket webSocket)
    : IOneBotV11Bot
{
    public long SelfId { get; } = id;

    public OneBotV11Adapter Adapter { get; } = adapter;

    public WebSocket WebSocket { get; } = webSocket;

    public async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        var guid = Guid.NewGuid();
        Adapter.WebSocketResponses.Add(guid, null);
        await WebSocket.SendAsJsonAsync(
            new
            {
                action,
                @params,
                echo = guid,
            }
        );
        // 轮询查询结果
        var now = DateTime.Now;
        while (true)
        {
            var value = Adapter.WebSocketResponses[guid];
            if (value is null)
            {
                if (DateTime.Now - now > TimeSpan.FromSeconds(10))
                {
                    // 等待结果超时
                    Adapter.WebSocketResponses.Remove(guid);
                    throw new TimeoutException();
                }
                await Task.Delay(100);
                continue;
            }
            // 获取到结果，释放内存
            Adapter.WebSocketResponses.Remove(guid);
            var result =
                value.Value.Deserialize<BaseResponseVo<TVo>>()
                ?? throw new NotSupportedException("not support null response");
            return result;
        }
    }
}
