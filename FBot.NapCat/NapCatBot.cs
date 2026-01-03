using System.Net.WebSockets;
using FBot.NapCat.Apis.Dto;
using FBot.NapCat.Apis.Shared;
using FBot.NapCat.Apis.Vo;
using FBot.OneBotV11;

namespace FBot.NapCat;

public interface INapCatBot : IOneBotV11Bot
{
    /// <summary>
    /// 调用NapCat API接口
    /// </summary>
    /// <typeparam name="TVo">返回值类型</typeparam>
    /// <param name="action">API动作名称</param>
    /// <param name="params">请求参数</param>
    /// <returns>API响应结果</returns>
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

    // ========== User APIs ==========
    /// <summary>
    /// 设置QQ个人资料
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SetQQProfileAsync(SetQQProfileDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("set_qq_profile", dto);

    /// <summary>
    /// 发送Ark分享消息
    /// </summary>
    Task<BaseResponseVo<SendArkShareVo>> SendArkShareAsync(SendArkShareDto dto) =>
        CallApiAsync<SendArkShareVo>("send_ark_share", dto);

    /// <summary>
    /// 发送群组Ark分享消息
    /// </summary>
    Task<BaseResponseVo<string>> SendGroupArkShareAsync(SendGroupArkShareDto dto) =>
        CallApiAsync<string>("send_group_ark_share", dto);

    /// <summary>
    /// 设置在线状态
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetOnlineStatusAsync(SetOnlineStatusDto dto) =>
        CallApiAsync<EmptyVo>("set_online_status", dto);

    /// <summary>
    /// 获取好友列表（带分组）
    /// </summary>
    Task<BaseResponseVo<GetFriendsWithCategoryVo[]>> GetFriendsWithCategoryAsync(
        GetFriendsWithCategoryDto dto
    ) => CallApiAsync<GetFriendsWithCategoryVo[]>("get_friends_with_category", dto);

    /// <summary>
    /// 设置QQ头像
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetQqAvatarAsync(SetQqAvatarDto dto) =>
        CallApiAsync<EmptyVo>("set_qq_avatar", dto);

    /// <summary>
    /// 点赞好友
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SendLikeAsync(SendLikeDto dto) =>
        CallApiAsync<EmptyVo>("send_like", dto);

    /// <summary>
    /// 创建收藏
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> CreateCollectionAsync(CreateCollectionDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("create_collection", dto);

    /// <summary>
    /// 处理好友添加请求
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetFriendAddRequestAsync(SetFriendAddRequestDto dto) =>
        CallApiAsync<EmptyVo>("set_friend_add_request", dto);

    /// <summary>
    /// 设置个人签名
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SetSelfLongNickAsync(SetSelfLongNickDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("set_self_longnick", dto);

    /// <summary>
    /// 获取陌生人信息
    /// </summary>
    Task<BaseResponseVo<GetStrangerInfoVo>> GetStrangerInfoAsync(GetStrangerInfoDto dto) =>
        CallApiAsync<GetStrangerInfoVo>("get_stranger_info", dto);

    /// <summary>
    /// 获取好友列表
    /// </summary>
    Task<BaseResponseVo<GetStrangerInfoVo[]>> GetFriendListAsync(GetFriendListDto dto) =>
        CallApiAsync<GetStrangerInfoVo[]>("get_friend_list", dto);

    /// <summary>
    /// 获取主页点赞信息
    /// </summary>
    Task<BaseResponseVo<GetProfileLikeVo>> GetProfileLikeAsync(GetProfileLikeDto dto) =>
        CallApiAsync<GetProfileLikeVo>("get_profile_like", dto);

    /// <summary>
    /// 获取自定义表情
    /// </summary>
    Task<BaseResponseVo<string[]>> FetchCustomFaceAsync(FetchCustomFaceDto dto) =>
        CallApiAsync<string[]>("fetch_custom_face", dto);

    /// <summary>
    /// 上传私聊文件
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> UploadPrivateFileAsync(UploadPrivateFileDto dto) =>
        CallApiAsync<EmptyVo>("upload_private_file", dto);

    /// <summary>
    /// 删除好友
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> DeleteFriendAsync(DeleteFriendDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("delete_friend", dto);

    /// <summary>
    /// 获取用户状态
    /// </summary>
    Task<BaseResponseVo<GetUserStatusVo>> GetUserStatusAsync(GetUserStatusDto dto) =>
        CallApiAsync<GetUserStatusVo>("nc_get_user_status", dto);

    // ========== Group APIs ==========
    /// <summary>
    /// 群组踢人
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupKickAsync(SetGroupKickDto dto) =>
        CallApiAsync<EmptyVo>("set_group_kick", dto);

    /// <summary>
    /// 群组禁言成员
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupBanAsync(SetGroupBanDto dto) =>
        CallApiAsync<EmptyVo>("set_group_ban", dto);

    /// <summary>
    /// 获取群系统消息
    /// </summary>
    Task<BaseResponseVo<GetGroupSystemMsgVo>> GetGroupSystemMsgAsync(GetGroupSystemMsgDto dto) =>
        CallApiAsync<GetGroupSystemMsgVo>("get_group_system_msg", dto);

    /// <summary>
    /// 获取精华消息列表
    /// </summary>
    Task<BaseResponseVo<GetEssenceMsgListVo[]>> GetEssenceMsgListAsync(GetEssenceMsgListDto dto) =>
        CallApiAsync<GetEssenceMsgListVo[]>("get_essence_msg_list", dto);

    /// <summary>
    /// 群组全员禁言
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupWholeBanAsync(SetGroupWholeBanDto dto) =>
        CallApiAsync<EmptyVo>("set_group_whole_ban", dto);

    /// <summary>
    /// 设置群头像
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SetGroupPortraitAsync(SetGroupPortraitDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("set_group_portrait", dto);

    /// <summary>
    /// 设置群管理员
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupAdminAsync(SetGroupAdminDto dto) =>
        CallApiAsync<EmptyVo>("set_group_admin", dto);

    /// <summary>
    /// 设置精华消息
    /// </summary>
    Task<BaseResponseVo<SetEssenceMsgVo>> SetEssenceMsgAsync(SetEssenceMsgDto dto) =>
        CallApiAsync<SetEssenceMsgVo>("set_essence_msg", dto);

    /// <summary>
    /// 设置群成员名片
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupCardAsync(SetGroupCardDto dto) =>
        CallApiAsync<EmptyVo>("set_group_card", dto);

    /// <summary>
    /// 删除精华消息
    /// </summary>
    Task<BaseResponseVo<DeleteEssenceMsgVo>> DeleteEssenceMsgAsync(DeleteEssenceMsgDto dto) =>
        CallApiAsync<DeleteEssenceMsgVo>("delete_essence_msg", dto);

    /// <summary>
    /// 设置群名称
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupNameAsync(SetGroupNameDto dto) =>
        CallApiAsync<EmptyVo>("set_group_name", dto);

    /// <summary>
    /// 退出群组
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupLeaveAsync(SetGroupLeaveDto dto) =>
        CallApiAsync<EmptyVo>("set_group_leave", dto);

    /// <summary>
    /// 发送群公告
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SendGroupNoticeAsync(SendGroupNoticeDto dto) =>
        CallApiAsync<EmptyVo>("_send_group_notice", dto);

    /// <summary>
    /// 获取群公告列表
    /// </summary>
    Task<BaseResponseVo<GroupNoticeVo[]>> GetGroupNoticeAsync(GetGroupNoticeDto dto) =>
        CallApiAsync<GroupNoticeVo[]>("_get_group_notice", dto);

    /// <summary>
    /// 设置群成员专属头衔
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupSpecialTitleAsync(SetGroupSpecialTitleDto dto) =>
        CallApiAsync<EmptyVo>("set_group_special_title", dto);

    /// <summary>
    /// 上传群文件
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> UploadGroupFileAsync(UploadGroupFileDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("upload_group_file", dto);

    /// <summary>
    /// 处理群加群请求
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupAddRequestAsync(SetGroupAddRequestDto dto) =>
        CallApiAsync<EmptyVo>("set_group_add_request", dto);

    /// <summary>
    /// 获取群信息
    /// </summary>
    Task<BaseResponseVo<object>> GetGroupInfoAsync(GetGroupInfoDto dto) =>
        CallApiAsync<object>("get_group_info", dto);

    /// <summary>
    /// 获取群详细信息
    /// </summary>
    Task<BaseResponseVo<GetGroupInfoExVo>> GetGroupInfoExAsync(GetGroupInfoExDto dto) =>
        CallApiAsync<GetGroupInfoExVo>("get_group_info_ex", dto);

    /// <summary>
    /// 创建群文件文件夹
    /// </summary>
    Task<BaseResponseVo<CreateGroupFileFolderVo>> CreateGroupFileFolderAsync(
        CreateGroupFileFolderDto dto
    ) => CallApiAsync<CreateGroupFileFolderVo>("create_group_file_folder", dto);

    /// <summary>
    /// 删除群文件
    /// </summary>
    Task<BaseResponseVo<DeleteGroupFileVo>> DeleteGroupFileAsync(DeleteGroupFileDto dto) =>
        CallApiAsync<DeleteGroupFileVo>("delete_group_file", dto);

    /// <summary>
    /// 删除群文件夹
    /// </summary>
    Task<BaseResponseVo<DeleteGroupFolderVo>> DeleteGroupFolderAsync(DeleteGroupFolderDto dto) =>
        CallApiAsync<DeleteGroupFolderVo>("delete_group_folder", dto);

    /// <summary>
    /// 获取群文件系统信息
    /// </summary>
    Task<BaseResponseVo<GetGroupFileSystemInfoVo>> GetGroupFileSystemInfoAsync(
        GetGroupFileSystemInfoDto dto
    ) => CallApiAsync<GetGroupFileSystemInfoVo>("get_group_file_system_info", dto);

    /// <summary>
    /// 获取群根目录文件列表
    /// </summary>
    Task<BaseResponseVo<GetGroupRootFilesVo[]>> GetGroupRootFilesAsync(GetGroupRootFilesDto dto) =>
        CallApiAsync<GetGroupRootFilesVo[]>("get_group_root_files", dto);

    /// <summary>
    /// 获取文件夹内文件列表
    /// </summary>
    Task<BaseResponseVo<GetGroupFilesByFolderVo>> GetGroupFilesByFolderAsync(
        GetGroupFilesByFolderDto dto
    ) => CallApiAsync<GetGroupFilesByFolderVo>("get_group_files_by_folder", dto);

    /// <summary>
    /// 获取群文件下载链接
    /// </summary>
    Task<BaseResponseVo<GetGroupFileUrlVo>> GetGroupFileUrlAsync(GetGroupFileUrlDto dto) =>
        CallApiAsync<GetGroupFileUrlVo>("get_group_file_url", dto);

    /// <summary>
    /// 获取群列表
    /// </summary>
    Task<BaseResponseVo<object[]>> GetGroupListAsync(GetGroupListDto dto) =>
        CallApiAsync<object[]>("get_group_list", dto);

    /// <summary>
    /// 获取群成员信息
    /// </summary>
    Task<BaseResponseVo<object>> GetGroupMemberInfoAsync(GetGroupMemberInfoDto dto) =>
        CallApiAsync<object>("get_group_member_info", dto);

    /// <summary>
    /// 获取群成员列表
    /// </summary>
    Task<BaseResponseVo<object[]>> GetGroupMemberListAsync(GetGroupMemberListDto dto) =>
        CallApiAsync<object[]>("get_group_member_list", dto);

    /// <summary>
    /// 获取群荣誉信息
    /// </summary>
    Task<BaseResponseVo<GetGroupHonorInfoVo>> GetGroupHonorInfoAsync(GetGroupHonorInfoDto dto) =>
        CallApiAsync<GetGroupHonorInfoVo>("get_group_honor_info", dto);

    /// <summary>
    /// 获取群@全体成员剩余次数
    /// </summary>
    Task<BaseResponseVo<GetGroupAtAllRemainVo>> GetGroupAtAllRemainAsync(
        GetGroupAtAllRemainDto dto
    ) => CallApiAsync<GetGroupAtAllRemainVo>("get_group_at_all_remain", dto);

    /// <summary>
    /// 获取群忽略的通知列表
    /// </summary>
    Task<BaseResponseVo<GetGroupIgnoredNotifiesVo>> GetGroupIgnoredNotifiesAsync(
        GetGroupIgnoredNotifiesDto dto
    ) => CallApiAsync<GetGroupIgnoredNotifiesVo>("get_group_ignored_notifies", dto);

    /// <summary>
    /// 设置群签到
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetGroupSignAsync(SetGroupSignDto dto) =>
        CallApiAsync<EmptyVo>("set_group_sign", dto);

    /// <summary>
    /// 发送群签到
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SendGroupSignAsync(SendGroupSignDto dto) =>
        CallApiAsync<EmptyVo>("send_group_sign", dto);

    /// <summary>
    /// 获取AI角色列表
    /// </summary>
    Task<BaseResponseVo<GetAiCharactersVo[]>> GetAiCharactersAsync(GetAiCharactersDto dto) =>
        CallApiAsync<GetAiCharactersVo[]>("get_ai_characters", dto);

    /// <summary>
    /// 发送群AI记录
    /// </summary>
    Task<BaseResponseVo<SendGroupAiRecordVo>> SendGroupAiRecordAsync(SendGroupAiRecordDto dto) =>
        CallApiAsync<SendGroupAiRecordVo>("send_group_ai_record", dto);

    /// <summary>
    /// 获取AI记录
    /// </summary>
    Task<BaseResponseVo<string>> GetAiRecordAsync(GetAiRecordDto dto) =>
        CallApiAsync<string>("get_ai_record", dto);

    // ========== System APIs ==========
    /// <summary>
    /// 获取在线客户端列表
    /// </summary>
    Task<BaseResponseVo<GetOnlineClientsVo>> GetOnlineClientsAsync(GetOnlineClientsDto dto) =>
        CallApiAsync<GetOnlineClientsVo>("get_online_clients", dto);

    /// <summary>
    /// 获取机器人账号范围
    /// </summary>
    Task<BaseResponseVo<GetRobotUinRangeVo[]>> GetRobotUinRangeAsync(GetRobotUinRangeDto dto) =>
        CallApiAsync<GetRobotUinRangeVo[]>("get_robot_uin_range", dto);

    /// <summary>
    /// OCR图片识别
    /// </summary>
    Task<BaseResponseVo<OcrImageVo[]>> OcrImageAsync(OcrImageDto dto) =>
        CallApiAsync<OcrImageVo[]>("ocr_image", dto);

    /// <summary>
    /// OCR图片识别（点选）
    /// </summary>
    Task<BaseResponseVo<OcrImageVo[]>> OcrImageDotAsync(OcrImageDto dto) =>
        CallApiAsync<OcrImageVo[]>(".ocr_image", dto);

    /// <summary>
    /// 英文转中文翻译
    /// </summary>
    Task<BaseResponseVo<string[]>> TranslateEn2ZhAsync(TranslateEn2ZhDto dto) =>
        CallApiAsync<string[]>("translate_en2zh", dto);

    /// <summary>
    /// 获取登录信息
    /// </summary>
    new Task<BaseResponseVo<GetLoginInfoVo>> GetLoginInfoAsync() =>
        CallApiAsync<GetLoginInfoVo>("get_login_info", null);

    /// <summary>
    /// 设置输入状态
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SetInputStatusAsync(SetInputStatusDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("set_input_status", dto);

    /// <summary>
    /// 下载文件
    /// </summary>
    Task<BaseResponseVo<DownloadFileVo>> DownloadFileAsync(DownloadFileDto dto) =>
        CallApiAsync<DownloadFileVo>("download_file", dto);

    /// <summary>
    /// 获取Cookies
    /// </summary>
    Task<BaseResponseVo<GetCookiesVo>> GetCookiesAsync(GetCookiesDto dto) =>
        CallApiAsync<GetCookiesVo>("get_cookies", dto);

    /// <summary>
    /// 处理快速操作
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> HandleQuickOperationAsync(HandleQuickOperationDto dto) =>
        CallApiAsync<EmptyVo>(".handle_quick_operation", dto);

    /// <summary>
    /// 获取CSRF Token
    /// </summary>
    Task<BaseResponseVo<GetCsrfTokenVo>> GetCsrfTokenAsync(GetCsrfTokenDto dto) =>
        CallApiAsync<GetCsrfTokenVo>("get_csrf_token", null);

    /// <summary>
    /// 删除群公告
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> DelGroupNoticeAsync(DelGroupNoticeDto dto) =>
        CallApiAsync<EmptyVo>("_del_group_notice", dto);

    /// <summary>
    /// 获取凭证
    /// </summary>
    Task<BaseResponseVo<GetCredentialsVo>> GetCredentialsAsync(GetCredentialsDto dto) =>
        CallApiAsync<GetCredentialsVo>("get_credentials", dto);

    /// <summary>
    /// 获取模型展示
    /// </summary>
    Task<BaseResponseVo<GetModelShowVo[]>> GetModelShowAsync(GetModelShowDto dto) =>
        CallApiAsync<GetModelShowVo[]>("_get_model_show", dto);

    /// <summary>
    /// 设置模型展示
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> SetModelShowAsync(SetModelShowDto dto) =>
        CallApiAsync<EmptyVo>("_set_model_show", dto);

    /// <summary>
    /// 检查是否可发送图片
    /// </summary>
    Task<BaseResponseVo<CanSendImageVo>> CanSendImageAsync(CanSendImageDto dto) =>
        CallApiAsync<CanSendImageVo>("can_send_image", null);

    /// <summary>
    /// 获取红包状态
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> GetPacketStatusAsync(GetPacketStatusDto dto) =>
        CallApiAsync<EmptyVo>("nc_get_packet_status", null);

    /// <summary>
    /// 检查是否可发送语音
    /// </summary>
    Task<BaseResponseVo<CanSendRecordVo>> CanSendRecordAsync(CanSendRecordDto dto) =>
        CallApiAsync<CanSendRecordVo>("can_send_record", null);

    /// <summary>
    /// 获取状态
    /// </summary>
    Task<BaseResponseVo<GetStatusVo>> GetStatusAsync(GetStatusDto dto) =>
        CallApiAsync<GetStatusVo>("get_status", null);

    /// <summary>
    /// 获取Rkey
    /// </summary>
    Task<BaseResponseVo<GetRkeyVo[]>> GetRkeyAsync(GetRkeyDto dto) =>
        CallApiAsync<GetRkeyVo[]>("nc_get_rkey", null);

    /// <summary>
    /// 获取版本信息
    /// </summary>
    Task<BaseResponseVo<GetVersionInfoVo>> GetVersionInfoAsync(GetVersionInfoDto dto) =>
        CallApiAsync<GetVersionInfoVo>("get_version_info", null);

    /// <summary>
    /// 获取群禁言列表
    /// </summary>
    Task<BaseResponseVo<GetGroupShutListVo>> GetGroupShutListAsync(GetGroupShutListDto dto) =>
        CallApiAsync<GetGroupShutListVo>("get_group_shut_list", dto);

    // ========== Message APIs ==========
    /// <summary>
    /// 标记消息为已读
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> MarkMsgAsReadAsync(MarkMsgAsReadDto dto) =>
        CallApiAsync<EmptyVo>("mark_msg_as_read", dto);

    /// <summary>
    /// 标记群消息为已读
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> MarkGroupMsgAsReadAsync(MarkGroupMsgAsReadDto dto) =>
        CallApiAsync<EmptyVo>("mark_group_msg_as_read", dto);

    /// <summary>
    /// 标记私聊消息为已读
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> MarkPrivateMsgAsReadAsync(MarkPrivateMsgAsReadDto dto) =>
        CallApiAsync<EmptyVo>("mark_private_msg_as_read", dto);

    /// <summary>
    /// 撤回消息
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> DeleteMsgAsync(DeleteMsgDto dto) =>
        CallApiAsync<EmptyVo>("delete_msg", dto);

    /// <summary>
    /// 获取消息
    /// </summary>
    Task<BaseResponseVo<object>> GetMsgAsync(GetMsgDto dto) => CallApiAsync<object>("get_msg", dto);

    /// <summary>
    /// 获取图片
    /// </summary>
    Task<BaseResponseVo<object>> GetImageAsync(GetImageDto dto) =>
        CallApiAsync<object>("get_image", dto);

    /// <summary>
    /// 获取语音
    /// </summary>
    Task<BaseResponseVo<object>> GetRecordAsync(GetRecordDto dto) =>
        CallApiAsync<object>("get_record", dto);

    /// <summary>
    /// 获取文件
    /// </summary>
    Task<BaseResponseVo<object>> GetFileAsync(GetFileDto dto) =>
        CallApiAsync<object>("get_file", dto);

    /// <summary>
    /// 获取群消息历史记录
    /// </summary>
    Task<BaseResponseVo<GetGroupMsgHistoryVo>> GetGroupMsgHistoryAsync(GetGroupMsgHistoryDto dto) =>
        CallApiAsync<GetGroupMsgHistoryVo>("get_group_msg_history", dto);

    /// <summary>
    /// 设置消息表情点赞
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SetMsgEmojiLikeAsync(SetMsgEmojiLikeDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("set_msg_emoji_like", dto);

    /// <summary>
    /// 获取好友消息历史记录
    /// </summary>
    Task<BaseResponseVo<GetGroupMsgHistoryVo>> GetFriendMsgHistoryAsync(
        GetFriendMsgHistoryDto dto
    ) => CallApiAsync<GetGroupMsgHistoryVo>("get_friend_msg_history", dto);

    /// <summary>
    /// 获取最近联系人
    /// </summary>
    Task<BaseResponseVo<GetRecentContactVo[]>> GetRecentContactAsync(GetRecentContactDto dto) =>
        CallApiAsync<GetRecentContactVo[]>("get_recent_contact", dto);

    /// <summary>
    /// 获取表情点赞列表
    /// </summary>
    Task<BaseResponseVo<FetchEmojiLikeVo>> FetchEmojiLikeAsync(FetchEmojiLikeDto dto) =>
        CallApiAsync<FetchEmojiLikeVo>("fetch_emoji_like", dto);

    /// <summary>
    /// 获取转发消息
    /// </summary>
    Task<BaseResponseVo<object>> GetForwardMsgAsync(GetForwardMsgDto dto) =>
        CallApiAsync<object>("get_forward_msg", dto);

    /// <summary>
    /// 发送转发消息
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SendForwardMsgAsync(SendForwardMsgDto dto) =>
        CallApiAsync<CommonResponseDataSchema>("send_forward_msg", dto);

    /// <summary>
    /// 发送群消息
    /// </summary>
    Task<BaseResponseVo<SendGroupMsgVo>> SendGroupMsgAsync(SendGroupMsgDto dto) =>
        CallApiAsync<SendGroupMsgVo>("send_group_msg", dto);

    /// <summary>
    /// 发送群转发消息
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SendGroupForwardMsgAsync(
        SendGroupForwardMsgDto dto
    ) => CallApiAsync<CommonResponseDataSchema>("send_group_forward_msg", dto);

    /// <summary>
    /// 转发单条群消息
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> ForwardGroupSingleMsgAsync(
        ForwardGroupSingleMsgDto dto
    ) => CallApiAsync<CommonResponseDataSchema>("forward_group_single_msg", dto);

    /// <summary>
    /// 群组戳一戳
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> GroupPokeAsync(GroupPokeDto dto) =>
        CallApiAsync<EmptyVo>("group_poke", dto);

    /// <summary>
    /// 发送私聊消息
    /// </summary>
    Task<BaseResponseVo<SendPrivateMsgVo>> SendPrivateMsgAsync(SendPrivateMsgDto dto) =>
        CallApiAsync<SendPrivateMsgVo>("send_private_msg", dto);

    /// <summary>
    /// 发送私聊转发消息
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> SendPrivateForwardMsgAsync(
        SendPrivateForwardMsgDto dto
    ) => CallApiAsync<CommonResponseDataSchema>("send_private_forward_msg", dto);

    /// <summary>
    /// 转发单条好友消息
    /// </summary>
    Task<BaseResponseVo<CommonResponseDataSchema>> ForwardFriendSingleMsgAsync(
        ForwardFriendSingleMsgDto dto
    ) => CallApiAsync<CommonResponseDataSchema>("forward_friend_single_msg", dto);

    /// <summary>
    /// 私聊戳一戳
    /// </summary>
    Task<BaseResponseVo<EmptyVo>> PrivatePokeAsync(PrivatePokeDto dto) =>
        CallApiAsync<EmptyVo>("group_poke", dto);
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
