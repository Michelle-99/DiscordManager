using DCM.Core.Interfaces;
using DCM.Core.Models;
using Discord;

namespace DCM.Core.Builder;

public class DefaultConfigBuilder<TConfig> : IBuilder<DCMConfig> where TConfig : class
{
    private readonly TConfig _config;
    private readonly DCMConfig _dcmConfig = new();
    private readonly JsonDiscordConfig _discordConfig = new();

    public DefaultConfigBuilder(TConfig config)
    {
        _config = config;
    }


    public DCMConfig Build()
    {
        return _dcmConfig;
    }

    public DefaultConfigBuilder<TConfig> HasAlwaysDownloadDefaultStickers(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.AlwaysDownloadDefaultStickers = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasAlwaysDownloadUsers(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.AlwaysDownloadUsers = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasAlwaysResolveStickers(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.AlwaysResolveStickers = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasAPIOnRestInteractionCreation(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.APIOnRestInteractionCreation = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasConnectionTimeout(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.ConnectionTimeout = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasDefaultGuild(Func<TConfig, ulong> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _dcmConfig.DefaultGuild = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasDefaultRetryMode(Func<TConfig, RetryMode?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.DefaultRetryMode = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasFormatUsersInBidirectionalUnicode(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.FormatUsersInBidirectionalUnicode = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasGatewayHost(Func<TConfig, string> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.GatewayHost = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasGatewayIntents(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.GatewayIntents = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasHandlerTimeout(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.HandlerTimeout = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasIdentifyMaxConcurrency(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.IdentifyMaxConcurrency = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasLargeThreshold(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.LargeThreshold = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasLogGatewayIntentWarnings(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.LogGatewayIntentWarnings = selector(arg: _config);
        return this;
    }


    public DefaultConfigBuilder<TConfig> HasLoginToken(Func<TConfig, string> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _dcmConfig.LoginToken = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasLogLevel(Func<TConfig, LogSeverity?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.LogLevel = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasMaxWaitBetweenGuildAvailablesBeforeReady(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.MaxWaitBetweenGuildAvailablesBeforeReady = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasMessageCacheSize(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.MessageCacheSize = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasShardId(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.ShardId = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasSuppressUnknownDispatchWarnings(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.SuppressUnknownDispatchWarnings = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasTotalShards(Func<TConfig, int?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.TotalShards = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasUseInteractionSnowflakeDate(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.UseInteractionSnowflakeDate = selector(arg: _config);
        return this;
    }

    public DefaultConfigBuilder<TConfig> HasUseSystemClock(Func<TConfig, bool?> selector)
    {
        if (selector is null)
            throw new ArgumentNullException(nameof(selector));

        _discordConfig.UseSystemClock = selector(arg: _config);
        return this;
    }
}