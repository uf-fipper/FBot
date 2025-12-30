using System.Net.WebSockets;
using FBot.NapCat.Apis.Dto;
using FBot.NapCat.Apis.Shared;
using FBot.NapCat.Apis.Vo;
using FBot.OneBotV11;

namespace FBot.NapCat;

public interface INapCatBot : IOneBotV11Bot
{
    new Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params);

    async Task<OneBotV11.Apis.Vo.BaseResponseVo<TVo>> IOneBotV11Bot.CallApiAsync<TVo>(
        string action,
        object? @params
    )
    {
        var result = await CallApiAsync<TVo>(action, @params);
        return new OneBotV11.Apis.Vo.BaseResponseVo<TVo>
        {
            Status = result.Status switch
            {
                BaseResponseVoStatus.Ok => OneBotV11.Apis.Vo.BaseResponseVoStatus.Ok,
                BaseResponseVoStatus.Error => OneBotV11.Apis.Vo.BaseResponseVoStatus.Failed,
                _ => throw new NotSupportedException(),
            },
            Retcode = result.Retcode,
            Data = result.Data,
            ExtensionData = result.ExtensionData,
        };
    }

    public Task<BaseResponseVo<CommonResponseDataSchema>> SetQQProfileAsync(SetQQProfileDto dto)
    {
        return CallApiAsync<CommonResponseDataSchema>("set_qq_profile", dto);
    }

    public Task<BaseResponseVo<SendArkShareVo>> SendArkShareAsync(SendArkShareDto dto)
    {
        return CallApiAsync<SendArkShareVo>("send_ark_share", dto);
    }
}

public class NapCatHttpBot(NapCatAdapter adapter, long id, HttpServerConfig httpServerConfig)
    : OneBotV11HttpBot(adapter, id, httpServerConfig),
        INapCatBot
{
    public new async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        var oneBotResult = await base.CallApiAsync<TVo>(action, @params);
        var napCatResult = new BaseResponseVo<TVo>
        {
            Status = oneBotResult.Status switch
            {
                OneBotV11.Apis.Vo.BaseResponseVoStatus.Ok => BaseResponseVoStatus.Ok,
                OneBotV11.Apis.Vo.BaseResponseVoStatus.Async => BaseResponseVoStatus.Ok,
                OneBotV11.Apis.Vo.BaseResponseVoStatus.Failed => BaseResponseVoStatus.Error,
                _ => throw new NotSupportedException(),
            },
            Retcode = oneBotResult.Retcode,
            Data = oneBotResult.Data,
            ExtensionData = oneBotResult.ExtensionData,
        };
        if (
            oneBotResult.ExtensionData.TryGetValue("message", out var messageObj)
            && messageObj.ValueKind == System.Text.Json.JsonValueKind.String
        )
        {
            napCatResult.Message = messageObj.GetString() ?? string.Empty;
        }
        if (
            oneBotResult.ExtensionData.TryGetValue("wording", out var wordingObj)
            && wordingObj.ValueKind == System.Text.Json.JsonValueKind.String
        )
        {
            napCatResult.Wording = wordingObj.GetString() ?? string.Empty;
        }
        return napCatResult;
    }
}

public class NapCatWebSocketBot(NapCatAdapter adapter, long id, WebSocket webSocket)
    : OneBotV11WebSocketBot(adapter, id, webSocket),
        INapCatBot
{
    public new async Task<BaseResponseVo<TVo>> CallApiAsync<TVo>(string action, object? @params)
    {
        var oneBotResult = await base.CallApiAsync<TVo>(action, @params);
        var napCatResult = new BaseResponseVo<TVo>
        {
            Status = oneBotResult.Status switch
            {
                OneBotV11.Apis.Vo.BaseResponseVoStatus.Ok => BaseResponseVoStatus.Ok,
                OneBotV11.Apis.Vo.BaseResponseVoStatus.Async => BaseResponseVoStatus.Ok,
                OneBotV11.Apis.Vo.BaseResponseVoStatus.Failed => BaseResponseVoStatus.Error,
                _ => throw new NotSupportedException(),
            },
            Retcode = oneBotResult.Retcode,
            Data = oneBotResult.Data,
            ExtensionData = oneBotResult.ExtensionData,
        };
        if (
            oneBotResult.ExtensionData.TryGetValue("message", out var messageObj)
            && messageObj.ValueKind == System.Text.Json.JsonValueKind.String
        )
        {
            napCatResult.Message = messageObj.GetString() ?? string.Empty;
        }
        if (
            oneBotResult.ExtensionData.TryGetValue("wording", out var wordingObj)
            && wordingObj.ValueKind == System.Text.Json.JsonValueKind.String
        )
        {
            napCatResult.Wording = wordingObj.GetString() ?? string.Empty;
        }
        return napCatResult;
    }
}
