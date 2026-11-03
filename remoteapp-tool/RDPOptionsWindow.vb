Public Class RDPOptionsWindow

    ' Array to store the all RDP options
    ' Each row represents an RDP option with its name, type, default value, and description
    Dim optionsList As String(,) = {
        {"administrative_session", "administrative session", "i", "0", "连接到远程计算机的管理会话。\n\n0 - 不使用管理会话。\n1 - 连接到管理会话。", ""},
        {"allow_desktop_composition", "allow desktop composition", "i", "0", "确定登录远程计算机时是否允许桌面合成（Aero 需要）。\n\n0 - 在远程会话中禁用桌面合成。\n1 - 允许桌面合成。", ""},
        {"allow_font_smoothing", "allow font smoothing", "i", "0", "确定远程会话中是否可以使用字体平滑。\n\n0 - 在远程会话中禁用字体平滑。\n1 - 允许字体平滑。", ""},
        {"audiocapturemode", "audiocapturemode", "i", "0", "确定连接到远程计算机时如何处理本地计算机捕获（录制）的声音。\n\n0 - 不捕获本地计算机的音频。\n1 - 捕获本地计算机的音频并发送到远程计算机。", ""},
        {"audiomode", "audiomode", "i", "0", "确定连接到远程计算机时如何处理远程计算机上的声音。\n\n0 - 在本地计算机上播放声音。\n1 - 在远程计算机上播放声音。\n2 - 不播放声音。", ""},
        {"audioqualitymode", "audioqualitymode", "i", "0", "确定远程会话中播放的音频质量。\n\n0 - 根据可用带宽动态调整音频质量。\n1 - 始终使用中等音频质量。\n2 - 始终使用未压缩音频质量。", ""},
        {"authentication_level", "authentication level", "i", "2", "确定服务器身份验证失败时应执行的操作。\n\n0 - 如果服务器身份验证失败，仍在不发出警告的情况下连接。\n1 - 如果服务器身份验证失败，则不连接。\n2 - 如果服务器身份验证失败，则显示警告并允许用户选择是否连接。\n3 - 不需要服务器身份验证。", ""},
        {"autoreconnect_max_retries", "autoreconnect max retries", "i", "20", "确定连接断开后，客户端计算机尝试重新连接远程计算机的最大次数。\n注意：远程桌面支持的最大值为 200。", ""},
        {"autoreconnection_enabled", "autoreconnection enabled", "i", "1", "确定连接断开后，客户端计算机是否自动尝试重新连接远程计算机。\n\n0 - 不尝试重新连接。\n1 - 尝试重新连接。", ""},
        {"bandwidthautodetect", "bandwidthautodetect", "i", "1", "启用自动检测网络类型的选项。与 networkautodetect 一起使用。另请参阅 connection type。\n\n0 - 不启用自动网络检测选项。\n1 - 启用自动网络检测选项。", ""},
        {"bitmapcachepersistenable", "bitmapcachepersistenable", "i", "1", "确定是否在本地计算机上缓存位图（基于磁盘的缓存）。位图缓存可以提高远程会话的性能。\n\n0 - 不缓存位图。\n1 - 缓存位图。", ""},
        {"bitmapcachesize", "bitmapcachesize", "i", "1500", "指定基于内存的位图缓存大小（KB）。最大值为 32000。", ""},
        {"camerastoredirect", "camerastoredirect", "s", "", "配置要重定向的摄像头。此设置使用分号分隔的 KSCATEGORY_VIDEO_CAMERA 接口列表，指定允许重定向的摄像头。", ""},
        {"compression", "compression", "i", "1", "确定连接是否使用批量压缩。\n\n0 - 不使用批量压缩。\n1 - 使用批量压缩。", ""},
        {"connect_to_console", "connect to console", "i", "0", "连接到远程计算机的控制台会话。\n\n0 - 连接到普通会话。\n1 - 连接到控制台屏幕。", "1"},
        {"connection_type", "connection type", "i", "2", "指定远程桌面会话的预定义性能设置。\n\n1 - 调制解调器（56 Kbps）。\n2 - 低速宽带（256 Kbps - 2 Mbps）。\n3 - 卫星（2 Mbps - 16 Mbps，高延迟）。\n4 - 高速宽带（2 Mbps - 10 Mbps）。\n5 - WAN（10 Mbps 或更高，高延迟）。\n6 - LAN（10 Mbps 或更高）。\n7 - 自动带宽检测。需要 bandwidthautodetect。\n\n此设置本身不起作用。在 RDC 图形界面中选择后，它会更改若干性能相关设置（主题、动画、字体平滑等）。这些单独设置始终优先于 connection type 设置。", ""},
        {"desktop_size_id", "desktop size id", "i", "0", "指定远程会话桌面的预定义尺寸。\n\n0 - 640x480。\n1 - 800x600。\n2 - 1024x768。\n3 - 1280x1024。\n4 - 1600x1200。\n\n如果已指定 /w 和 /h，或 desktopwidth 和 desktopheight，则忽略此设置。", ""},
        {"desktopheight", "desktopheight", "i", "600", "远程会话桌面的高度（像素）。", ""},
        {"desktopscalefactor", "desktopscalefactor", "i", "", "指定远程会话的缩放比例，使内容显示得更大。\n\n支持的值：\n以下列表中的数值：100、125、150、175、200、250、300、400、500\n\n注意：desktopscalefactor 属性已弃用，即将不可用。", ""},
        {"desktopwidth", "desktopwidth", "i", "800", "远程会话桌面的宽度（像素）。", ""},
        {"devicestoredirect", "devicestoredirect", "s", "", "确定客户端计算机上哪些受支持的即插即用设备将被重定向并在远程会话中可用。\n\n未指定值 - 不重定向任何受支持的即插即用设备。\n* - 重定向所有受支持的即插即用设备，包括稍后连接的设备。\nDynamicDevices - 重定向稍后连接的任何受支持的即插即用设备。\n一个或多个即插即用设备的硬件 ID - 重定向指定的受支持即插即用设备。", ""},
        {"disable_ctrl+alt+del", "disable ctrl+alt+del", "i", "1", "确定连接到远程计算机后，在输入凭据之前是否必须按 CTRL+ALT+DELETE。\n\n0 - 登录前需要按 CTRL+ALT+DELETE。\n1 - 不需要按 CTRL+ALT+DELETE，可以立即登录。\n\n注意：禁用时，此设置还会将自动登录延迟到用户按下 CTRL+ALT+DELETE 之后。", ""},
        {"disable_full_window_drag", "disable full window drag", "i", "1", "确定将窗口拖到新位置时是否显示窗口内容。\n\n0 - 拖动时显示窗口内容。\n1 - 拖动时只显示窗口轮廓。", ""},
        {"disable_menu_anims", "disable menu anims", "i", "1", "确定远程会话中菜单和窗口是否可以使用动画效果显示。\n\n0 - 允许菜单和窗口动画。\n1 - 不使用菜单和窗口动画。", ""},
        {"disable_themes", "disable themes", "i", "0", "确定登录远程计算机时是否允许主题。\n\n0 - 允许主题。\n1 - 在远程会话中禁用主题。", ""},
        {"disable_wallpaper", "disable wallpaper", "i", "1", "确定远程会话中是否显示桌面背景。\n\n0 - 显示壁纸。\n1 - 不显示任何壁纸。", ""},
        {"disableconnectionsharing", "disableconnectionsharing", "i", "0", "确定每次使用相同凭据启动指向同一计算机的 RemoteApp 时，是否启动新的终端服务器会话。\n\n0 - 不启动新会话，共享用户当前的活动会话。\n1 - 为 RemoteApp 启动新的登录会话。", ""},
        {"disableremoteappcapscheck", "disableremoteappcapscheck", "i", "0", "指定远程桌面客户端是否应检查远程计算机的 RemoteApp 功能。\n0 - 登录前检查远程计算机的 RemoteApp 功能。\n1 - 不检查远程计算机的 RemoteApp 功能。注意：连接到配置了 RemoteApp 的 Windows XP SP3、Vista 或 7 计算机时，此设置必须为 1。", ""},
        {"displayconnectionbar", "displayconnectionbar", "i", "1", "确定全屏模式下是否显示连接栏。\n\n0 - 不显示连接栏。\n1 - 显示连接栏。", ""},
        {"domain", "domain", "s", "", "指定用户所在的域名称。", ""},
        {"drivestoredirect", "drivestoredirect", "s", "", "确定客户端计算机上的哪些本地磁盘驱动器将被重定向并在远程会话中可用。\n\n未指定值 - 不重定向任何驱动器。\n* - 重定向所有磁盘驱动器，包括稍后连接的驱动器。\nDynamicDrives - 重定向稍后连接的任何驱动器。\n一个或多个驱动器的盘符和标签 - 重定向指定的驱动器。", ""},
        {"dynamic_resolution", "dynamic resolution", "i", "1", "确定本地窗口大小改变时，远程会话的分辨率是否自动更新。\n\n0 - 会话期间分辨率保持不变。\n1 - 随本地窗口大小调整更新会话分辨率。", ""},
        {"enablecredsspsupport", "enablecredsspsupport", "i", "1", "确定远程桌面在可用时是否使用 CredSSP 进行身份验证。\n\n0 - 即使操作系统支持，也不使用 CredSSP。\n1 - 如果操作系统支持，则使用 CredSSP。", ""},
        {"enablerdsaadauth", "enablerdsaadauth", "i", "0", "确定客户端是否使用 Microsoft Entra ID 向远程 PC 进行身份验证。与 Azure 虚拟桌面配合使用时，这可提供单一登录体验。此属性替代 targetisaadjoined。\n\n0 - 即使远程 PC 支持，连接也不使用 Microsoft Entra 身份验证。\n1 - 如果远程 PC 支持，连接将使用 Microsoft Entra 身份验证。", ""},
        {"enablesuperpan", "enablesuperpan", "i", "0", "确定是否启用 SuperPan。当远程桌面的尺寸大于当前客户端窗口时，SuperPan 允许用户在全屏模式下无需滚动条浏览远程桌面。用户可以将鼠标指向窗口边缘，桌面视图会自动向该方向滚动。\n\n0 - 不使用 SuperPan。远程会话窗口大小与客户端窗口大小一致。\n1 - 启用 SuperPan。远程会话窗口大小由 /w 和 /h 或 desktopwidth 和 desktopheight 指定。", ""},
        {"encode_redirected_video_capture", "encode redirected video capture", "i", "1", "启用或禁用重定向视频的编码。\n\n0 - 禁用重定向视频的编码。\n\n1 - 启用重定向视频的编码。", ""},
        {"gatewaycredentialssource", "gatewaycredentialssource", "i", "4", "指定用于验证与 RD 网关连接的凭据。\n\n0 - 询问密码（NTLM）。\n1 - 使用智能卡。\n4 - 允许用户稍后选择。", ""},
        {"kdcproxyname", "kdcproxyname", "s", "", "指定 KDC 代理的完全限定域名。", ""},
        {"keyboardhook", "keyboardhook", "i", "2", "确定连接到远程计算机时 Windows 组合键的应用方式。\n\n0 - Windows 组合键应用于本地计算机。\n1 - Windows 组合键应用于远程计算机。\n2 - 仅在全屏模式下应用 Windows 组合键。", ""},
        {"maximizetocurrentdisplays", "maximizetocurrentdisplays", "i", "0", "确定最大化时远程会话在哪些显示器上全屏显示。需要将 use multimon 设置为 1。仅在 Windows 版 Windows 应用和 Windows 版远程桌面应用中可用。\n\n0 - 最大化时会话在最初选定的显示器上全屏显示。\n1 - 最大化时会话在窗口跨越的显示器上动态全屏显示。", ""},
        {"negotiate_security_layer", "negotiate security layer", "i", "1", "确定是否协商安全级别。\n\n0 - 不启用安全层协商，会话使用安全套接字层 (SSL) 启动。\n1 - 启用安全层协商，会话使用 x.224 加密启动。", ""},
        {"networkautodetect", "networkautodetect", "i", "1", "确定是否使用自动网络带宽检测。需要设置 bandwidthautodetect 选项，并与 connection type 7 对应。\n\n0 - 使用自动网络带宽检测。\n1 - 不使用自动网络带宽检测。", ""},
        {"pinconnectionbar", "pinconnectionbar", "i", "1", "确定全屏模式下连接时，连接栏是否应固定在远程会话顶部。\n\n0 - 连接栏不应固定在远程会话顶部。\n1 - 连接栏应固定在远程会话顶部。", ""},
        {"prompt_for_credentials", "prompt for credentials", "i", "0", "确定连接到已保存凭据的远程计算机时，远程桌面连接是否提示输入凭据。\n\n0 - 远程桌面将使用已保存的凭据，不提示输入。\n1 - 远程桌面将提示输入凭据。", ""},
        {"prompt_for_credentials_on_client", "prompt for credentials on client", "i", "0", "确定连接到不支持服务器身份验证的服务器时，远程桌面连接是否提示输入凭据。\n\n0 - 远程桌面不提示输入凭据。\n1 - 远程桌面提示输入凭据。", ""},
        {"promptcredentialonce", "promptcredentialonce", "i", "1", "通过 RD 网关连接时，确定 RDC 是否对 RD 网关和远程计算机使用相同的凭据。\n\n0 - 远程桌面不使用相同凭据。\n1 - 远程桌面对 RD 网关和远程计算机使用相同凭据。", ""},
        {"public_mode", "public mode", "i", "0", "确定远程桌面连接是否以公共模式启动。\n\n0 - 远程桌面不以公共模式启动。\n1 - 远程桌面以公共模式启动，并且不在本地计算机上保存任何用户数据（凭据、位图缓存、MRU）。", ""},
        {"redirectclipboard", "redirectclipboard", "i", "1", "确定客户端计算机上的剪贴板是否将被重定向并在远程会话中可用，反之亦然。\n\n0 - 不重定向剪贴板。\n1 - 重定向剪贴板。", ""},
        {"redirectcomports", "redirectcomports", "i", "0", "确定客户端计算机上的 COM（串行）端口是否将被重定向并在远程会话中可用。\n\n0 - 本地计算机的 COM 端口在远程会话中不可用。\n1 - 本地计算机的 COM 端口在远程会话中可用。", ""},
        {"redirectdirectx", "redirectdirectx", "i", "1", "确定是否为远程会话启用 DirectX。\n\n0 - 不启用 DirectX 呈现。\n1 - 在远程会话中启用 DirectX 呈现。", ""},
        {"redirectdrives", "redirectdrives", "i", "0", "确定客户端计算机上的本地磁盘驱动器是否将被重定向并在远程会话中可用。\n\n0 - 本地计算机的驱动器在远程会话中不可用。\n1 - 本地计算机的驱动器在远程会话中可用。\n\n注意：从 RDC 6.0 起，此设置已被 drivestoredirect 取代。", "1"},
        {"redirected_video_capture_encoding_quality", "redirected video capture encoding quality", "i", "0", "控制编码视频的质量。\n\n0 - 高压缩视频。画面运动较多时质量可能下降。\n1 - 中等压缩。\n2 - 低压缩视频，画面质量高。", ""},
        {"redirectlocation", "redirectlocation", "i", "0", "确定本地设备的位置信息是否将被重定向并在远程会话中可用。\n\n0 - 远程会话使用远程计算机的位置。\n1 - 远程会话使用本地设备的位置。", ""},
        {"redirectposdevices", "redirectposdevices", "i", "0", "确定连接到客户端计算机的 Microsoft Point of Service (POS) for .NET 设备是否将被重定向并在远程会话中可用。\n\n0 - 本地计算机的 POS 设备在远程会话中不可用。\n1 - 本地计算机的 POS 设备在远程会话中可用。", ""},
        {"redirectprinters", "redirectprinters", "i", "1", "确定客户端计算机上配置的打印机是否将被重定向并在远程会话中可用。\n\n0 - 本地计算机的打印机在远程会话中不可用。\n1 - 本地计算机的打印机在远程会话中可用。", ""},
        {"redirectsmartcards", "redirectsmartcards", "i", "1", "确定客户端计算机上的智能卡设备是否将被重定向并在远程会话中可用。\n\n0 - 本地计算机的智能卡设备在远程会话中不可用。\n1 - 本地计算机的智能卡设备在远程会话中可用。", ""},
        {"redirectwebauthn", "redirectwebauthn", "i", "1", "确定远程计算机上的 WebAuthn 请求是否将被重定向到本地计算机，从而允许使用本地验证器（例如 Windows Hello 企业版和安全密钥）。\n\n0 - 远程会话的 WebAuthn 请求不会发送到本地计算机进行身份验证，必须在远程会话中完成。\n1 - 远程会话的 WebAuthn 请求将发送到本地计算机进行身份验证。", ""},
        {"remoteapplicationcmdline", "remoteapplicationcmdline", "s", "", "RemoteApp 的可选命令行参数。", ""},
        {"remoteapplicationexpandworkingdir", "remoteapplicationexpandworkingdir", "i", "0", "确定 RemoteApp 工作目录参数中的环境变量应在本地还是远程展开。\n\n0 - 环境变量应展开为本地计算机的值。\n1 - 环境变量应在远程计算机上展开为远程计算机的值。\n\n注意：RemoteApp 工作目录通过 shell working directory 参数指定。", ""},
        {"remoteapplicationicon", "remoteapplicationicon", "s", "", "指定启动 RemoteApp 时在远程桌面界面中显示的图标文件名。默认情况下，RDC 显示标准远程桌面图标。\n\n注意：仅支持 .ico 文件。", ""},
        {"screen_mode_id", "screen mode id", "i", "2", "确定连接到远程计算机时远程会话窗口是否全屏显示。\n\n1 - 远程会话在窗口中显示。\n2 - 远程会话全屏显示。", ""},
        {"selectedmonitors", "selectedmonitors", "s", "", "指定远程会话使用哪些本地显示器。所选显示器必须连续。需要将 use multimon 设置为 1。\n\n以逗号分隔的计算机专用显示器 ID 列表。可以通过调用 mstsc.exe /l 获取 ID。列出的第一个 ID 将设置为会话中的主显示器。默认为所有显示器。", ""},
        {"session_bpp", "session bpp", "i", "32", "确定连接时远程计算机的颜色深度（位）。\n\n8 - 256 色（8 位）。\n15 - 高彩色（15 位）。\n16 - 高彩色（16 位）。\n24 - 真彩色（24 位）。\n32 - 最高质量（32 位）。", ""},
        {"shell_working_directory", "shell working directory", "s", "", "指定备用外壳程序时，远程计算机上使用的工作目录。", ""},
        {"signscope", "signscope", "s", "", "使用 .rdp 文件签名时，为其生成签名的 .rdp 文件设置列表，以逗号分隔。", ""},
        {"singlemoninwindowedmode", "singlemoninwindowedmode", "i", "0", "确定多显示器远程会话在退出全屏时是否自动切换到单显示器。需要将 use multimon 设置为 1。仅在 Windows 版 Windows 应用和 Windows 版远程桌面应用中可用。\n\n0 - 退出全屏时远程会话保留所有显示器。\n1 - 退出全屏时远程会话切换到单显示器。", ""},
        {"smart_sizing", "smart sizing", "i", "0", "确定调整窗口大小时，客户端计算机是否应缩放远程计算机上的内容以适应客户端窗口大小。\n\n0 - 调整大小时不缩放客户端窗口显示。\n1 - 调整大小时缩放客户端窗口显示。", ""},
        {"span_monitors", "span monitors", "i", "0", "确定连接到远程计算机时，远程会话窗口是否跨多个显示器。\n\n0 - 不启用跨显示器。\n1 - 启用跨显示器。\n\n注意：使用远程桌面连接 7（Windows 7/2008）时，建议使用 use multimon 设置。", ""},
        {"superpanaccelerationfactor", "superpanaccelerationfactor", "i", "1", "指定 SuperPan 模式下，客户端鼠标每移动一个像素，屏幕视图在给定方向上滚动的像素数。", ""},
        {"targetisaadjoined", "targetisaadjoined", "i", "0", "允许使用用户名和密码连接到已加入 Microsoft Entra 的会话主机。此属性仅适用于非 Windows 客户端和未加入 Microsoft Entra 的本地 Windows 设备。\n\n0 - 对于满足要求的 Windows 设备，连接到已加入 Microsoft Entra 的会话主机会成功，但其他连接将失败。\n1 - 连接到已加入 Microsoft Entra 的主机会成功，但连接会话主机时只能输入用户名和密码凭据。\n\n注意：此属性正被 enablerdsaadauth 取代。", ""},
        {"usbdevicestoredirect", "usbdevicestoredirect", "s", "", "确定连接到支持 RemoteFX USB 重定向的远程会话时，客户端计算机上哪些受支持的 RemoteFX USB 设备将被重定向并在远程会话中可用。\n\n未指定值 - 不重定向任何受支持的 RemoteFX USB 设备。\n* - 重定向所有受支持且未被高级重定向机制重定向的 RemoteFX USB 设备。\n{设备安装类 GUID} - 重定向属于指定设备安装类的所有受支持的 RemoteFX USB 设备。\nUSB\InstanceID - 重定向指定实例 ID 的受支持 RemoteFX USB 设备。\n-USB\InstanceID - 即使设备属于要重定向的设备安装类，也不重定向指定实例 ID 的受支持 RemoteFX USB 设备。", ""},
        {"use_multimon", "use multimon", "i", "0", "确定连接到远程计算机时会话是否使用真正的多显示器支持。\n\n0 - 不启用多显示器支持。\n1 - 启用多显示器支持。", ""},
        {"username", "username", "s", "", "指定用于登录远程计算机的用户帐户名称。", ""},
        {"videoplaybackmode", "videoplaybackmode", "i", "1", "确定 RDC 是否使用 RDP 高效多媒体流进行视频播放。\n\n0 - 不使用 RDP 高效多媒体流进行视频播放。\n1 - 尽可能使用 RDP 高效多媒体流进行视频播放。", ""},
        {"winposstr", "winposstr", "s", "0,3,0,0,800,600", "指定客户端计算机上会话窗口的位置和尺寸。", ""},
        {"workspaceid", "workspaceid", "s", "", "此设置定义与包含此设置的 RDP 文件关联的 RemoteApp 和桌面 ID。\n\n无", ""}
    }

    ' Array to store recommended default options
    Public RecommendedDefaultOptions As String(,) = {
        {"disableremoteappcapscheck", "disableremoteappcapscheck", "i", "1"},
        {"drivestoredirect", "drivestoredirect", "s", "*"},
        {"prompt_for_credentials", "prompt for credentials", "i", "1"},
        {"promptcredentialonce", "promptcredentialonce", "i", "0"},
        {"redirectcomports", "redirectcomports", "i", "1"},
        {"span_monitors", "span monitors", "i", "1"},
        {"use_multimon", "use multimon", "i", "1"}
    }

    ' Array to store changed options during editing
    Dim changedOptions As String(,)

    ' Index of the currently selected row in the OptionsListBox
    Dim selectedRow As Integer = 0

    ' Copy the original options to the changedOptions array
    Private Sub CopyOptions()
        changedOptions = New String(optionsList.GetLength(0) - 1, optionsList.GetLength(1) - 1) {}
        Array.Copy(optionsList, changedOptions, optionsList.Length)
    End Sub

    ' Main function that prepares and opens the window (to be called from elsewhere)
    Public Function EditAdditionalOptions(additionalOptions As String(,))
        ' Copy options, load additional options, and update the changed options
        CopyOptions()
        LoadAdditionalOptions(additionalOptions)
        UpdateChangedOptions()

        ' Load options into the OptionsListBox
        OptionsListBox.Items.Clear()
        For row As Integer = 0 To optionsList.GetLength(0) - 1
            OptionsListBox.Items.Add(optionsList(row, 1))
        Next

        ' Set the selected item in OptionsListBox and load the selected option
        OptionsListBox.SelectedIndex = selectedRow
        LoadSelected()

        ' Show the form
        ShowDialog()

        ' Export saved options and return the result
        Dim SavedOptions As String(,) = ExportSavedOptionsAsArray()
        Return SavedOptions

        ' Dispose of the form
        Dispose()
    End Function

    ' Load additional options and update the changed options array
    Private Sub LoadAdditionalOptions(additionalOptions As String(,))
        If additionalOptions.Length > 1 Then
            For row As Integer = 0 To optionsList.GetLength(0) - 1
                For additionalOptionRow As Integer = 0 To additionalOptions.GetLength(0) - 1
                    If optionsList(row, 1) = additionalOptions(additionalOptionRow, 1) Then
                        changedOptions(row, 3) = additionalOptions(additionalOptionRow, 3)
                    End If
                Next
            Next
        End If
    End Sub

    ' Handle the selection change in OptionsListBox
    Private Sub OptionsListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles OptionsListBox.SelectedIndexChanged
        If OptionsListBox.SelectedItems.Count = 1 Then
            selectedRow = OptionsListBox.SelectedIndex
            LoadSelected()
        End If
    End Sub

    ' Load the details of the selected option into the description and value textboxes
    Private Sub LoadSelected()
        Dim descriptionText = "# " & optionsList(selectedRow, 1) & vbCrLf & vbCrLf
        descriptionText = descriptionText & optionsList(selectedRow, 4).Replace("\n", vbCrLf)
        Dim valueText = changedOptions(selectedRow, 3)

        If optionsList(selectedRow, 3) <> "" Then
            descriptionText = descriptionText & vbCrLf & vbCrLf & "默认值：" & optionsList(selectedRow, 3)
        End If

        DescriptionTextBox.Text = descriptionText
        ValueTextBox.Text = valueText
    End Sub

    ' Handle the change in the value textbox
    Private Sub ValueTextBox_TextChanged(sender As Object, e As EventArgs) Handles ValueTextBox.TextChanged
        If changedOptions(selectedRow, 3) <> ValueTextBox.Text Then
            changedOptions(selectedRow, 3) = ValueTextBox.Text
            UpdateChangedOptions()
        End If
    End Sub

    ' Update the ChangedOptionsListView with any changes
    Private Sub UpdateChangedOptions()
        ChangedOptionsListView.Items.Clear()

        For row As Integer = 0 To optionsList.GetLength(0) - 1
            If optionsList(row, 3) <> changedOptions(row, 3) Then
                Dim newItem As ListViewItem = ChangedOptionsListView.Items.Add(changedOptions(row, 1))
                newItem.SubItems.Add(changedOptions(row, 2))
                newItem.SubItems.Add(changedOptions(row, 3))
            End If
        Next
    End Sub

    ' Export only the modified options as an array
    Private Function ExportSavedOptionsAsArray()
        Dim selectedIndicesList As New List(Of Integer)

        For row As Integer = 0 To optionsList.GetLength(0) - 1
            If optionsList(row, 3) <> changedOptions(row, 3) Then
                selectedIndicesList.Add(row)
            End If
        Next

        Dim selectedIndices() As Integer = selectedIndicesList.ToArray()

        Dim changedOptionsNoDesc As String(,) = RemoveDescriptions(changedOptions)
        Return SelectRows(changedOptionsNoDesc, selectedIndices)
    End Function

    ' Select specific rows from the array
    Function SelectRows(originalArray As String(,), selectedIndices() As Integer) As String(,)
        Dim numSelectedRows As Integer = selectedIndices.Length
        Dim numCols As Integer = originalArray.GetLength(1)

        ' Create a new array with the selected rows
        Dim newArray(numSelectedRows - 1, numCols - 1) As String

        ' Copy the selected rows from the original array
        For i As Integer = 0 To numSelectedRows - 1
            Dim rowIndex As Integer = selectedIndices(i)
            For j As Integer = 0 To numCols - 1
                newArray(i, j) = originalArray(rowIndex, j)
            Next
        Next

        Return newArray
    End Function

    ' Remove descriptions from the array
    Function RemoveDescriptions(originalArray(,) As String) As String(,)
        Dim numRows As Integer = originalArray.GetLength(0)
        Dim numColumns As Integer = Math.Min(originalArray.GetLength(1), 4)

        Dim newArray(numRows - 1, numColumns - 1) As String

        For i As Integer = 0 To numRows - 1
            For j As Integer = 0 To numColumns - 1
                newArray(i, j) = originalArray(i, j)
            Next
        Next

        Return newArray
    End Function

    ' Handle the Close button being clicked
    Private Sub SaveButton_Click(sender As Object, e As EventArgs) Handles SaveButton.Click
        Me.Close()
    End Sub

    ' Handles the Reset button being clicked, resets all options to RDP defaults (so they are not active)
    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click
        CopyOptions()
        UpdateChangedOptions()
        LoadSelected()
    End Sub

    ' Handles the Defaults button being clicked, clears all options and adds all recommended default options
    Private Sub DefaultsButton_Click(sender As Object, e As EventArgs) Handles DefaultsButton.Click
        CopyOptions()
        LoadAdditionalOptions(RecommendedDefaultOptions)
        UpdateChangedOptions()
        LoadSelected()
    End Sub

    ' Handles items in the Changed Options ListView being clicked/selected, scrolls to the selected option in the main Options ListBox
    Private Sub ChangedOptionsListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ChangedOptionsListView.SelectedIndexChanged
        ScrollToSelectedOption()
        ChangedOptionsListView.Focus()
    End Sub

    ' As above, scrolls to the selected option in the main Options ListBox
    Private Sub ScrollToSelectedOption()
        If ChangedOptionsListView.SelectedItems.Count > 0 Then
            Dim selectedOptionName As String = ChangedOptionsListView.SelectedItems(0).Text
            OptionsListBox.SelectedItem = selectedOptionName
        End If
    End Sub

    Private Sub ResetValueButton_Click(sender As Object, e As EventArgs) Handles ResetValueButton.Click
        If ValueTextBox.Text <> optionsList(selectedRow, 3) Then
            changedOptions(selectedRow, 3) = optionsList(selectedRow, 3)
            LoadSelected()
            UpdateChangedOptions()
        End If
    End Sub
End Class